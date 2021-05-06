using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Threading;

namespace Final_Game_Project
{
    class TextAnimationUtils
    {
        public static void Blink(string text, int blinkCount = 5, int onTime = 500, int offTIme = 200)
        {
            CursorVisible = false;
            for (int i = 0; i < blinkCount; i++)
            {
                WriteLine(text);
                Thread.Sleep(onTime);
                Clear();
                Thread.Sleep(offTIme);
            }
            WriteLine(text);
            CursorVisible = false;
        }

        public static void AnimateTyping(string text, int delay = 25)
        {
            for (int i = 0; i < text.Length; i++)
            {
                
                Write(text[i]);
                Thread.Sleep(delay);

                // Skip the animation if a key pressed.
                if (KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Write(text.Substring(i + 1));
                        break;
                    }
                }
            }
        }
        public static void AnimateTypingMovable(string text, int x, int y, int delay = 25)
        {
            CursorVisible = false;
            for (int i = 0; i < text.Length; i++)
            {
                if(x%100 == 0)
                {
                    SetCursorPosition(x, y);
                    Write(text[i]);
                    Thread.Sleep(delay);
                    x = 5;
                }
                else
                {
                    SetCursorPosition(x, y);
                    Write(text[i]);
                    Thread.Sleep(delay);
                    x++;
                }
                if (KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Write(text.Substring(i + 1));
                        break;
                    }
                }
            }
        }
        public static void AnimateMultiLines(string text, int x, int y, string art, ConsoleColor artColor, int delay)
        {
            string[] lines = text.Split('\n');
            int lineNumber = 1;
            int yStart = y;
            Clear();
            ForegroundColor = artColor;
            WriteLine(art);
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(Art_Assets.TextBox);
            ForegroundColor = ConsoleColor.Yellow;
            foreach (var line in lines)
            {
                AnimateTypingMovable(line, x, y, delay);
                if (lineNumber == 4)
                {
                    Thread.Sleep(1000);
                    Clear();
                    ForegroundColor = artColor;
                    WriteLine(art);
                    ForegroundColor = ConsoleColor.Gray;
                    WriteLine(Art_Assets.TextBox);
                    ForegroundColor = ConsoleColor.Yellow;
                    lineNumber = 1;
                    y = yStart;
                }
                else
                {
                    lineNumber++;
                    y += 2;
                }
            }

        }
    }
}
