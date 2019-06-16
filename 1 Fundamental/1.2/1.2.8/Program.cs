using System;
using System.IO;

namespace _1._2._8
{
    class Program
    {
        static void Main(string[] args)
        {
            // 读取 largeW.txt
            string[] allNums = File.ReadAllLines("largeW.txt");
            int N = allNums.Length;
            int[] a = new int[N];
            int[] b = new int[N];

            // 数组 a 与数组 b 数字顺序相反
            for (int i = 0; i < N; i++)
            {
                a[i] = int.Parse(allNums[i]);
                b[N - i - 1] = a[i];
            }

            // 输出前5个数字
            Console.WriteLine("Before Swap");
            Console.Write("a:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($" {a[i]}");
            }
            Console.WriteLine();
            Console.Write("b:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($" {b[i]}");
            }
            Console.WriteLine();

            // 交换
            int[] t = a;
            a = b;
            b = t;

            // 再次输出
            Console.WriteLine("After Swap");
            Console.Write("a:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($" {a[i]}");
            }
            Console.WriteLine();
            Console.Write("b:");
            for (int i = 0; i < 5; i++)
            {
                Console.Write($" {b[i]}");
            }
            Console.WriteLine();
        }
    }
}