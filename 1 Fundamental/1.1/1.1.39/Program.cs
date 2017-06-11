using System;

namespace _1._1._39
{
    /*
     * 1.1.39
     * 
     * 随机匹配。
     * 编写一个使用 BinarySearch 的程序，
     * 它从命令行接受一个整型参数 T，
     * 并会分别针对 N = 10^3、10^4、10^5 和 10^6 将以下实验运行 T 遍：
     * 生成两个大小为 N 的随机 6 位正整数数组并找出同时存在于两个数组中的整数的数量。
     * 打印一个表格，对于每个 N，给出 T 次实验中该数量的平均值。
     * 
     */
    class Program
    {
        //需要 6 秒左右的运算时间
        static void Main(string[] args)
        {
            Random r = new Random();
            int baseNum = 10;
            int powNum = 3;
            int T = 10;
            int M = 4;

            double[,] Matrix = new double[M,2];

            for (int i = 0; i < M; ++i)
            {
                int N = (int)Math.Pow(baseNum, powNum + i);
                double sum = 0;
                for (int j = 0; j < T; ++j)
                {
                    sum += Test(N, r.Next());
                }
                Matrix[i, 0] = N;
                Matrix[i, 1] = sum / T;
            }

            PrintMatrix(Matrix);
        }

        /// <summary>
        /// 执行一次“实验”
        /// </summary>
        /// <param name="N">数组的大小</param>
        /// <param name="seed">随机种子</param>
        /// <returns>返回相同数字的数目</returns>
        static int Test(int N, int seed)
        {
            Random random = new Random(seed);
            int[] a = new int[N];
            int[] b = new int[N];
            int count = 0;

            for (int i = 0; i < N; ++i)
            {
                a[i] = random.Next(100000, 1000000);
                b[i] = random.Next(100000, 1000000);
            }

            for (int i = 0; i < N; ++i)
            {
                if (rank(a[i], b) != -1)
                    count++;
            }

            return count;
        }

        //重载方法，用于启动二分查找
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1, 1);
        }

        //二分查找
        public static int rank(int key, int[] a, int lo, int hi, int number)
        {
            if (lo > hi)
            {
                return -1;
            }

            int mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1, number + 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi, number + 1);
            }
            else
            {
                return mid;
            }
        }

        /// <summary>
        /// 在控制台上输出矩阵
        /// </summary>
        /// <param name="a">需要输出的矩阵</param>
        public static void PrintMatrix(double[,] a)
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