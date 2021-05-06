using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project.Scenes
{
    class You_Died : Scene
    {
        public You_Died(Game game) : base(game)
        {

        }

        public override void Run()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine(Art_Assets.BillyTV);
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(Art_Assets.TextBox);
            ForegroundColor = ConsoleColor.Yellow;
            TextAnimationUtils.AnimateTypingMovable("You ran out of time. Game Over! ", 20, 38, 50);
            ConsoleUtils.WaitForKeyPress();

            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine(Art_Assets.GameOverImage);
            WriteLine($"{Art_Assets.GameOverText}\n");
            ConsoleUtils.ExitConsole();

        }
    }
}
