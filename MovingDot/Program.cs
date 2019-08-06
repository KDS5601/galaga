using System;
using System.Threading;

namespace Gallag
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.CursorVisible = false;
            Dot dot = new Dot();

            while (true)
            {
                Draw();

                Thread InputThread = new Thread(dot.Move);
                InputThread.IsBackground = true;
                InputThread.Start();

                Thread.Sleep(30);
            }

            void Draw()
            {
                Console.Clear();
                Console.SetCursorPosition(dot.Position.X, dot.Position.Y);
                Console.Write(dot.Shape);
            }
        }
    }

    class Dot
    {
        public (int X, int Y) Position;

        public string Shape = "■";

        public Dot()
        {
            Position.X = 0;
            Position.Y = 0;
        }

        public void Move()
        {
            ConsoleKeyInfo keys = Console.ReadKey(true);

            if (keys.Key == ConsoleKey.RightArrow)
                Position.X++;
            else if (keys.Key == ConsoleKey.LeftArrow)
                Position.X--;
            else if (keys.Key == ConsoleKey.UpArrow)
                Position.Y--;
            else if (keys.Key == ConsoleKey.DownArrow)
                Position.Y++;
        }
    }
}
