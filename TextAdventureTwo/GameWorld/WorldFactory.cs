using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public static class WorldFactory
    {

        internal static World CreateWorld()
        {
            World world = new World();
            world.AddLocation(0, 0, "Rogue Encampment", Messages.RogueEncampment["RogueEncampmentEntry"], NpcFactory.ActOneNpcs());
            

            return world;
        }

    }
}
