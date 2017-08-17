using System;

namespace _1._1._20
{
    /*
     * 1.1.20
     * 
     * 编写一个递归的静态方法计算 ln(N!) 的值。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int N = 4;
            Console.WriteLine($"{factorialLn(N)}");
        }

        // n(N!) =
        // n(N * (N - 1) * ... * 1) =
        // n(N) + ln((N - 1)!)
        public static double factorialLn(int N)
        {
            if (N == 1)
            {
                return 0;
            }

            return Math.Log(N) + factorialLn(N - 1);
        }
    }
}