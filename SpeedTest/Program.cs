using System;

namespace SpeedTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = new DateTime();

            int[,] testMetrix = new int[1000000,1000000];

            time = DateTime.Now;
            
            for (int i = 0; i < testMetrix.GetLength(0); i++)
                for(int j = 0; j <testMetrix.GetLength(1); j++)
                {
                    testMetrix[i, j] = 0;
                }
            Console.WriteLine("뒷차원 부터 접근 : " + (time - DateTime.Now).ToString());

            Console.ReadKey();
        }
    }
}
