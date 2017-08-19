using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    /// <summary>
    /// 用暴力方法查找数组中和为零的二元组。
    /// </summary>
    public static class TwoSum
    {
        /// <summary>
        /// 打印出数组中所有和为零的整数对。
        /// </summary>
        /// <param name="a">查找范围。</param>
        public static void PrintAll(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (a[i] + a[j] == 0)
                    {
                        Console.WriteLine(a[i] + " " + a[j]);
                    }
                }
            }
        }

        /// <summary>
        /// 计算数组中和为零的整数对数量。
        /// </summary>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int Count(int[] a)
        {
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    if (a[i] + a[j] == 0)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
