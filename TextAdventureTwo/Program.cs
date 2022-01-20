using System;
using System.Drawing;
using System.Threading;

namespace TextAdventureTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(150, 80);                               
            GameManager.StartGame();
        }

    }
}
