using System;
using static System.Console;

namespace Final_Game_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Title = "Saw: The Lost Chapter";
            CursorVisible = false;
            int Height = 50;
            int Width = 170;

            try
            {
                SetWindowSize(Width, Height);
            }
            catch
            {
                WriteLine("Cannot create a big enough console window.");
                WriteLine("Try adjusting your font/console settings and restarting.");
                WriteLine("You can continue playing, just be aware that some art might not render properly!");
                ConsoleUtils.WaitForKeyPress();
            }
            Game mygame = new Game();
            mygame.Start();
        }
    }
}
