using System;
using Measurement;

namespace _1._4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            var splits = new char[1] { '\n' };
            var testCase = TestCase.Properties.Resources._16Kints.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            var testArray = new int[testCase.Length + 2];
            // 样例第一个和最后一个相等
            testArray[0] = 1;
            testArray[testCase.Length + 1] = 1;
            for (var i = 1; i <= testCase.Length; i++)
            {
                testArray[i] = int.Parse(testCase[i - 1]);
            }

            var timer = new Stopwatch();
            Console.WriteLine($"Count:{CountEqual(testArray)}");
            Console.WriteLine($"Time:{timer.ElapsedTime()} seconds");
            timer = new Stopwatch();
            Console.WriteLine($"Count:{CountEqualLog(testArray)}");
            Console.WriteLine($"Time:{timer.ElapsedTime()} seconds");
        }

        /// <summary>
        /// 暴力查找数组中相等的整数对。
        /// </summary>
        /// <param name="a">需要查找的数组。</param>
        /// <returns></returns>
        static int CountEqual(int[] a)
        {
            var n = a.Length;
            var count = 0;
            for (var i = 0; i < n; i++)
            {
                for (var j = i + 1; j < n; j++)
                {
                    if (a[i] == a[j])
                        count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 利用 Array.Sort 进行优化的查找相等整数对算法。
        /// </summary>
        /// <param name="a">需要查找的数组。</param>
        /// <returns></returns>
        static int CountEqualLog(int[] a)
        {
            var n = a.Length;
            var count = 0;
            Array.Sort(a);
            var dup = 0; // dup = 重复元素数量-1
            for (var i = 1; i < n; i++)
            {
                while (a[i - 1] == a[i])
                {
                    dup++;
                    i++;
                }
                count += dup * (dup + 1) / 2;
                dup = 0;
            }
            return count;
        }
    }
}
