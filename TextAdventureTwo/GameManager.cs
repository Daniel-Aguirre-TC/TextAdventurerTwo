using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TextAdventureTwo.GameMessages;
using TextAdventureTwo.GamePlayer;
using TextAdventureTwo.GameWorld;

namespace TextAdventureTwo
{
    public static class GameManager
    {

        static bool StillPlaying { get; set; }
        static Player User { get; set; }
        static World CurrentWorld { get; set; }
        static Location CurrentLocation { get; set; }
        static Location SavedLocation { get; set; }

        static List<string> Messages { get; set; }

        static GameManager()
        {
            Messages = new List<string>();
            CurrentWorld = WorldFactory.CreateWorld();

        }

        //TODO: Should probably move to a LocationHandler class
        #region MoveLocation

        /// <summary>
        /// Return the location stored in SavedLocation property.
        /// </summary>
        public static void ReturnToSavedLocation()
        {
            MoveToLocation(SavedLocation.XCoord, SavedLocation.YCoord, false, false);
        }

        /// <summary>
        /// This method allows you to return to your current location without needing a reference to where you are. It will not display an entry message nor will it clear the messages.
        /// </summary>
        public static void ReturnToCurrentLocation()
        {
            MoveToLocation(CurrentLocation.XCoord, CurrentLocation.YCoord, false, false);
        }

        /// <summary>
        /// Move to the location at the provided (x,y). DisplayEntryMessage if applicable, and clearMessages in the screen
        /// </summary>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        /// <param name="displayEntryMessage"></param>
        /// <param name="clearMessages"></param>
        public static void MoveToLocation(int xCoord, int yCoord, bool displayEntryMessage, bool clearMessages)
        {
            CurrentLocation = CurrentWorld.FindLocation(xCoord, yCoord);
            User.Current = $"Current Location: {CurrentLocation.Name}";
            if(clearMessages)
            {
            MessageController.ClearMessages();
            }
            if (CurrentLocation.EntryMessage[0] != "" && CurrentLocation.EntryMessage != null && displayEntryMessage)
            {
                MessageController.AddMessage(CurrentLocation.EntryMessage);
            }
            ConsoleUI.ClearOptions();
            CurrentLocation.Options.ForEach(ConsoleUI.AddOption);

        }

        /// <summary>
        /// Default MoveToLocation will take the provdied (x,y) move to that location, display any available entry message after clearing all messages.
        /// </summary>
        /// <param name="xCoord"></param>
        /// <param name="yCoord"></param>
        public static void MoveToLocation(int xCoord, int yCoord)
        {
            MoveToLocation(xCoord, yCoord, true, true);
        }

        #endregion


        /// <summary>
        /// Begin the game by creating a player, and then placing them in Rogue Encampment followed by starting the game loop.
        /// </summary>
        public static void StartGame()
        {
            StillPlaying = true;
            Prompter.StartingScreen();
            User = new Player();
            MoveToLocation(0, 0);
            int optionIndex = 0;

            while (StillPlaying)
            {
                if (optionIndex >= ConsoleUI.Options.Count())
                { optionIndex = ConsoleUI.Options.Count - 1; }
                bool processInput = false;
                Prompter.PrintPage(User, optionIndex);
                switch (GetInput())
                {
                    case "right":
                        optionIndex = optionIndex >= ConsoleUI.Options.Count() - 1 ? 0 : ++optionIndex;
                        break;

                    case "left":
                        optionIndex = optionIndex == 0 ? ConsoleUI.Options.Count() - 1 : --optionIndex;
                        break;

                    case "enter":
                        processInput = true;
                        break;
                    default:
                        break;
                }

                if(processInput)
                {
                    ProcessInput(ConsoleUI.Options[optionIndex]);
                }


            }
        }

