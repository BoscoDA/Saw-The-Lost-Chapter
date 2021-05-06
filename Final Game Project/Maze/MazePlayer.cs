using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using Pastel;

namespace Final_Game_Project.Maze
{
    class MazePlayer
    {
        public int X { get; set; }
        public int Y { get; set; }
        private string PlayerMarker;
        private string PlayerColor;

        public MazePlayer(int initialX, int initialY)
        {
            X = initialX;
            Y = initialY;
            PlayerMarker = "O";
            PlayerColor = "#66ff99";

        }

        public void Draw()
        {
            SetCursorPosition(X, Y);
            Write(PlayerMarker.Pastel(PlayerColor));
            ResetColor();
        }
    }
}
