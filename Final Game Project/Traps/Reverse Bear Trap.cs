using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project
{
    class Reverse_Bear_Trap : Trap
    {
        public Reverse_Bear_Trap(ConsoleColor color, int deathTime, Game game): base(color, deathTime, game)
        {
            
        }

        public override bool AttemptEscape()
        {
            ConsoleColor prevColor = ForegroundColor;
            ForegroundColor = Color;
            WriteLine("You feel around the contraption and find a lock...");
            ReadKey(true);
            if (MyGame.MyPlayer.HasKey == true)
            {
                WriteLine("You put the key you found into the lock...");
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nClick... the lock opens!");
                ResetColor();

            }
            else
            {
                WriteLine("\nYou will need to find the key to unlock the device...");
                ResetColor();

            }

            ConsoleUtils.WaitForKeyPress();
            ForegroundColor = prevColor;
            return MyGame.MyPlayer.HasKey;
        }
    }
}
