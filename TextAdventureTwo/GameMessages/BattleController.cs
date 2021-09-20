using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if(enemy.CurrentHealth > 0)
                {
                    EnemyTurn(user, enemy);
                }

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
                    ProcessBattleInput(ConsoleUI.Options[optionIndex], user, enemy, ref hasRanAway);
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
                        //TODO: Calculate then apply damage to enemy
                        case int num when num < user.ChanceToHit:
                            if(num < user.ChanceToHit/2)
                            {
                                MessageController.AddMessage("                                                                    ");
                                MessageController.AddMessage("                     You strike a critical hit!                     ");
                            }
                            else
                            {
                                MessageController.AddMessage("                                                                    ");
                                MessageController.AddMessage("                      You strike successfully.                      ");
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

        }


    }
}