        /// <summary>
        /// Take in a string representing the option the player selected. 
        /// </summary>
        /// <param name="optionSelected"></param>
        static void ProcessInput(string optionSelected)
        {
            switch (optionSelected)
            {
                // view a list of Npcs to talk to at the current location.
                case "Talk to Locals":
                    CurrentLocation.TalkToLocals();
                    break;
                
                // start a conversation with a selected Npc
                case string word when word.StartsWith("Approach"):
                    var npcApproached = NpcFactory.FindNpc(word.Replace("Approach ", ""));
                    User.Current = $"You Are Currently Talking To {npcApproached.Name}";
                    ConsoleUI.ClearOptions();
                    ConsoleUI.AddOption(npcApproached.ApproachNpc());
                    break;
                
                // select a conversation topic with npc you're currently talking to
                case string word when word.StartsWith("Discuss "):
                    var npcTalkingTo = NpcFactory.FindNpc(User.Current.Replace("You Are Currently Talking To ", ""));
                    MessageController.ClearMessages();
                    MessageController.AddMessage(npcTalkingTo.PullDialog(word.Replace("Discuss ", "")));
                    break;
                
                // return to the current location.
                case "Return to Town":
                    //TODO: Refactor this with new method to return to current location and display a message that you return to the town.
                    MoveToLocation(CurrentLocation.XCoord, CurrentLocation.YCoord);
                    break;
                
                case "Go to Stash":
                    MessageController.AddMessage("                     Stash is not yet available                     ");
                    break;
                
                // if option begins with "Travel" then get direction and move location based on that,
                case string word when word.StartsWith("Travel "):
                    switch (word.Replace("Travel ", ""))
                    {
                        case "East":
                            MoveToLocation(CurrentLocation.XCoord + 1, CurrentLocation.YCoord);
                            break;
                        case "West":
                            MoveToLocation(CurrentLocation.XCoord - 1, CurrentLocation.YCoord);
                            break;
                        case "North":
                            MoveToLocation(CurrentLocation.XCoord, CurrentLocation.YCoord + 1);
                            break;
                        case "South":
                            MoveToLocation(CurrentLocation.XCoord, CurrentLocation.YCoord - 1);
                            break;
                        default:
                            break;
                    }
                    break;
                
                case "Use Waypoint":
                    //TODO: make AddMessage handle formatting messages to the right length.
                    MessageController.AddMessage("                  You don't have any waypoints yet                  ");
                    break;
                
                case string word when word.StartsWith("Explore "):
                    Explorer.Explore(CurrentLocation, User);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Take in the selected key and return a string based on what that key was. The result is used for ProcessInput()
        /// </summary>
        /// <returns></returns>
        public static string GetInput()
        {
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.RightArrow:
                    return "right";
                case ConsoleKey.LeftArrow:
                    return "left";
                case ConsoleKey.Enter:
                    return "enter";
                case ConsoleKey.H:
                    //TODO: use health potion/mana potion
                    return "health";
                case ConsoleKey.M:
                    return "mana";
                case ConsoleKey.Escape:
                    return "quit";
                case ConsoleKey.I:
                    return "inv";
                case ConsoleKey.Q:
                    return "quest";

                default:
                    return "";
            }
        }


        #region 
        /// <summary>
        /// Pull a copy of all the messages being stored to display within the ConsoleUI
        /// </summary>
        /// <returns></returns>
        public static string[] PullMessages()
        {
            return Messages.ToArray();
        }


        //TODO: SkipLine Overload.

        /// <summary>
        /// For each string in the provided array, add to the list of messages to display on the ConsoleUI.
        /// </summary>
        /// <param name="newMessage"></param>
        public static void AddMessage(string[] newMessage)
        {
            newMessage.ToList().ForEach(Messages.Add);
        }

        /// <summary>
        /// Add the provided string to the list of messages to display on the ConsoleUI.
        /// </summary>
        /// <param name="newMessage"></param>
        public static void AddMessage(string newMessage)
        {
            Messages.Add(newMessage);
        }

        #endregion

    }
}
