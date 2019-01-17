using System;
using Measurement;

namespace _1._4._8
{
    /*
     * 1.4.8
     * 
     * 编写一个程序，计算输入文件中相等的整数对的数量。
     * 如果你的第一个程序是平方级别的，
     * 请继续思考并用 Array.sort() 给出一个线性对数级别的解答。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            char[] splits = new char[1] { '\n' };
            string[] testCase = TestCase.Properties.Resources._16Kints.Split(splits, StringSplitOptions.RemoveEmptyEntries);
            int[] testArray = new int[testCase.Length + 2];
            // 样例第一个和最后一个相等
            testArray[0] = 1;
            testArray[testCase.Length + 1] = 1;
            for (int i = 1; i <= testCase.Length; i++)
            {
                testArray[i] = int.Parse(testCase[i - 1]);
            }

            Stopwatch timer = new Stopwatch();
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
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[i] == a[j])
                        count++;
                }
            }

            return count;
        }

        /// <summary>
        /// 利用二分查找进行优化的查找相等整数对算法。
        /// </summary>
        /// <param name="a">需要查找的数组。</param>
        /// <returns></returns>
        static int CountEqualLog(int[] a)
        {
            int n = a.Length;
            int count = 0;
            Array.Sort(a);
            int dup = 0; // dup = 重复元素数量-1
            for (int i = 1; i < n; i++)
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
