using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;
using Pastel;
using Figgle;
using Final_Game_Project;

namespace Final_Game_Project.Maze
{
    class GameMaze
    {
        private World MyWorld;
        private MazePlayer CurrentPlayer;
        private bool FirstTime;

        public void Start(string filename)
        {
            string[,] grid = LevelParser.ParseFileToArray(filename);

            MyWorld = new World(grid);
            CursorVisible = false;

            CurrentPlayer = new MazePlayer(44, 30);

            FirstTime = true;

            RunGameLoop();
        }

        private void DisplayIntro()
        {
            if (FirstTime == true)
            {
                WriteLine("\nInstructions");
                WriteLine("> Use the arrow kets to move");
                WriteLine("> Reach an organ, which looks like this: ");
                ResetColor();
                Write("  > Heart: ");
                WriteLine("H".Pastel("#bb33ff"));
                Write("  > Intestine: ");
                WriteLine("I".Pastel("#e6e600"));
                Write("  > Pancreas: ");
                WriteLine("P".Pastel("#ff6600"));
                Write("  > Stomach: ");
                WriteLine("S".Pastel("#66ff99"));
                Write("  > Kidney: ");
                WriteLine("K".Pastel("#0099ff"));
                ForegroundColor = ConsoleColor.Yellow;
                WriteLine("\n> Press any key to start");
                FirstTime = false;
                ReadKey(true);
            }
        }

        private void DrawFrame()
        {
            Clear();
            MyWorld.Draw();
            CurrentPlayer.Draw();
        }

        private void HandlePlayerInput()
        {
            ConsoleKey key;
            do
            {
                ConsoleKeyInfo keyInfo = ReadKey(true);
                key = keyInfo.Key;

            } while (KeyAvailable);


            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y - 1))
                    {
                        CurrentPlayer.Y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X, CurrentPlayer.Y + 1))
                    {
                        CurrentPlayer.Y += 1;

                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X - 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X -= 1;

                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (MyWorld.IsPositionWalkable(CurrentPlayer.X + 1, CurrentPlayer.Y))
                    {
                        CurrentPlayer.X += 1;

                    }
                    break;
            }
        }

        private void RunGameLoop()
        {
            DisplayIntro();

            while (true)
            {
                DrawFrame();

                HandlePlayerInput();

                string elementAtPlayerPos = MyWorld.GetElementAt(CurrentPlayer.X, CurrentPlayer.Y);
                if (elementAtPlayerPos == "S")
                {
                    SetCursorPosition(0, 33);
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("\nYou cut in the stomach and in the intestine track find a key...");
                    ReadKey();
                    break;
                }
                else if (elementAtPlayerPos == "I")
                {
                    SetCursorPosition(0, 33);
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nThere was nothing there... You continue to search the organs.");
                    ConsoleUtils.WaitForKeyPress();
                }
                else if (elementAtPlayerPos == "H")
                {
                    SetCursorPosition(0, 33);
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nThere was nothing there... You continue to search the organs.");
                    ConsoleUtils.WaitForKeyPress();
                }
                else if (elementAtPlayerPos == "P")
                {
                    SetCursorPosition(0, 33);
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nThere was nothing there... You continue to search the organs.");
                    ConsoleUtils.WaitForKeyPress();
                }
                else if (elementAtPlayerPos == "K")
                {
                    SetCursorPosition(0, 33);
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nThere was nothing there... You continue to search the organs.");
                    ConsoleUtils.WaitForKeyPress();
                }

                Thread.Sleep(20);

            }
        }
    }
}
