using System;

namespace _1._1._14
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = 9;
            Console.WriteLine($"{ lg(N)}");
        }

        // 利用循环逼近 N，得到 log2(N) 的值
        static int lg(int N)
        {
            var baseNumber = 2;
            var pow = 1;
            var sum = 2;

            for (pow = 1; sum < N; pow++)
            {
                sum *= baseNumber;
            }

            return pow - 1;
        }
    }
}