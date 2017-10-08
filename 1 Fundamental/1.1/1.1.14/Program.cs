using System;

namespace _1._1._14
{
    /*
     * 1.1.14
     * 
     * 编写一个静态方法lg()，接受一个整型参数N，返回不大于log2(N)的最大整数。
     * 不要使用 Math 库。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int N = 9;
            Console.WriteLine($"{ lg(N)}");
        }

        // 利用循环逼近 N，得到 log2(N) 的值
        static int lg(int N)
        {
            int baseNumber = 2;
            int pow = 1;
            int sum = 2;

            for (pow = 1; sum < N; ++pow)
            {
                sum *= baseNumber;
            }

            return pow - 1;
        }
    }
}
