using System;

namespace _1._1._26
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 2;
            int c = 1;
            int t = 0;

            if (a > b) { t = a; a = b; b = t; } // 如果 a > b，那么 a, b 交换，保证b >= a
            if (a > c) { t = a; a = c; c = t; } // 如果 b >= a > c，那么 a, c 交换，保证 c >= a
            if (b > c) { t = b; b = c; c = t; } // 如果 b > c >= a，那么 b, c 交换，保证 c >= b
            Console.WriteLine($"{a} {b} {c}");  // 最终结果为 c >= b >= a，保证升序排列
        }
    }
}