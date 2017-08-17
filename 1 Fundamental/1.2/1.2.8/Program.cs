using System;
using System.IO;

namespace _1._2._8
{
    /*
     * 1.2.8
     * 
     * 设 a[] 和 b[] 均为长数百万的整型数组。以下代码的作用是什么？有效吗？
     * int[] t = a; a = b; b = t;
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 取 largeW.txt
            string[] allNums = File.ReadAllLines("largeW.txt");
            int N = allNums.Length;
            int[] a = new int[N];
            int[] b = new int[N];

            // 组 a 与数组 b 数字顺序相反
            for (int i = 0; i < N; ++i)
            {
                a[i] = int.Parse(allNums[i]);
                b[N - i - 1] = a[i];
            }

            // 出前5个数字
            Console.WriteLine("Before Swap");
            Console.Write("a:");
            for (int i = 0; i < 5; ++i)
            {
                Console.Write($" {a[i]}");
            }
            Console.WriteLine();
            Console.Write("b:");
            for (int i = 0; i < 5; ++i)
            {
                Console.Write($" {b[i]}");
            }
            Console.WriteLine();

            // 换
            int[] t = a;
            a = b;
            b = t;

            // 次输出
            Console.WriteLine("After Swap");
            Console.Write("a:");
            for (int i = 0; i < 5; ++i)
            {
                Console.Write($" {a[i]}");
            }
            Console.WriteLine();
            Console.Write("b:");
            for (int i = 0; i < 5; ++i)
            {
                Console.Write($" {b[i]}");
            }
            Console.WriteLine();
        }
    }
}
