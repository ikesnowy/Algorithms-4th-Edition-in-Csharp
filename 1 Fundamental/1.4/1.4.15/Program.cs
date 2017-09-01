using System;
using Measurement;

namespace _1._4._15
{
    /*
     * 1.4.15
     * 
     * 快速 3-sum。
     * 作为热身，使用一个线性级别的算法
     * （而非基于二分查找的线性对数级别的算法）
     * 实现 TwoSumFaster 来计算已排序的数组中和为 0 的整数对的数量。
     * 用相同的思想为 3-sum 问题给出一个平方级别的算法。
     * 
     */
    class Program
    {
        // 由于数组已经排序（从小到大），负数在左侧，正数在右侧。
        // TwoSumFaster
        // 设最左侧下标为 lo，最右侧下标为 hi。
        // 如果 a[lo] + a[hi] > 0, 说明正数太大，hi--。
        // 如果 a[lo] + a[hi] < 0，说明负数太小，lo++。
        // 否则就找到了一对和为零的整数对，lo++, hi--。
        //
        // ThreeSumFaster
        // 对于数组中的每一个数 a，ThreeSum 问题就等于求剩余数组中所有和为 -a 的 TwoSum 问题。
        // 只要在 TwoSumFaster 外层再套一个循环即可。
        static void Main(string[] args)
        {
            char[] split = new char[1] { '\n' };
            string[] testCases = TestCase.Properties.Resources._1Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int[] a = new int[testCases.Length];
            for (int i = 0; i < testCases.Length; ++i)
            {
                a[i] = int.Parse(testCases[i]);
            }
            Array.Sort(a);
            Console.WriteLine(TwoSum.Count(a));
            Console.WriteLine(TwoSumFaster(a));
            Console.WriteLine(ThreeSum.Count(a));
            Console.WriteLine(ThreeSumFaster(a));
        }

        /// <summary>
        /// TwoSum 的快速实现。（线性级别）
        /// </summary>
        /// <param name="a">需要查找的数组范围。</param>
        /// <returns>数组中和为零的整数对数量。</returns>
        static int TwoSumFaster(int[] a)
        {
            int i = 0;
            int j = a.Length - 1;
            int count = 0;
            while (i != j)
            {
                if (a[i] + a[j] == 0)
                {
                    count++;
                    i++;
                    j--;
                }
                else if (a[i] + a[j] < 0)
                {
                    i++;
                }
                else
                {
                    j--;
                }
            }
            return count;
        }

        /// <summary>
        /// ThreeSum 的快速实现。（平方级别）
        /// </summary>
        /// <param name="a">需要查找的数组范围。</param>
        /// <returns>数组中和为零的三元组数量。</returns>
        static int ThreeSumFaster(int[] a)
        {
            int count = 0;
            for (int i = 0; i < a.Length; ++i)
            {
                int lo = i + 1;
                int hi = a.Length - 1;
                while (lo <= hi)
                {
                    if (a[lo] + a[hi] + a[i] == 0)
                    {
                        count++;
                        lo++;
                        hi--;
                    }
                    else if (a[lo] + a[hi] + a[i] < 0)
                    {
                        lo++;
                    }
                    else
                    {
                        hi--;
                    }
                }
            }
            return count;
        }
    }
}
