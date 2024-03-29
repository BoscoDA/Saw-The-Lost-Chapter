﻿using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;
using System.IO;

namespace Final_Game_Project.Maze
{
    class LevelParser
    {
        public static string[,] ParseFileToArray(string filepath)
        {
            string[] lines = File.ReadAllLines(filepath);
            string firstLine = lines[0];
            int rows = lines.Length;
            int cols = firstLine.Length;
            string[,] grid = new string[rows, cols];
            for (int y = 0; y < rows; y++)
            {
                string line = lines[y];
                for (int x = 0; x < cols; x++)
                {

                    char currentChar = line[x];
                    grid[y, x] = currentChar.ToString();
                }
            }
            return grid;
        }
    }
}
