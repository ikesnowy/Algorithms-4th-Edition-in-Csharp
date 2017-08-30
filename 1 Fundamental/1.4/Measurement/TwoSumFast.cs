using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    /// <summary>
    /// 用二分查找优化的方法查找数组中和为零的二元组。
    /// </summary>
    public static class TwoSumFast
    {
        /// <summary>
        /// 打印出数组中所有和为零的整数对。
        /// </summary>
        /// <param name="a">查找范围。</param>
        public static void PrintAll(int[] a)
        {
            int n = a.Length;
            Array.Sort(a);
            for (int i = 0; i < n; ++i)
            {
                int j = Array.BinarySearch(a, -a[i]);
                if (j > i)
                {
                    Console.WriteLine(a[i] + " " + a[j]);
                }
            }
        }

        /// <summary>
        /// 计算数组中和为零的整数对数量。
        /// </summary>
        /// <param name="a">查找范围。</param>
        /// <returns>数组中和为零的整数对数量。</returns>
        public static int Count(int[] a)
        {
            int n = a.Length;
            Array.Sort(a);
            int count = 0;
            for (int i = 0; i < n; ++i)
            {
                int j = Array.BinarySearch(a, -a[i]);
                if (i < j)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
