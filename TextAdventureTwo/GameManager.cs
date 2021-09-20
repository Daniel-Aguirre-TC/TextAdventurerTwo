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
        static Location ReturnToLocation { get; set; }

        static List<string> Messages { get; set; }

        static GameManager()
        {
            Messages = new List<string>();
            CurrentWorld = WorldFactory.CreateWorld();

        }


        public static void MoveToLocation(int xCoord, int yCoord)
        {
            CurrentLocation = CurrentWorld.FindLocation(xCoord, yCoord);
            User.Current = $"Current Location: {CurrentLocation.Name}";
            MessageController.ClearMessages();
            if (CurrentLocation.EntryMessage[0] != "" && CurrentLocation.EntryMessage != null)
            {
                MessageController.AddMessage(CurrentLocation.EntryMessage);
            }
            ConsoleUI.ClearOptions();
            CurrentLocation.Options.ForEach(ConsoleUI.AddOption);

        }


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

        static void ProcessInput(string optionSelected)
        {
            switch (optionSelected)
            {
                case "Talk to Locals":
                    CurrentLocation.TalkToLocals();
                    break;
                
                    // start a conversation with an npc
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
                
                case "Return to Town":
                    MoveToLocation(CurrentLocation.XCoord, CurrentLocation.YCoord);
                    break;
                
                case "Go to Stash":
                    MessageController.AddMessage("                     Stash is not yet available                     ");
                    break;
                
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

        public static string[] PullMessages()
        {
            return Messages.ToArray();
        }

        public static void AddMessage(string[] newMessage)
        {
            newMessage.ToList().ForEach(Messages.Add);
        }

        public static void AddMessage(string newMessage)
        {
            Messages.Add(newMessage);
        }

    }  
}
