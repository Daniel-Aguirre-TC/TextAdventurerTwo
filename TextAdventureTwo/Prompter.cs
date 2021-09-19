using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TextAdventureTwo.GamePlayer;
using TextAdventureTwo.GameMessages;

namespace TextAdventureTwo
{

    // Handle calling the screen methods based on what the game manager tells it.
    // Format the messages as they are being passed to Screen class to achieve desired formatting.
    static class Prompter
    {


        public static void StartingScreen()
        {
            Console.CursorVisible = false;
            CenterVertically(Messages.Main["StartScreen"].Length);
            Screen.ClearThenPrint(PadToCenter(Messages.Main["StartScreen"]));
            Console.ReadKey();
            CenterVertically(Messages.Main["Intro"].Length);
            Screen.ClearThenPrint(PadToCenter(Messages.Main["Intro"]));
            Console.ReadKey();
        }
        
        public static int SelectClassScreen()
        {
            var confirmed = false;
            int selectedIndex = 0;
            while (!confirmed)
            {
                bool selectingClass = true;
                while (selectingClass)
                {
                    // clear screen, then print the page depending on what the current selectedIndex is.
                    Screen.ClearRows();
                    Screen.AddToRows(PadToCenter(Messages.Main["SelectClass"]));
                    Screen.AddToRows(PadToCenter(selectedIndex == 0 ? Messages.Main["AmazonSelected"] : Messages.Main["Amazon"]));
                    Screen.AddToRows(PadToCenter(selectedIndex == 1 ? Messages.Main["BarbarianSelected"] : Messages.Main["Barbarian"]));
                    Screen.ReprintWith(PadToCenter(selectedIndex == 2 ? Messages.Main["SorceressSelected"] : Messages.Main["Sorceress"]));

                    // take in input to adjust selection, accept selection, or hint to use arrows to change selection.
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            selectingClass = false;
                            break;
                        case ConsoleKey.UpArrow:

                            selectedIndex = selectedIndex == 0 ? 2 : --selectedIndex;
                            break;

                        case ConsoleKey.DownArrow:

                            selectedIndex = selectedIndex == 2 ? 0 : ++selectedIndex;
                            break;

                        default:
                            // if the user enters something else we will display this message then wait for a key press before reprinting page.
                            Screen.ReprintWith(PadToCenter("You can change your selection using the up and down arrows."));
                            Console.ReadKey();
                            break;
                    }
                }

                Screen.ClearRows();
                // show a screen displaying the selected classes stats.
                switch (selectedIndex)
                {
                    case 0:
                        Screen.AddToRows(PadToCenter(Messages.Main["Amazon"]));
                        Screen.ReprintWith(PadToCenter(Messages.Main["ShowAmazonStats"]));
                        break;

                    case 1:
                        Screen.AddToRows(PadToCenter(Messages.Main["Barbarian"]));
                        Screen.ReprintWith(PadToCenter(Messages.Main["ShowBarbarianStats"]));
                        break;

                    case 2:
                        Screen.AddToRows(PadToCenter(Messages.Main["Sorceress"]));
                        Screen.ReprintWith(PadToCenter(Messages.Main["ShowSorceressStats"]));
                        break;
                    default:
                        break;
                }
                // confirm if the player wishes to use this class.
                Console.Clear();
                confirmed = Screen.ReprintWithYesNoQ(PadToCenter("Is this your final decision?"));
                selectingClass = !confirmed;
            }
            Console.Clear();
            // return selected index once confirmed.
            return selectedIndex;
        }
        
        public static string GetPlayerName()
        {
            Screen.ClearRows();
            CenterVertically(Messages.Main["NameRequest"].Length);
            return Screen.ClearThenConfirmInput(PadToCenter(Messages.Main["NameRequest"]), "                            What is your name, Hero ? ");
        }
        
        public static void PrintPage(Player player, int indexSelected)
        {
            Screen.SetTopSpacing(0);
            Screen.ClearRows();
            Screen.ClearThenPrint(MessageController.DisplayMessages(ConsoleUI.FormatPage(player, indexSelected)));
        }
        
        static void CenterVertically(int nextMessageLength)
        {
            PadCeiling(Console.WindowHeight / 2 - (nextMessageLength / 2));
        }

        static void PadCeiling(int rowsToPad)
        {
            Screen.SetTopSpacing(rowsToPad);
        }

        /// <summary>
        /// Return the provided string array with padding to the left to center it horiziontally.
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        public static string[] PadToCenter(string[] textToCenter)
        {
            return textToCenter.Select(x => PadToCenter(x)).ToArray();
        }

        /// <summary>
        /// Return the provided string with padding to the left to center it horiziontally.
        /// </summary>
        /// <param name="textToCenter"></param>
        /// <returns></returns>
        public static string PadToCenter(string textToCenter)
        {
            if (textToCenter == null)
            {
                return "";
            }
            return textToCenter.PadLeft((int)MathF.Round((Console.WindowWidth / 2) + (textToCenter.Length / 2)));
        }


    }
}
