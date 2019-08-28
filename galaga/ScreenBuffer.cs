using System;
using System.IO;
using System.Threading;
using System.Buffers;
using System.Collections.Generic;

namespace Gallag
{
    public class ScreenBuffer
    {
        //private struct ScreenStrut { int x; int y; char shape; }

        //private List<ScreenStrut> screenStruts = new List<ScreenStrut>();

        private char[,] ScreenArry;

        public ScreenBuffer(int Height, int Width)
        {
            ScreenArry = new char[Height, Width];
        }

        public void Push(int x, int y, char char_p)
        {
            ScreenArry[y, x] = char_p;
        }

        public void Paint()
        {
            Console.Clear();

            for (int i = 0; i < ScreenArry.GetLength(0); i++)
            {
                for (int j = 0; j < ScreenArry.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j,i);
                    Console.Write(ScreenArry[i, j]);
                }
            }

            for (int i = 0; i < ScreenArry.GetLength(0); i++)
            {
                for (int j = 0; j < ScreenArry.GetLength(1); j++)
                {
                    ScreenArry[i, j] = ' ';
                }
            }
        }
    }
}

