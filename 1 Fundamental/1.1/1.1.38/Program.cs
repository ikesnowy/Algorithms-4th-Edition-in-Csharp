using System;
using System.Diagnostics;
using System.IO;

namespace _1._1._38
{
    class Program
    {
        static void Main(string[] args)
        {
            var largeWString = File.ReadAllLines("largeW.txt");
            var largeW = new int[largeWString.Length];
            for (var i = 0; i < largeW.Length; i++)
            {
                largeW[i] = int.Parse(largeWString[i]);
            }
            var timer = Stopwatch.StartNew();
            BruteForceSearch(111111, largeW);
            Console.WriteLine($"BruteForceSearch: {timer.ElapsedMilliseconds} ms");

            timer.Restart();
            rank(111111, largeW);
            Console.WriteLine($"BinarySearch: {timer.ElapsedMilliseconds} ms");

            var largeTString = File.ReadAllLines("largeT.txt");
            var largeT = new int[largeTString.Length];
            for (var i = 0; i < largeW.Length; i++)
            {
                largeT[i] = int.Parse(largeTString[i]);
            }

            timer.Restart();
            BruteForceSearch(111111, largeT);
            Console.WriteLine($"BruteForceSearch: {timer.ElapsedMilliseconds} ms");

            timer.Restart();
            rank(111111, largeT);
            Console.WriteLine($"BinarySearch: {timer.ElapsedMilliseconds} ms");
        }

        /// <summary>
        /// 暴力查找算法。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int BruteForceSearch(int key, int[] a)
        {
            for (var i = 0; i < a.Length; i++)
            {
                if (a[i] == key)
                    return i;
            }

            return -1;
        }

        /// <summary>
        /// 二分查找，默认在整个数组范围内查找。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1, 1);
        }

        /// <summary>
        /// 二分查找。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <param name="lo">查找的下界。</param>
        /// <param name="hi">查找的上界。</param>
        /// <param name="number">递归调用的次数。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a, int lo, int hi, int number)
        {
            if (lo > hi)
            {
                return -1;
            }

            var mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1, number + 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi, number + 1);
            }
            else
            {
                return mid;
            }
        }
    }
}
