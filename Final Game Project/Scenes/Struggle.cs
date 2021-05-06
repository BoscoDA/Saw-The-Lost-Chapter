using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project.Scenes
{
    class Struggle : Scene
    {
        Random myRand;
        public int Luck { get; set; }

        public Struggle(Game game) : base(game)
        {
            
        }

        public override void Run()
        {
            myRand = new Random();
                string strugglePrompt = "Escape your restraints";
                string[] struggleOptions = { "Struggle", "Give Up" };
                Menu struggleMenu = new Menu(strugglePrompt, struggleOptions);
                int struggleSelectedIndex = struggleMenu.Run();

            switch (struggleSelectedIndex)
            {
                case 0:
                    Luck = myRand.Next(1, 101);
                    if (Luck <= 10)
                    {
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine("\nYou break your restraints!\n");
                        ResetColor();
                        ConsoleUtils.WaitForKeyPress();
                        MyGame.MyChoice2.Run();
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("\nYour restraints loosen some, but don't come off.\n");
                        ResetColor();
                        ConsoleUtils.WaitForKeyPress();
                        Run();
                    }
                    break;
                case 1:
                    MyGame.MyDeath.Run();
                    break;
            }
        }
    }
}
