using System;

namespace _1._1._20
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = 4;
            Console.WriteLine($"{factorialLn(N)}");
        }

        // ln(N!) =
        // ln(N * (N - 1) * ... * 1) =
        // ln(N) + ln((N - 1)!)
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