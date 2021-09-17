using System;
using System.Collections.Generic;
using System.Text;
using TextAdventureTwo.GamePlayer;

namespace TextAdventureTwo
{
    public static class GameManager
    {
        static Player User { get; set; }


        public static void StartGame()
        {
            Prompter.StartingScreen();
            User = new Player();


        }



    }  
}
