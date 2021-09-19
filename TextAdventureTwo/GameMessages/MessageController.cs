using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;


namespace TextAdventureTwo.GameMessages
{
    public static class MessageController
    {

        static List<string> DisplayedMessages { get; set; }

        static MessageController()
        {
            DisplayedMessages = new List<string>();
        }

        public static string[] DisplayMessages(string[] consoleUI)
        {
            var index = 0;
            var newArray = consoleUI;
            for (int i = 0; i < consoleUI.Length; i++)
            {
                var line = new Regex(@".* (Line [\d]*%*) .*").Match(consoleUI[i]).Groups.Values.Select(x => x.ToString()).ToArray();
                if(line.Count() > 1)
                {
                    //TODO: change formatting to automatically break apart messages and pad them as needed.
                    newArray[i] = consoleUI[i].Replace(line[1], index >= DisplayedMessages.Count() ? 
                    " ".PadRight(line[1].Length) : DisplayedMessages[index]);
                    index++;
                }                

            }
            return newArray;
        }

        public static void ClearMessages()
        {
            DisplayedMessages.Clear();
        }


        public static void AddMessage(string[] newMessage)
        {
            newMessage.ToList().ForEach(DisplayedMessages.Add);
        }
        public static void AddMessage(string newMessage)
        {
            DisplayedMessages.Add(newMessage);
        }


    }
}
