using System;

namespace _1._1._24
{
    
    class Program
    {
        static void Main(string[] args)
        {
            GCD(105, 24);
            Console.WriteLine();
            GCD(111111, 1234567);
        }

        /// <summary>
        /// 返回两个数的最大公约数。
        /// </summary>
        /// <param name="a">第一个数。</param>
        /// <param name="b">第二个数。</param>
        /// <returns></returns>
        public static int GCD(int a, int b)
        {
            Console.WriteLine($"{a} {b}");
            if (b == 0)
            {
                return a;
            }

            return GCD(b, a % b);
        }
    }
}