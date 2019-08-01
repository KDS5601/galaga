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
            Player player = new Player();

            while (true)
            {
                Draw();

                Thread InputThread = new Thread(player.KeyInput);
                InputThread.IsBackground = true;
                InputThread.Start();

                Thread.Sleep(30);
            }

            void Draw()
            {
                Console.Clear();
                Console.SetCursorPosition(player.Position.X, player.Position.Y);
                Console.Write(player.Shape);
            }
        }
    }

    class Player
    {
        public (int X, int Y) Position;

        public string Shape = "■";

        public Player()
        {
            Position.X = 0;
            Position.Y = 0;
        }

        public void KeyInput()
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
