using System;

namespace _1._1._30
{
    class Program
    {
        // 互质 = 最大公约数为 1 = gcd(i, j) == 1
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());

            bool[,] a = new bool[N, N];

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    a[i, j] = (gcd(i, j) == 1);
                }
            }

            PrintArray2D(a, N, N);
        }

        /// <summary>
        /// 计算两个数之间的最大公约数。
        /// </summary>
        /// <param name="a">第一个数。</param>
        /// <param name="b">第二个数。</param>
        /// <returns></returns>
        static int gcd(int a, int b)
        {
            if (b == 0)
                return a;

            return gcd(b, a % b);
        }

        private static void PrintArray2D(bool[,] array, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"\t{array[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}