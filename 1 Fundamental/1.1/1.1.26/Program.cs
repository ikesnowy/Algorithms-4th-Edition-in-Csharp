using System;

namespace _1._1._26
{
    /*
     * 1.1.26
     * 
     * 将三个数字排序。
     * 假设 a、b、c 和 t 都是同一种原始数字类型的变量。
     * 证明如下代码能够将 a、b、c 按照升序排列。
     * if (a > b) { t = a; a = b; b = t; }
     * if (a > c) { t = a; a = c; c = t; }
     * if (b > c) { t = b; b = c; c = t; }
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 2;
            int c = 1;
            int t = 0;

            if (a > b) { t = a; a = b; b = t; } // 果 a > b，那么 a, b 交换，保证b >= a
            if (a > c) { t = a; a = c; c = t; } // 果 b >= a > c，那么 a, c 交换，保证 c >= a
            if (b > c) { t = b; b = c; c = t; } // 果 b > c >= a，那么 b, c 交换，保证 c >= b
            Console.WriteLine($"{a} {b} {c}");  // 终结果为 c >= b >= a，保证升序排列
        }
    }
}