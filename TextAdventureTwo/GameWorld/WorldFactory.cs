using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureTwo.GameWorld
{
    public static class WorldFactory
    {

        internal static World CreateWorld()
        {
            World world = new World();
            world.AddLocation(0, 0, "Rogue Encampment");

            return world;
        }

    }
}
