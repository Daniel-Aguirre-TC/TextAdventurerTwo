using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GameMessages;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public class Location
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Name { get; set; }
        public string[] EntryMessage { get; set; }
        public List<string> Options { get; set; }
        public List<Npc> Npcs { get; set; }

        public void TalkToLocals()
        {
            ConsoleUI.ClearOptions();
            Npcs.ForEach(x => ConsoleUI.AddOption($"Approach {x.Name}"));          
            ConsoleUI.AddOption("Return to Town");
            MessageController.AddMessage(new string[]
            {
                "                                                                    ",
                "                   You decide to visit the locals                   ",
            
            });

        }

        public void AddOption(string newOption)
        {
            Options.Add(newOption);
        }


    }
}
