using System;

namespace _1._1._27
{
    /*
     * 1.1.27
     * 
     * 二项分布。
     * 估计用以下代码计算 binomial(100, 50, 0.25) 将会产生的递归调用次数：
     * 
     * public static double binomial(int N, int k, double p)
     * {
     *     if (N == 0 && k == 0)    return 1.0;
     *     if (N < 0 || k < 0)    return 0.0;
     *     return (1.0 - p) * binomial(N - 1, k, p) + p * binomial(N - 1, k - 1, p);
     * }
     * 
     * 将已经计算过的值保存在数组中并给出一个更好的实现。
     * 
     */
    class Program
    {
        static int BinomialCalled = 0;  //计算递归调用次数
        static double?[,] BinomialCache;    //保存计算结果的数组

        static void Main(string[] args)
        {
            BinomialCache = new double?[101, 51];
            Console.WriteLine(Binomial(100, 50, 0.25));
            Console.WriteLine(BinomialCalled);
        }

        public static double? Binomial(int N, int k, double p)
        {
            BinomialCalled++;
            if (N == 0 && k == 0)
                return 1.0;
            if (N < 0 || k < 0)
                return 0.0;
            if (BinomialCache[N, k] != null)
            {
                return BinomialCache[N, k];
            }
            else
            {
                BinomialCache[N, k] = (1.0 - p) * Binomial(N - 1, k, p) + p * Binomial(N - 1, k - 1, p);
                return BinomialCache[N, k];
            }
        }
    }
}