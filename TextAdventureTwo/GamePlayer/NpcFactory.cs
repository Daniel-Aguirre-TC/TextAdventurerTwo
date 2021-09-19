using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GameWorld;

namespace TextAdventureTwo.GamePlayer
{
    public static class NpcFactory
    {
        static List<Npc> AllNpcs { get; set; }

        static Dictionary<string, string[]> WarrivDialog {get; set;}

        static NpcFactory()
        {

            WarrivDialog = new Dictionary<string, string[]>()
            {
                { "Greeting", new string[]{

                    "                                                                    ",
                    "      As you approach Warriv the caravan traveler, you wonder if he ",
                    "would consider selling his blue and grey outfit to you. It's hard   ",
                    "not to notice how comfortable and well suited for this environment  ",
                    "it appears to be.                                                   ",

                } },

                { "Introduction", new string[]{

                    "      Greetings, stranger. I'm not surprised to see your kind here. ",
                    "Many adventurers have traveled this way since the recent troubles   ",
                    "began. No doubt you've heard about the tragedy that befell Tristram.",
                    "Some say that Diablo, the Lord of Terror, walks the world again.    ",
                    "      I don't know if I believe that, but a Dark Wanderer did travel",
                    "this route a few weeks ago. He was headed East to the mountain pass ",
                    "guarded by the Rogue Monastery. Maybe it's nothing, but evil seems  ",
                    "to have trailed in his wake. You see, shortly after the Wanderer    ",
                    "went through, the Monastery's Gates to the pass were closed and     ",
                    "strange creatures began ravaging the countryside.                   ",
                    "      Until it's safer outside the camp and the gates are re-opened,",
                    "I'll remain here with my caravan. I hope to leave for Lut Gholein   ",
                    "before the shadow that fell over Tristram consumes us all. If you're",
                    "still alive then, I'll take you along. You should talk to Akara too.",
                    "She seems to be the leader here. Maybe she can tell you more.       "

                } }

            };
            AllNpcs = new List<Npc>
            {
                new Npc("Warriv", WarrivDialog )
                //TODO: New Enemy : Npc
                
            };
        }


        public static List<Npc> ActOneNpcs()
        {
            return new List<Npc>()
            {
                FindNpc("Warriv")
            };
        }

        public static List<Npc> BloodMoorMobs()
        {
            return new List<Npc>()
            {
                FindNpc("Warriv")
            };
        }

        public static Npc FindNpc(string npcName)
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
