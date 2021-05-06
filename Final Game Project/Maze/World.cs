using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.Threading;
using Pastel;
using Figgle;

namespace Final_Game_Project.Maze
{
    class World
    {
        private string[,] Grid;
        private int Rows;
        private int Cols;

        public World(string[,] grid)
        {
            Grid = grid;
            Rows = Grid.GetLength(0);
            Cols = Grid.GetLength(1);
        }

        public void Draw()
        {
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Cols; x++)
                {
                    string element = Grid[y, x];
                    SetCursorPosition(x, y);

                    string bgColorHex;
                    if (y % 2 == 0)
                    {
                        bgColorHex = x % 2 == 0 ? "#12070f" : "#070306";
                    }
                    else
                    {
                        bgColorHex = x % 2 == 0 ? "#070306" : "#12070f";
                    }
                    string fgColorHex = element == "X" ? "6bff93" : "e3bad5";
                    if (element == "S")
                    {
                        fgColorHex = "#66ff99";
                    }
                    else if (element == "I")
                    {
                        fgColorHex = "#e6e600";
                    }
                    else if (element == "H")
                    {
                        fgColorHex = "#bb33ff";
                    }
                    else if (element == "P")
                    {
                        fgColorHex = "#ff6600";
                    }
                    else if (element == "K")
                    {
                        fgColorHex = "#0099ff";
                    }
                    else
                    {
                        fgColorHex = "e3bad5";
                    }

                    Write(element.Pastel(fgColorHex).PastelBg(bgColorHex));
                }
            }
        }

        public string GetElementAt(int x, int y)
        {
            return Grid[y, x];
        }

        public bool IsPositionWalkable(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Cols || y >= Rows)
            {
                return false;
            }
            return Grid[y, x] == " " || Grid[y, x] == "H" || Grid[y,x] == "I" || Grid[y, x] == "P" || Grid[y, x] == "S" || Grid[y, x] == "K";
        }
    }
}
