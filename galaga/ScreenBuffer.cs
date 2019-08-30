using System;
using System.IO;
using System.Threading;
using System.Buffers;
using System.Collections.Generic;

namespace Gallag
{
    public class ScreenBuffer1
    {
        private char[,] ScreenArry;

        public ScreenBuffer1(int Height, int Width)
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
                    Console.SetCursorPosition(j, i);
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

    public class ScreenBuffer2
    {

        private List<(int x, int y, char c)> ScreensTuple = new List<(int x, int y, char c)>();


        public void Push(int x, int y, char char_p)
        {
            ScreensTuple.Add((x, y, char_p));
        }

        public void Paint()
        {
            Console.Clear();

            foreach ((int x, int y, char c) screensTuple in ScreensTuple)
            {
                Console.SetCursorPosition(screensTuple.x, screensTuple.y);
                Console.Write(screensTuple.c);
            }

            ScreensTuple.Clear();
        }

    }

    public class ScreenBuffer3
    {
        private char[,] ScreenArry;

        public ScreenBuffer3(int Height, int Width)
        {
            ScreenArry = new char[Height, Width];
        }

        public async void Paint()
        {
            Console.Clear();

            for (int i = 0; i < ScreenArry.GetLength(0); i++)
            {
                for (int j = 0; j < ScreenArry.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
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

    public class ScreenBuffer
    {
        private List<(int x, int y, char c)> ScreensTuple = new List<(int x, int y, char c)>();


        public void Push(int x, int y, char char_p)
        {
            ScreensTuple.Add((x, y, char_p));
        }

        public void Paint()
        {
            Console.Clear();

            foreach ((int x, int y, char c) screensTuple in ScreensTuple)
            {
                Console.SetCursorPosition(screensTuple.x, screensTuple.y);
                Console.Write(screensTuple.c);
            }

            ScreensTuple.Clear();
        }
    }
}

