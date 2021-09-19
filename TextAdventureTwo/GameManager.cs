using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        static List<string> Messages { get; set; }

        static GameManager()
        {
            Messages = new List<string>();
            CurrentWorld = WorldFactory.CreateWorld();

        }


        public static void MoveToLocation(int xCoord, int yCoord)
        {
            CurrentLocation = CurrentWorld.LocationAt(xCoord, yCoord);
            User.Current = $"Current Location: {CurrentLocation.Name}";
            MessageController.ClearMessages();
            if (CurrentLocation.EntryMessage[0] != "" && CurrentLocation.EntryMessage != null)
            {
                MessageController.AddMessage(CurrentLocation.EntryMessage);
            }
            ConsoleUI.ClearOptions();
            ConsoleUI.AddOption(CurrentLocation.Options);

        }


        public static void StartGame()
        {
            StillPlaying = true;
            Prompter.StartingScreen();
            User = new Player();
            MoveToLocation(0, 0);
            int optionIndex = 0;

            while(StillPlaying)
            {
                bool processInput = false;
                string option = "";
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
                        option = ConsoleUI.Options[optionIndex];
                        break;
                    default:
                        break;
                }

                if(processInput)
                {

                }


            }
        }

        static void ProcessInput(string optionSelected)
        {
            switch (optionSelected.ToLower())
            {
                case "talk to locals":
                    //TODO: for each npc in current location I  need to add a ""

                default:
                    break;
            }
        }

        static string GetInput()
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
