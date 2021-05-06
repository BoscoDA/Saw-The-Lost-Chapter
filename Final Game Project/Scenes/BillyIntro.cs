using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project.Scenes
{
    class BillyIntro : Scene
    {
        public BillyIntro(Game game) : base(game)
        {
            CursorVisible = false;
        }
        public override void Run()
        {
            string billyTalk = @$"Hello, {MyGame.MyPlayer.Name}. You don't know me, but... I know you. I want to play a game.
Here's what happens if you lose. The device you're wearing is hooked into
your upper and lower jaws.

When the timer at the back goes off, your mouth will be permanently ripped
open. Think of it like a... reverse bear trap. There is only one key to
open the device.

Will you be able to stomach the truth and find it. Or will this room become
your final resting place. You have two minutes.
Live or die. Make your choice. ";

            TextAnimationUtils.AnimateMultiLines(billyTalk, 20, 37, Art_Assets.BillyTV, ConsoleColor.Red, 50);
            ConsoleUtils.WaitForKeyPress();

            MyGame.MyChoice1.Run();
        }

            
    }
}
