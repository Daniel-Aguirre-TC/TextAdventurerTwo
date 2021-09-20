using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public static class WorldFactory
    {

        static Dictionary<string, string[]> DefaultLocationOptions { get; set; }
        
        static WorldFactory()
        {
            DefaultLocationOptions = new Dictionary<string, string[]>()
            {
                {"RogueEncampment", new string[] {                
                    "Talk to Locals", "Go to Stash", "Use Waypoint", "Travel East"                
                } },

                {"BloodMoor", new string[] {
                    "Explore Blood Moor", "Travel West"
                } },

                {"DenOfEvil", new string[]
                {
                    "Explore Den of Evil", "Return to Blood Moor"
                } }

            };
        }


        /* Map
        
                                 Den of Evil (1,1)                                  
                                      /'\
                                       |
        Rogue Encampment (0,0) --> Blood Moor(1,0) --> Cold Plains (2,0)
        

        */

        internal static World CreateWorld()
        {
            World world = new World();
            world.AddLocation(0, 0, "Rogue Encampment",
                DefaultLocationOptions["RogueEncampment"], Messages.EntryMessage["RogueEncampment"], NpcFactory.ActOneNpcs());
            
            world.AddLocation(1, 0, "Blood Moor",
                DefaultLocationOptions["BloodMoor"], Messages.EntryMessage["BloodMoor"], NpcFactory.BloodMoorMobs());
            
            world.AddLocation(1, 1, "Den of Evil",
                DefaultLocationOptions["DenOfEvil"], Messages.EntryMessage["DenOfEvil"], NpcFactory.DenOfEvilMobs()); 
            
            //TODO: NpcFactory creating monsters for NpcList

            return world;
        }

    }
}
