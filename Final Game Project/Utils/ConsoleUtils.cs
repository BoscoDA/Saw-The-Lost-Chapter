using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Final_Game_Project
{
    static class ConsoleUtils
    {
        public static void WaitForKeyPress()
        {
            WriteLine("(Press any key to continue.)");
            ReadKey(true);
        }

        public static void ExitConsole()
        {
            WriteLine("(Press any key to exit)");
            ReadKey(true);
            Environment.Exit(0);
        }


    }
}
