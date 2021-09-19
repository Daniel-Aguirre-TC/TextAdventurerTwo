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
        }


        public static void StartGame()
        {
            Prompter.StartingScreen();
            User = new Player();
            MoveToLocation(0, 0);
            Prompter.PrintPage(User, 0);


            Console.ReadKey();

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
