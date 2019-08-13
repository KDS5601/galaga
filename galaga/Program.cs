using System;
using System.IO;
using System.Threading;
using System.Buffers;
using System.Collections.Generic;

namespace Gallag
{
    static class Program
    {
        static public int FrameTime = 20;
        static public int rootWidth = 40;
        static public int rootHeight = 30;

        static List<Bullet> bulletList;
        static List<Monster> monsterList;

        static void Main(string[] args)
        {
            Console.SetWindowSize(rootWidth, rootHeight);
            Console.SetBufferSize(rootWidth, rootHeight);
            Console.CursorVisible = false;

            Player player = new Player();
            bulletList = new List<Bullet>();
            monsterList = new List<Monster>();


            Thread InputThread = new Thread(player.KeyInput);
            InputThread.Start();
            InputThread.IsBackground = false;

            while (true)
            {
                Console.Clear();

                Drawing();

                Thread.Sleep(FrameTime);
            }

            void Drawing()
            {
                (int x, int y) postion = player.GetPostion();
                Console.SetCursorPosition(postion.x, postion.y);
                Console.Write(player.GetShape());

                foreach (Monster monster in monsterList)
                {
                    postion = monster.GetPostion();
                    Console.SetCursorPosition(postion.x, postion.y);
                    Console.Write(monster.GetShape());
                }

                List<Bullet> toRemove = new List<Bullet>();
                for (int i = 0; i < bulletList.Count; i++)
                {
                    postion = bulletList[i].GetPostion();
                    Console.SetCursorPosition(postion.x, postion.y);
                    Console.Write(bulletList[i].GetShape());

                    //총알 삭제용 --> 코드 위치 이전예정
                    if (bulletList[i].GetPostion().y == 0)
                        toRemove.Add(bulletList[i]);
                }
                bulletList.RemoveAll(toRemove.Contains);

                GC.Collect();                
            }
        }


        abstract class Dot
        {
            protected enum Movement { Up, Down, Left, Right }

            protected (int X, int Y) Position;
            protected string Shape;

            public (int x, int y) GetPostion()
            {
                return Position;
            }

            public string GetShape()
            {
                return Shape;
            }

            protected void Moving(Movement movement)
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
                Position.X = rootWidth / 2;
                Position.Y = 2 * rootHeight / 3;
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
                    else if (keys.Key == ConsoleKey.Spacebar)
                        bulletList.Add(new Bullet(this.Position));
                }
            }
        }

        class Monster : Dot
        {
            public Monster()
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
            public Bullet((int X, int Y) position_r)
            {
                Shape = "·";
                Position.X = position_r.X + 1;
                Position.Y = position_r.Y;

                Thread shootingTr = new Thread(Moving);
                shootingTr.Start();
                shootingTr.IsBackground = false;
            }

            public void Moving()
            {
                for (; ; )
                {
                    if (--Position.Y == 0)
                        break;

                    Thread.Sleep(Program.FrameTime);
                }
            }
        }
    }
}
