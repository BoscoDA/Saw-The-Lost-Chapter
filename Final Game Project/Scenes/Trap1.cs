using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace Final_Game_Project.Scenes
{
    class Trap1 : Scene
    {
        public bool HasEscaped { get; protected set; } = false;
        

        public Trap1(Game game) : base(game)
        {
            
        }

        public override void Run()
        {
            while (HasEscaped != true && MyGame.MyReverse.myWatch.ElapsedMilliseconds <= MyGame.MyReverse.DeathTime)
            {
                if (MyGame.MyPlayer.HasLookedAround == true)
                {
                    ObservantPath();
                }
                else
                {
                    UnobservantPath();
                }

            }
            Clear();
            MyGame.MyReverse.myWatch.Stop();
            if (HasEscaped == true && MyGame.MyReverse.myWatch.ElapsedMilliseconds <= MyGame.MyReverse.DeathTime)
            {
                MyGame.MyChoice3.Run();
            }
            else
            {
                MyGame.MyDeath.Run();
            }
        }
        private void UnobservantPath()
        {
            string unobservantPathPrompt = $"{Art_Assets.IntroArt}\n\nNow that you are up what will you do?";
            string[] unobservantPathOptions = { "Go to the body...", "Look around...", "Remove trap..." };
            Menu unobservantPathChoiceMenu = new Menu(unobservantPathPrompt, unobservantPathOptions);
            int unobservantPathSelectedIndex = unobservantPathChoiceMenu.Run();

            switch (unobservantPathSelectedIndex)
            {
                case 0:
                    string needScalpel = @"You're gonna need something sharp to cut into the body... 
";
                    TextAnimationUtils.AnimateMultiLines(needScalpel, 20, 38, Art_Assets.DeadBody, ConsoleColor.Red, 40);
                    SetCursorPosition(20,40);
                    ConsoleUtils.WaitForKeyPress();
                    MyGame.MyChoice2.Run();
                    break;

                case 1:
                    LookAround();
                    break;
                case 2:
                    bool wasSuccesful = MyGame.MyReverse.AttemptEscape();
                    HasEscaped = wasSuccesful;
                    break;
                default:
                    Clear();
                    break;
            }
        }
        private void ObservantPath()
        {
            string observantPathPrompt = @$"{Art_Assets.IntroArt}
Now that you are up what will you do?";
            string[] observantPathOptions = { "Go to the body", "Get Scalpel", "Remove trap" };
            Menu observantPathChoiceMenu = new Menu(observantPathPrompt, observantPathOptions);
            int observantPathSelectedIndex = observantPathChoiceMenu.Run();

            switch (observantPathSelectedIndex)
            {
                case 0:
                    if (MyGame.MyPlayer.HasScalpel == true)
                    {
                        if (MyGame.MyPlayer.HasKey == false)
                        {
                            string bodyText = @"You go to cut into the body... ";
                            TextAnimationUtils.AnimateMultiLines(bodyText, 20, 38, Art_Assets.DeadBody, ConsoleColor.Green, 50);
                            ConsoleUtils.WaitForKeyPress();
                            Clear();
                            MyGame.MyMaze.Start(@"Maze\Level1.Txt");
                            MyGame.MyPlayer.HasKey = true;
                            MyGame.MyChoice2.Run();
                        }
                        else
                        {
                            ForegroundColor = ConsoleColor.Yellow;
                            string haveKey = @"Looks like you have the key already... 
";
                            TextAnimationUtils.AnimateMultiLines(haveKey, 20, 38, Art_Assets.DeadBody, ConsoleColor.Green, 50);
                            ConsoleUtils.WaitForKeyPress();
                            Clear();
                        }
                        break;
                    }
                    else
                    {
                        string needScalpelText = @"You're gonna need something sharp to cut into the body...
";
                        TextAnimationUtils.AnimateMultiLines(needScalpelText, 20, 38, Art_Assets.DeadBody, ConsoleColor.Red, 50);
                        SetCursorPosition(20, 40);
                        ConsoleUtils.WaitForKeyPress();
                        MyGame.MyChoice2.Run();
                        break;
                    }

                case 1:
                    if (MyGame.MyPlayer.HasScalpel == false)
                    {
                        GetScalpel();
                    }
                    else
                    {
                        string haveScalpel = @"Looks like you already have the scalpel... ";
                        TextAnimationUtils.AnimateMultiLines(haveScalpel, 20, 38, Art_Assets.Box, ConsoleColor.Green, 50);
                        ConsoleUtils.WaitForKeyPress();
                        Clear();
                    }
                    break;
                case 2:
                    bool wasSuccesful = MyGame.MyReverse.AttemptEscape();
                    HasEscaped = wasSuccesful;
                    break;
                default:
                    Clear();
                    break;
            }
        }
        private void GetScalpel()
        {
            if (MyGame.MyPlayer.HasScalpel == false)
            {
                string getScalpelPrompt = $"{Art_Assets.BoxScalpel}\nYou look around..." +
                                "\nThere seems to be a scalpel on a small table next to the chair." +
                                "\nWill you pick it up?\n";
                string[] getScalpelOptions = { "Yes", "No" };
                Menu getScalpelChoiceMenu = new Menu(getScalpelPrompt, getScalpelOptions);
                int getScalpelSelectedIndex = getScalpelChoiceMenu.Run();
                switch (getScalpelSelectedIndex)
                {
                    case 0:
                        MyGame.MyPlayer.HasScalpel = true;
                        MyGame.MyChoice2.Run();
                        break;
                    case 1:
                        MyGame.MyChoice2.Run();
                        break;
                }
            }
            else
            {
                string bodyText4 = @"There doesn't seem like there is anything else here...";
                TextAnimationUtils.AnimateMultiLines(bodyText4, 20, 38, Art_Assets.Box, ConsoleColor.Green, 40);
                ReadKey();
                MyGame.MyChoice2.Run();
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

            string seeScalpel = @"The last thing that you notice in the room is a scalpel on a small table next
to you. ";
            TextAnimationUtils.AnimateMultiLines(seeScalpel, 20, 38, Art_Assets.BoxScalpel, ConsoleColor.Green, 40);


            MyGame.MyPlayer.HasLookedAround = true;
            ConsoleUtils.WaitForKeyPress();
            Run();

        }
    }
}
