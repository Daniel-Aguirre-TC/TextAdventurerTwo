using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GameWorld;

namespace TextAdventureTwo.GamePlayer
{
    public static class NpcFactory
    {
        static List<Npc> AllNpcs { get; set; }

        static NpcFactory()
        {
            AllNpcs = new List<Npc>
            {
                new Npc("Warriv", Messages.RogueEncampment)
            };
        }

        public static List<Npc> ActOneNpcs()
        {
            return new List<Npc>()
            {
                FindNpc("Warriv")
            };
        }

        static Npc FindNpc(string npcName)
        {
            foreach (var npc in AllNpcs)
            {
                if (npc.Name == npcName)
                {
                    return npc;
                }    
            }
            return null;
        }

        

    }
}
