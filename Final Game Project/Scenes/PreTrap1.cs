using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace Final_Game_Project.Scenes
{
    class PreTrap1 : Scene
    {
       
        public PreTrap1(Game game) : base(game)
        {

        }

        public override void Run()
        {
            string preTrapPrompt = @$"{Art_Assets.IntroArt}
What will you do?";
            string[] preTrapOptions = { "Escape restraints.", "Look around..." };
            Menu preTrapMenu = new Menu(preTrapPrompt, preTrapOptions);
            int preTrapSelectedIndex = preTrapMenu.Run();

            switch (preTrapSelectedIndex)
            {
                case 0:
                    MyGame.MyReverse.StartTrap();
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\n\"Clink\" In your first attempts to get out of your restraints it seems like a pin has been removed from the contraption.\n And you can hear a timer now ticking away.");
                    ReadKey(true);
                    MyGame.MyStruggle.Run();
                    break;
                case 1:
                    Clear();
                    if (MyGame.MyPlayer.HasLookedAround == false)
                    {
                        LookAround();
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Green;
                        WriteLine(Art_Assets.IntroArt);
                        ForegroundColor = ConsoleColor.Gray;
                        WriteLine(Art_Assets.TextBox);
                        ForegroundColor = ConsoleColor.Yellow;
                        string lookAround = "There seems to be nothing new to find...";
                        TextAnimationUtils.AnimateTypingMovable(lookAround, 20, 38, 50);
                        ConsoleUtils.WaitForKeyPress();
                    }
                    MyGame.MyChoice1.Run();
                    break;
            }
        }

        private void LookAround()
        {
            string lookAround = @"In a paniced haze you look around...";
            TextAnimationUtils.AnimateMultiLines(lookAround, 20, 38, Art_Assets.IntroArt, ConsoleColor.Green, 40);
            Thread.Sleep(1000);

            string seeBody = @"There seems to be a body on the floor with a red spiral painted on its
stomach.";
            TextAnimationUtils.AnimateMultiLines(seeBody, 20, 38, Art_Assets.DeadBody, ConsoleColor.Green, 40);
            Thread.Sleep(1000);

            string seeRestraints = @"You notice that the restaints that bind your arms to your chair are made of a
cheap fabric. But they will still take some time to break free of.";
            TextAnimationUtils.AnimateMultiLines(seeRestraints, 20, 38, Art_Assets.Fabric, ConsoleColor.Green, 40);
            Thread.Sleep(1000);

            string seeScalpel = @"The last thing that you notice in the room is a scalpel on a small table next
to you. ";
            TextAnimationUtils.AnimateMultiLines(seeScalpel, 20, 38, Art_Assets.BoxScalpel, ConsoleColor.Green, 40);


            MyGame.MyPlayer.HasLookedAround = true;
            ConsoleUtils.WaitForKeyPress();
        }
    }
}
