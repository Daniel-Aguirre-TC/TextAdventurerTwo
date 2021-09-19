using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventureTwo.GameWorld
{
    public static class Explorer
    {
        static Random rng = new Random();

        public static void Explore(Location currentLocation)
        {
            switch (currentLocation.Name)
            {
                case "Blood Moor":
                    BloodMoor(currentLocation);
                    break;

                default:
                    break;
            }


            //TODO: use currentLocation name to call an explore method that will do something random dependant upon the
            // name of the currentLocation we are at. Blood Moore for example will randomly either locate the den allowing
            // it to be added to the location options list, find cold plains which will also add it to the option list, or
            // fight a monster which will pick a random monster from the ACtOneMobs list and start fight method that will
            // have a loop for battle mechanics


        }


        static void BloodMoor(Location currentLocation)
        {
            switch (rng.Next(100))
            {
                // 10% chance to find den
                case int num when num >= 90:
                    break;
                // 10% chance to find Cold Plains
                case int num when num >= 80:

                    break;
                // 10% chance to not find anything
                case int num when num >= 70:
                
                    break;
                // remaining 70% chance of starting a fight with a monster.
                default:
                    //TODO:  Fight monster
                    break;
            }

        }


    }
}
