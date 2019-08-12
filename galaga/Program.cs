using System;
using System.IO;
using System.Threading;
using System.Buffers;

namespace Gallag
{
    class Program
    {
        static public int roomWidth = 40;
        static public int roomHeight = 30;

        static void Main(string[] args)
        {
            Console.SetWindowSize(roomWidth, roomHeight);
            Console.SetBufferSize(roomWidth, roomHeight);
            Console.CursorVisible = false;

            Player player = new Player();

            Thread InputThread = new Thread(player.KeyInput);
            InputThread.Start();
            InputThread.IsBackground = true;

            while (true)
            {
                Console.Clear();

                Draw();

                Thread.Sleep(20);
            }

            void Draw()
            {
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

    class Monster : Dot
    {
        public Monster ()
        {
            Shape = "★";
            Position.X = 0;
            Position.Y = 0;
        }

        public void RanMoving()
        {
            Random rn = new Random();
            int i = rn.Next(0, 5);

            if (i == 1)
                Moving(Movement.Down);
            else if (i == 2)
                Moving(Movement.Left);
            else if (i == 3)
                Moving(Movement.Right);
            else if (i == 4)
                Moving(Movement.Up);
        }
    }

    class Bullet : Dot
    {
        public Bullet (ref Player player_r)
        {
            Shape = "·";
            Position = player_r.GetPostion();
        }

        public void Shooting ()
        {
            for (; ; )
            {
                Moving(Movement.Up);
                
                if (Position.Y == 0)
                    break;
            }
        }
    }
}
