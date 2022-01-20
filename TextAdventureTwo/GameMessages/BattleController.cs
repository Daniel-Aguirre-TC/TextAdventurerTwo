using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo.GameMessages
{
    public static class BattleController
    {
        static List<string> PlayerAttackOptions { get; set; }
        static Random rng { get; set; }


        static BattleController()
        {
            rng = new Random();
            PlayerAttackOptions = new List<string>
            {
                "Attack",
                "Defend",
                "Run Away"
            };
        }


        public static void StartBattle(Player user, List<Enemy> enemies)
        {

            // select a random enemy from the list provided
            var enemy = enemies[rng.Next(enemies.Count())];
            var hasRanAway = false;
            MessageController.AddMessage(enemy.Dialog["Encountered"]);
            user.Current = $"You are currently fighting: {enemy.Name}";

            // while all enemies and the player are still above 0 health
            while( enemy.CurrentHealth > 0 && user.CurrentHealth > 0 && hasRanAway == false)
            {

                PlayerTurn(user, enemy, ref hasRanAway);
                if (enemy.CurrentHealth > 0)
                {
                    EnemyTurn(user, enemy);
                }               

            }


            // at the end of the battle return user.IsDefending to false.
            user.IsDefending = false;
            //Set the enemy health back to max
            //TODO: create a new instance of the enemy so that we can delete the instance at the end of the battle and not affect the original copy.
            enemy.CurrentHealth = enemy.MaxHealth;
            // then return to location.
            if(user.CurrentHealth > 0)
            {
                MessageController.AddMessage("                                                                    ");
                MessageController.AddMessage("                         You won the battle!                        ");
                GameManager.ReturnToCurrentLocation();
            }

            else
            {

                MessageController.AddMessage("                                                                    ");
                MessageController.AddMessage("      Despite your valiant efforts, you were unable to defeat this  ");
                MessageController.AddMessage("monster from Hell. As you breathe your last breath, you wonder if   ");
                MessageController.AddMessage("another hero will rise to finish your quest and save humanity.      ");
                Prompter.PrintPage(user, 0);
                //TODO: create a better way to end the application when finished.
                Console.WriteLine();
                Console.WriteLine("Press any key to end the application.".PadLeft(Console.WindowWidth / 2 + 19).PadRight(Console.WindowWidth));
                Console.ReadKey();
                Environment.Exit(0);
            }

        }


        static void PlayerTurn(Player user, Enemy enemy, ref bool hasRanAway)
        {
            // Ask player for input
            ConsoleUI.ClearOptions();
            ConsoleUI.AddOption(PlayerAttackOptions.ToArray());
            var WaitingForInput = true;
            int optionIndex = 0;
            while(WaitingForInput)
            {
                if (optionIndex >= ConsoleUI.Options.Count())
                { optionIndex = ConsoleUI.Options.Count - 1; }
                bool processInput = false;
                Prompter.PrintPage(user, optionIndex);               
                switch (GameManager.GetInput())
                {
                    case "right":
                        optionIndex = optionIndex >= ConsoleUI.Options.Count() - 1 ? 0 : ++optionIndex;
                        break;

                    case "left":
                        optionIndex = optionIndex == 0 ? ConsoleUI.Options.Count() - 1 : --optionIndex;
                        break;
                    case "enter":
                        processInput = true;
                        break;
                    default:
                        break;
                }

                if (processInput)
                {
                    WaitingForInput = false;

                    ProcessBattleInput(ConsoleUI.Options[optionIndex], user, enemy, ref hasRanAway);

                    //temporary playing out with delaying messages
                    Prompter.PrintPage(user, optionIndex);
                    Thread.Sleep(400);
                    
                }



            }



        }        


        static void ProcessBattleInput(string optionSelected, Player user, Enemy enemy, ref bool hasRunAway)
        {

            switch (optionSelected)
            {
                case "Attack":
                    var attackSuccess = rng.Next(100);
                    switch (attackSuccess)
                    {
                        case int num when num < user.ChanceToHit:
                            if(num < user.ChanceToHit/2)
                            {
                                MessageController.AddMessage("                                                                    ");
                                MessageController.AddMessage("                     You strike a critical hit!                     ");
                                MessageController.AddMessage("                       You dealt two damage.                        ");
                                enemy.CurrentHealth -= 2;
                                var enemyHp = enemy.CurrentHealth.ToString().PadRight(4);
                                MessageController.AddMessage($"                    The enemies health is now {enemyHp}                  ");
                            }
                            else
                            {
                                MessageController.AddMessage("                                                                    ");
                                MessageController.AddMessage("                      You strike successfully.                      ");
                                MessageController.AddMessage("                       You dealt one damage.                        ");
                                enemy.CurrentHealth -= 1;
                                var enemyHp = enemy.CurrentHealth.ToString().PadRight(4);
                                MessageController.AddMessage($"                    The enemies health is now {enemyHp}                  ");
                            }
                            break;

                        default:
                            MessageController.AddMessage("                                                                    ");
                            MessageController.AddMessage("                  You attempt to strike, but miss.                  ");
                            break;
                    }

                break;
                case "Defend":
                    user.IsDefending = true;
                    MessageController.AddMessage("                                                                    ");
                    MessageController.AddMessage("               You brace yourself for the next attack.              ");
                    break;

                case "Run Away":
                    // 50/50 chance of running away
                    if(rng.Next(100) >= 50)
                    {
                        hasRunAway = true;
                        MessageController.AddMessage("                                                                    ");
                        MessageController.AddMessage("                     You run away from the fight.                   ");
                        GameManager.ReturnToCurrentLocation();
                        
                    }
                    else
                    {
                        MessageController.AddMessage("                                                                    ");
                        MessageController.AddMessage("                You fail to run away from the fight.                ");
                    }
                    break;

                default:
                    break;
            }

        }




        static void EnemyTurn(Player user, Enemy enemy)
        {

            switch (rng.Next(100))
            {
                // 20% chance to yell gibberish
                case int num when num > 80:
                    MessageController.AddMessage("                                                                    ");
                    MessageController.AddMessage("                Instead of attacking the Fallen One                 ");
                    MessageController.AddMessage("                runs in circles screaming gibberish                 ");

                    break;
                //20% chance to miss
                case int num when num > 60:
                    MessageController.AddMessage("                                                                    ");
                    MessageController.AddMessage("                   The fallen one charges at you!                   ");
                    MessageController.AddMessage("                       Thankfully it missed.                        ");

                    break;
                //remaining 60% chance is to land an attack
                default:
                    MessageController.AddMessage("                                                                    ");
                    MessageController.AddMessage("                   The fallen one lands a strike!                   ");
                    MessageController.AddMessage("                      You receive two damage.                       ");
                    user.CurrentHealth -= 2;
                    break;
            }


        }


    }
}
