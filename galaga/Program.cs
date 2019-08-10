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

            Thread InputThread = new Thread(player.KeyInput);
            InputThread.Start();
            InputThread.IsBackground = true;

            while (true)
            {
                Draw();

                Thread.Sleep(30);
            }

            void Draw()
            {
                Console.Clear();

                (int x, int y) postion = player.GetPostion();
                Console.SetCursorPosition(postion.x , postion.y);
                Console.Write(player.GetShape());
            }
        }
    }

    abstract class Dot
    {
        protected enum Movement { Up, Down, Left, Right}

        protected (int X, int Y) Position;
        protected string Shape;

        public (int x, int y) GetPostion ()
        {
            return Position;
        }

        public string GetShape()
        {
            return Shape;
        }

        protected void Moving (Movement movement)
        {
            if (movement == Movement.Right)
                Position.X++;
            else if (movement == Movement.Left && Position.X > 0)
                Position.X--;
            else if (movement == Movement.Up && Position.Y > 0)
                Position.Y--;
            else if (movement == Movement.Down)
                Position.Y++;
        }
    }

    class Player : Dot
    {
        public Player()
        {
            Shape = "-ㅅ-";
            Position.X = 0;
            Position.Y = 0;
        }

        public void KeyInput()
        {
            for (; ; )
            {
                ConsoleKeyInfo keys = Console.ReadKey(true);

                if (keys.Key == ConsoleKey.RightArrow)
                    Moving(Movement.Right);
                else if (keys.Key == ConsoleKey.LeftArrow)
                    Moving(Movement.Left);
                else if (keys.Key == ConsoleKey.UpArrow)
                    Moving(Movement.Up);
                else if (keys.Key == ConsoleKey.DownArrow)
                    Moving(Movement.Down);
            }
        }
    }
}
