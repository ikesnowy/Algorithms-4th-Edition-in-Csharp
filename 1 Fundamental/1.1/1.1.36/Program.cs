using System;

namespace _1._1._36
{
    class Program
    {
        static void Main(string[] args)
        {
            int M = 10;     // 数组大小
            int N = 1000;   // 打乱次数
            int[] a = new int[10];

            int[,] result = new int[M, M];

            for (int i = 0; i < N; i++)
            {
                // 初始化
                for (int j = 0; j < a.Length; j++)
                {
                    a[j] = j;
                }

                // 打乱
                Shuffle(a, i);

                // 记录
                for (int j = 0; j < M; j++)
                {
                    result[a[j], j]++;
                }
            }

            PrintMatrix(result);
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <param name="a">需要打乱的数组。</param>
        /// <param name="seed">用于生成随机数的种子值。</param>
        static void Shuffle(int[] a, int seed)
        {
            int N = a.Length;
            Random random = new Random(seed);
            for (int i = 0; i < N; i++)
            {
                int r = i + random.Next(N - i);// 等于StdRandom.uniform(N-i)
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }

        /// <summary>
        /// 在控制台上输出矩阵。
        /// </summary>
        /// <param name="a">需要输出的矩阵。</param>
        public static void PrintMatrix(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"\t{a[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}