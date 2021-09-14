using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;

namespace TextAdventureTwo
{
    public static class GameManager
    {
       
        public static void StartApplication()
        {
            // Print the first opening message and wait for input to continue.
            Screen.ClearThenPrint(Messages.Main["Opening"]);
            // Set a checkpoint to return to.
            Screen.SetCheckpoint();
            Console.ReadKey();

            int entry = Screen.ClearThenPrintOptionList(Messages.Main["ClearThenPrintOptionList"]);
            Screen.ReprintWith(new string[] { "", $"You clicked {entry}", "" });
            Console.ReadKey();

            var temp = Screen.GetTempCheckpoint();
            bool cont = false;
            while(!cont)
            {
                cont = Screen.ReprintWithYesNoQ("Are you ready to reset to the checkpoint?");
                if (!cont)
                {
                    Screen.ReprintWith("Then we will ask you again....");
                    Screen.ClearThenPrint(temp);
                }

            }
            Screen.ResetToCheckpoint();

            Screen.ReprintWith("Now we called ResetToCheckpoint, so the Opening message has returned!");
            Console.ReadKey();

            Screen.ClearThenPrint("That's the end of my testing for now!");
            Console.ReadKey();


        }



    }
}
