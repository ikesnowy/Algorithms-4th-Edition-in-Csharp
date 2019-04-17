using System;
using System.Diagnostics;

namespace _1._1._19
{
    class Fibnacci
    {
        // long 类型不够大，换成 UINT64 类型
        // 用于保存计算结果的数组，UInt64? 代表可以赋值为普通 UInt64 类型的值以及 null 值
        private static UInt64?[] fibnacciResults = new UInt64?[100];

        static void Main(string[] args)
        {
            /*
             * 测试环境
             * 
             * Surface Pro3 i7
             * i7 4650U + 8G
             * 
             */
            Stopwatch timer = Stopwatch.StartNew();
            for (int N = 0; N < 100; N++)
            {
                // 书本中的代码，非常慢，1小时后 N = 50
                // Console.WriteLine($"{N} {F(N)}");

                // 利用已知结果加速
                // 全部计算完毕耗时 84ms
                Console.WriteLine($"{N} {BetterF(N)}");
            }
            Console.WriteLine($"{timer.ElapsedMilliseconds} ms");
        }

        // 书中提供的代码
        public static UInt64 F(int N)
        {
            if (N == 0)
                return 0;
            if (N == 1)
                return 1;

            return F(N - 1) + F(N - 2);
        }

        // 更好的实现，将已经计算的结果保存，不必重复计算
        public static UInt64? BetterF(int N)
        {
            if (N == 0)
                return 0;
            if (N == 1)
                return 1;

            if (fibnacciResults[N] != null)     // 如果已经计算过则直接读取已知值
            {
                return fibnacciResults[N];
            }
            else
            {
                fibnacciResults[N] = BetterF(N - 1) + BetterF(N - 2);
                return fibnacciResults[N];
            }
        }
    }
}