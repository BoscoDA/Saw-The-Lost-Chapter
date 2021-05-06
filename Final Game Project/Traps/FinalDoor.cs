using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;

namespace Final_Game_Project.Scenes
{
    class FinalDoor : Trap
    {
        public FinalDoor(ConsoleColor color, int deathTime, Game game) : base(color, deathTime, game)
        {

        }

        public override bool AttemptEscape()
        {
            string door1 = @"There seems to be some kind of opening in the wall next to the door,
with Sacrifice written above it. ";
            TextAnimationUtils.AnimateMultiLines(door1, 20, 38, Art_Assets.FinalDoor, Color, 40);
            ConsoleUtils.WaitForKeyPress();
            if (MyGame.MyPlayer.HasHacksaw == true)
            {
                Sacrifice();
                Clear();
                ForegroundColor = Color;
                WriteLine(Art_Assets.FinalDoor);
                ForegroundColor = ConsoleColor.Gray;
                WriteLine(Art_Assets.TextBox);
                ForegroundColor = ConsoleColor.Yellow;
                string door4 = "You put your severed hand in the opening...";
                string door5 = "Click... the lock on the door unlocks and the door slowly slides open! ";
                TextAnimationUtils.AnimateTypingMovable(door4, 20, 38);
                Thread.Sleep(2000);
                TextAnimationUtils.AnimateTypingMovable(door5, 20, 40);
                SetCursorPosition(20, 42);
                ConsoleUtils.WaitForKeyPress();

            }
            else
            {
                Clear();
                ForegroundColor = Color;
                WriteLine(Art_Assets.FinalDoor);
                ForegroundColor = ConsoleColor.Gray;
                WriteLine(Art_Assets.TextBox);
                ForegroundColor = ConsoleColor.Yellow;
                string door3 = "Only through a sacrifce will you seek the salvation you seek.";
                TextAnimationUtils.AnimateTypingMovable(door3, 20, 38);
                SetCursorPosition(20, 40);
                ConsoleUtils.WaitForKeyPress();

            }
            return MyGame.MyPlayer.HasSacrificed;
        }

        private bool Sacrifice()
        {
            string title = $"{Art_Assets.FinalDoor}\nWill you make the ultimate sacrifice in order to reach salvation...";
            string[] options = { "Use Hacksaw", "Exit"};
            Menu mainMenu = new Menu(title, options);
            int selectedIndex = mainMenu.Run(ConsoleColor.Red);

            switch (selectedIndex)
            {
                case 0:
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("\nYou use the hacksaw that you found and vigerously chop off your hand.\n");
                    ResetColor();
                    MyGame.MyPlayer.HasSacrificed = true;
                    ConsoleUtils.WaitForKeyPress();
                    break;
                case 1:
                    AttemptEscape();
                    break;
            }
            return MyGame.MyPlayer.HasSacrificed;
        }
    }
}
