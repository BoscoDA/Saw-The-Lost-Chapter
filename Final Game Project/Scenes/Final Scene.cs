using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project.Scenes
{
    class Final_Scene : Scene
    {
        public Final_Scene(Game game): base(game)
        {

        }

        public override void Run()
        {
            if(MyGame.MyPlayer.HasTourniquet == true)
            {
                string endingText = @"After the door swings open you put the tournauiet on in order to stop yourself
from bleeding out. ";
                TextAnimationUtils.AnimateMultiLines(endingText, 20, 38, Art_Assets.FinalHallway, ConsoleColor.Green, 40);
                ConsoleUtils.WaitForKeyPress();

                string endingText2 = @"Congradulations, you have escaped.
And have been born a new. More grateful for the life that you hold.";
                TextAnimationUtils.AnimateMultiLines(endingText2, 20, 37, Art_Assets.BillyTV, ConsoleColor.Red, 40);
                SetCursorPosition(20, 41);
                ConsoleUtils.WaitForKeyPress();
                MyGame.MyCredits.Run();
            }
            else
            {
                string endingText3 = @"As you stumble out the door and through the rest of the complex you faint
due to blood lose and bleed out. ";
                TextAnimationUtils.AnimateMultiLines(endingText3, 20, 38, Art_Assets.FinalHallway, ConsoleColor.Green, 40);
                ConsoleUtils.WaitForKeyPress();

                string endingText4 = @"Salvation was yours, but your rashness and impatience cost you your
life. Game Over! ";
                TextAnimationUtils.AnimateMultiLines(endingText4, 20, 37, Art_Assets.BillyTV, ConsoleColor.Red, 40);
                ConsoleUtils.WaitForKeyPress();
                MyGame.MyCredits.Run();
            }
        }
    }
}
