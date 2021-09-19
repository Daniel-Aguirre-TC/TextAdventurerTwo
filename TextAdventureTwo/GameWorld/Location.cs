using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public class Location
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }
        public string Name { get; set; }
        public string[] EntryMessage { get; set; }
        public string[] Options { get; set; }
        public List<Npc> Npcs { get; set; }



    }
}
