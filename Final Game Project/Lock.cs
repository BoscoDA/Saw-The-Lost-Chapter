using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project
{
    class Lock
    {
        private string Code;
        private ConsoleColor Color;

        public Lock(string code, ConsoleColor color)
        {
            Code = code;
            Color = color;
        }

        public bool AttemptEscape()
        {
            Clear();
            ConsoleColor prevColor = ForegroundColor;
            ForegroundColor = Color;
            WriteLine("It's locked and needs a code...");
            Write("Please end a code: ");
            string playerGuess = ReadLine().ToLower().Trim();
            if (playerGuess == Code)
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nClick... the lock unlocks.\n");
                ResetColor();

            }
            else
            {
                ForegroundColor = ConsoleColor.Green;
                WriteLine("\nNothing happened... guess the code was wrong.\n");
                ResetColor();
            }

            ConsoleUtils.WaitForKeyPress();
            ForegroundColor = prevColor;
            return playerGuess == Code;
        }
    }
}
