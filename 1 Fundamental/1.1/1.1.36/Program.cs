using System;

namespace _1._1._36
{
    class Program
    {
        static void Main(string[] args)
        {
            var M = 10;     // 数组大小
            var N = 1000;   // 打乱次数
            var a = new int[10];

            var result = new int[M, M];

            for (var i = 0; i < N; i++)
            {
                // 初始化
                for (var j = 0; j < a.Length; j++)
                {
                    a[j] = j;
                }

                // 打乱
                Shuffle(a, i);

                // 记录
                for (var j = 0; j < M; j++)
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
            var N = a.Length;
            var random = new Random(seed);
            for (var i = 0; i < N; i++)
            {
                var r = i + random.Next(N - i);// 等于StdRandom.uniform(N-i)
                var temp = a[i];
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
            for (var i = 0; i < a.GetLength(0); i++)
            {
                for (var j = 0; j < a.GetLength(1); j++)
                {
                    Console.Write($"\t{a[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}