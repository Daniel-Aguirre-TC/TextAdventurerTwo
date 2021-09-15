using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAdventureTwo
{

    // Handle calling the screen methods based on what the game manager tells it.
    // Format the messages as they are being passed to Screen class to achieve desired formatting.
    static class Prompter
    {

        public static void StartingScreen()
        {
            Console.CursorVisible = false;
            CenterVertically(Messages.General["Logo"].Length);
            Screen.ClearThenPrint(PadToCenter(Messages.General["Logo"]));
            Console.ReadKey();
            PadCeiling(Messages.General["Logo"].Length + Messages.General["Opening"].Length);
            Screen.ReprintWith(PadToCenter(Messages.General["Opening"]));
            Console.ReadKey();
        }





        static void CenterVertically(int nextMessageLength)
        {
            PadCeiling(Console.WindowHeight / 2 - ((nextMessageLength / 2) + Screen.GetTopSpacing()));
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
        static string[] PadToCenter(string[] textToCenter)
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
