using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TextAdventureTwo
{
    static class Messages
    {

        public static Dictionary<string, string[]> General = new Dictionary<string, string[]>
        { 
            { "Logo", new string[] 
            {
            "   .-.                       .-.                           ",
            "  (_) )-.              .'   (_) )-.             .-.        ",
            "    .:   \\   .-.  .-..'       .:   \\  .-.       `-' . ,';. ",
            "   .::.   ).;.-' :   ;       .::.   );   :     ;'   ;;  ;; ",
            " .-:. `:-'  `:::'`:::'`.   .-:. `:-' `:::'-'_.;:._.';  ;;  ",
            "(_/     `:._.             (_/     `:._.            ;    `. ", ""
            } },

            { "Opening", new string[]
            {
                "","Welcome to my Text Adventure Game!", "", "Created by Daniel Aguirre.", "Press any key to continue"
            } }


        };


        public static Dictionary<string, string[]> TestingMessages = new Dictionary<string, string[]>
        {
            {"Opening", new string[] {
                "This is the first message for the Screen.", "",
                "This was created with Screen.ClearThenPrint().","",
                "My next message will erase this one.",
                "But we will return it later using a checkpoint.", ""
            } },

            {"ClearThenPrintOptionList", new string[] {
            "Now we have deleted the screen before this message.",           
            "The method that printed this screen is ClearThenPrintOptionList.", "",
            "This method will continue to print this screen until you pass a valid option.",
            "",
            "1) Option One",
            "2) Option Two ",
            "3) Option Three ",
            "4) Option Four",
            "5) Option Five",
            "", "Invalid Entries Not Allowed."} },


            {"TestingClearThenConfirmInput", new string[] {
                "This is asking for my input", "", "Then it will confirm it with a yes/no added."} },
        };



    }
}
