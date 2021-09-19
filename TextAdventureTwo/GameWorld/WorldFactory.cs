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
                    "Explore Blood Moor", "Travel West",
                } }

            };
        }


        internal static World CreateWorld()
        {
            World world = new World();
            world.AddLocation(0, 0, "Rogue Encampment", DefaultLocationOptions["RogueEncampment"], Messages.RogueEncampment["RogueEncampmentEntry"], NpcFactory.ActOneNpcs());
            world.AddLocation(1, 0, "Blood Moor", DefaultLocationOptions["BloodMoor"], Messages.BloodMoor["BloodMoorEntry"], NpcFactory.BloodMoorMobs());

            return world;
        }

    }
}
