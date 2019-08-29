using System;
using System.IO;
using System.Threading;
using System.Buffers;
using System.Collections.Generic;

namespace Gallag
{
    public class ScreenBuffer
    {
        private List<(int x, int y, char c)> ScreensTuple = new List<(int x, int y, char c)>();


        public void Push(int x, int y, char char_p)
        {
            ScreensTuple.Add((x,y,char_p));
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

