using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Diagnostics;
using System.Threading;

namespace Final_Game_Project
{
    class Trap
    {
        public int DeathTime { get; private set; }
        protected ConsoleColor Color;
        protected Game MyGame;
        public Stopwatch myWatch = new Stopwatch();

        public Trap(ConsoleColor color, int deathTime, Game game)
        {
            DeathTime = deathTime;
            Color = color;
            MyGame = game;
        }

        public void StartTrap()
        {
            myWatch.Reset();
            myWatch.Start();
        }

        public virtual bool AttemptEscape()
        {
            return false;
        }
    }
}
