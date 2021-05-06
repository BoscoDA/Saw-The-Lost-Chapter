using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace Final_Game_Project.Scenes
{
    class Intro : Scene
    {
        public Intro(Game game) : base(game)
        {

        }
        public override void Run()
        {
            GetName();
            
            string introPrompt = $"{Art_Assets.TitleArt}\n\n" + 
                $"Welcome {MyGame.MyPlayer.Name} are you ready to play?";
            string[] introOptions = { "Yes", "No" };
            Menu introMenu = new Menu(introPrompt, introOptions);
            int introSelectedIndex = introMenu.Run(ConsoleColor.Red);

            switch (introSelectedIndex)
            {
                case 0:
                    IntroPlot();
                    MyGame.MyBilly.Run();
                    break;

                case 1:
                    MyGame.MyMainMeneu.Run();
                    break;
            }
            
        }
        private void GetName()
        {
            Clear();
            ForegroundColor = ConsoleColor.Red;
            WriteLine(Art_Assets.TitleArt);
            ResetColor();
            Write("What is your name: ");
            ForegroundColor = ConsoleColor.Red;
            string name = ReadLine().Trim();
            MyGame.MyPlayer.Name = name;
        }
        private void IntroPlot()
        {
            string plotText = @"You wake up in a dimmly lit room. You have a pounding headache and all
you can taste is metal and blood. In your confused haze a TV that is
infront of you turns on...";
            TextAnimationUtils.AnimateMultiLines(plotText, 20, 38, Art_Assets.IntroArt, ConsoleColor.Green, 40);
            Thread.Sleep(2000);
        }
    }
}
