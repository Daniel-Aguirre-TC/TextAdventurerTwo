using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public static class WorldFactory
    {

        static Dictionary<string, string[]> LocationOptions { get; set; }
        
        static WorldFactory()
        {
            LocationOptions = new Dictionary<string, string[]>()
            {
                {"RogueEncampment", new string[] {                
                    "Talk to Locals", "Go to Stash", "Use Waypoint", "Leave Town"                
                } }

            };
        }


        internal static World CreateWorld()
        {
            World world = new World();
            world.AddLocation(0, 0, "Rogue Encampment", LocationOptions["RogueEncampment"], Messages.RogueEncampment["RogueEncampmentEntry"], NpcFactory.ActOneNpcs());
            

            return world;
        }

    }
}
