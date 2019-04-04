using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._32
{
    /*
     * 3.1.32
     * 
     * 练习。
     * 编写一段练习程序，
     * 用困难或者极端但在实际应用中可能出现的情况来测试我们的有序符号表 API。
     * 一些简单的例子包括有序的键列、逆序的键列、所有键全部相同或者只含有两种不同的值。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = 100000;

            Console.WriteLine("n=" + n);
            SequentialSearchST<string, int>[] sst = new SequentialSearchST<string, int>[4]; 
            BinarySearchST<string, int>[] bst = new BinarySearchST<string, int>[4];
            for (int i = 0; i < 4; i++)
            {
                bst[i] = new BinarySearchST<string, int>();
                sst[i] = new SequentialSearchST<string, int>();
            }
            Console.WriteLine("BinarySearch");
            Test(bst, n);
            Console.WriteLine();
            Console.WriteLine("SequentialSearch");
            Test(sst, n);
        }

        static void Test(IST<string, int>[] sts, int n)
        {
            Stopwatch sw = new Stopwatch();
            string[] data = SearchCompare.GetRandomArrayString(n, 3, 10);
            string item1 = "item1";
            Array.Sort(data);

            // 有序的数组
            Console.Write("Sorted Array: ");
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                sts[0].Put(data[i], i);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // 逆序的数组
            Console.Write("Sorted Array Reversed: ");
            sw.Restart();
            for (int i = n - 1; i >= 0; i--)
            {
                sts[1].Put(data[i], i);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // 只有一种键
            Console.Write("One Distinct Key: ");
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                sts[2].Put(item1, i);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            // 只有两种值
            Console.Write("Two Distinct Values: ");
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                sts[3].Put(data[i], i % 2);
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
