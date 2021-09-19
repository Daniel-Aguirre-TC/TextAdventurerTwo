using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureTwo.GamePlayer
{
    public class Npc
    {
        public string Name { get; set; }
        public Dictionary<string, string[]> Dialog { get; set; }
        
        public Npc(string name, Dictionary<string, string[]> messages)
        {
            Name = name;
            Dialog = messages;
        }


    }
}
