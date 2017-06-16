using System;

namespace _1._1._37
{
    /*
     * 1.1.37
     * 
     * 糟糕的打乱。
     * 假设在我们的乱序代码中你选择的是一个 0 到 N - 1 而非 i 到 N - 1 之间的随机整数。
     * 证明得到的结果并非均匀地分布在 N! 种可能性之间。
     * 用上一题中的测试检验这个版本。
     * 
     */
    class Program
    {
        //使用 0~N-1 的随机数会导致每次交换的数字可能相同
        //例如：
        //原数组： 1 2 3 4
        //第一次： 2 1 3 4 random = 1，第 0 个和第 1 个交换
        //第二次： 1 2 3 4 random = 0，第 1 个和第 0 个交换
        static void Main(string[] args)
        {
            int M = 10;//数组大小
            int N = 100000;//打乱次数
            int[] a = new int[10];

            int[,] result = new int[M, M];

            for (int i = 0; i < N; ++i)
            {
                //初始化
                for (int j = 0; j < a.Length; ++j)
                {
                    a[j] = j;
                }

                //打乱
                Shuffle(a, i);

                //记录
                for (int j = 0; j < M; ++j)
                {
                    result[a[j], j]++;
                }
            }

            PrintMatrix(result);
        }

        /// <summary>
        /// 打乱数组（不够好的版本）。
        /// </summary>
        /// <param name="a">需要打乱的数组。</param>
        /// <param name="seed">用于生成随机数的种子值。</param>
        static void Shuffle(int[] a, int seed)
        {
            int N = a.Length;
            Random random = new Random(seed);
            for (int i = 0; i < N; ++i)
            {
                //int r = i + random.Next(N - i);
                int r = random.Next(N); //返回的是 0 ~ N-1 之间的随机整数
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
            for (int i = 0; i < a.GetLength(0); ++i)
            {
                for (int j = 0; j < a.GetLength(1); ++j)
                {
                    Console.Write($"\t{a[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}