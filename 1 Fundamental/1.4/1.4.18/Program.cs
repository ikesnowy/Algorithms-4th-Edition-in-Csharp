using System;

namespace _1._4._18
{
    /*
     * 1.4.18
     * 
     * 数组的局部最小元素。
     * 编写一个程序，给定一个含有 N 个不同整数的数组，找到一个局部最小元素：
     * 满足 a[i] < a[i-1]，且 a[i] < a[i+1] 的索引 i。
     * 程序在最坏情况下所需的比较次数为 ~ 2lgN。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 5, 6, 5, 3, 5 };
            Console.WriteLine(LocalMinimum(a));
        }

        /// <summary>
        /// 寻找数组的局部最小元素。
        /// </summary>
        /// <param name="testcases">寻找范围。</param>
        /// <returns>局部最小元素的值。</returns>
        static int LocalMinimum(int[] testcases)
        {
            int lo = 0;
            int hi = testcases.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (testcases[mid] < testcases[mid - 1] && testcases[mid] < testcases[mid + 1])
                    return mid;
                if (testcases[mid - 1] < testcases[mid + 1])
                    hi = mid - 1;
                else
                    lo = mid + 1;
            }
            return -1;
        }
    }
}
