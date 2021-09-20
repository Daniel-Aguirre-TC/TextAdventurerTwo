using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GameMessages;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameWorld
{
    public static class Explorer
    {
        static Random rng = new Random();
        static Dictionary<string, string[]> ExploreMessages { get; set; }

        static Explorer()
        {
            ExploreMessages = new Dictionary<string, string[]>()
            {
                { "FoundNothing", new string[]
                {
                    "                                                                    ",
                    "      You scour the area but to your surprise you find nothing. Not ",
                    "a single demon, undead, or foul beast. Though you you want to be    ",
                    "relieved you can't help but to fear for what may come next. You take",
                    "a deep breath and prepare yourself for your next step.              "
                } },

                { "FoundDenOfEvil", new string[]
                {
                    "                                                                    ",
                    "      As you explore the Blood Moor you begin to feel an evil       ",
                    "presence luring you to a cave. Though you are unaware of what dwells",
                    "within this Den of Evil, the fact that you could sense the darkness ",
                    "from so far away hints at the power of the demonic forces within.   "
                } },


            };

        }

        public static void Explore(Location currentLocation, Player player)
        {
            switch (currentLocation.Name)
            {
                case "Blood Moor":
                    BloodMoor(currentLocation, player);
                    break;

                //TODO: Case for Den of Evil
                default:
                    break;
            }


            //TODO: use currentLocation name to call an explore method that will do something random dependant upon the
            // name of the currentLocation we are at. Blood Moore for example will randomly either locate the den allowing
            // it to be added to the location options list, find cold plains which will also add it to the option list, or
            // fight a monster which will pick a random monster from the ACtOneMobs list and start fight method that will
            // have a loop for battle mechanics


        }


        static void BloodMoor(Location currentLocation, Player player)
        {

            switch (rng.Next(100))
            {
                // 10% chance to not find anything
                case int num when num >= 90:
                    MessageController.AddMessage(ExploreMessages["FoundNothing"]);
                    break;

                // 10% chance to find den
                case int num when num >= 80:
                    if (!currentLocation.Options.Contains("Enter Den of Evil"))
                    {
                        ConsoleUI.AddOption("Enter Den of Evil");
                        currentLocation.AddOption("Enter Den of Evil");
                        MessageController.AddMessage(ExploreMessages["FoundDenOfEvil"]);
                        break;
                    }
                    // if den is already found then we will just fight a monster.
                    else goto default;

                // 10% chance to find Cold Plains
                case int num when num >= 70:
                    MessageController.AddMessage(ExploreMessages["FoundNothing"]);
                    //TODO: set up finding cold plains
                    break;

                // remaining 70% chance of starting a fight with a monster.
                default:
                    BattleController.StartBattle(player, currentLocation.Enemies);
                    break;
            }
        }



    }
}
