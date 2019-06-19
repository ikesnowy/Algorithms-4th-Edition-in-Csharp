using System;

namespace _1._1._17
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{exR2(6)}");// 抛出 StackOverflow Exception
        }

        public static string exR2(int n)
        {
            var s = exR2(n - 3) + n + exR2(n - 2) + n;// 运行到 exR2 即展开，不会再运行下一句
            if (n <= 0) return "";
            return s;
        }
    }
}