using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sort
{
    /// <summary>
    /// 静态类，提供一系列用于测试排序算法的方法。
    /// </summary>
    public static class SortCompare
    {
        /// <summary>
        /// 对相应排序算法执行一次耗时测试。
        /// </summary>
        /// <param name="sort">用于测试的排序算法。</param>
        /// <param name="a">用于测试的数据。</param>
        /// <returns>排序的耗时。</returns>
        public static double Time<T>(BaseSort sort, T[] a) where T : IComparable<T>
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sort.Sort(a);
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// 对相应排序算法做多次随机数据测试。
        /// </summary>
        /// <param name="sort">用于测试的排序算法。</param>
        /// <param name="n">每次测试的数据量。</param>
        /// <param name="trials">测试次数。</param>
        /// <returns>多次排序的总耗时。</returns>
        public static double TimeRandomInput(BaseSort sort, int n, int trials)
        {
            double total = 0.0;
            double[] a = new double[n];
            Random random = new Random();
            for (int t = 0; t < trials; t++)
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] = random.NextDouble();
                }
                total += Time(sort, a);
            }
            return total;
        }

        /// <summary>
        /// 对相应排序算法做多次有序数据测试。
        /// </summary>
        /// <param name="sort">用于测试的排序算法。</param>
        /// <param name="n">每次测试的数据量。</param>
        /// <param name="trials">测试次数。</param>
        /// <returns>多次排序的总耗时。</returns>
        public static double TimeSortedInput(BaseSort sort, int n, int trials)
        {
            double total = 0.0;
            double[] a = new double[n];
            for (int t = 0; t < trials; t++)
            {
                for (int i = 0; i < n; i++)
                {
                    a[i] = i * 1.0;
                }
                total += Time(sort, a);
            }
            return total;
        }

        /// <summary>
        /// 获取大小为 n 的随机整数数组。
        /// </summary>
        /// <param name="n">数组的大小。</param>
        /// <returns>大小为 n 的随机整数数组。</returns>
        public static int[] GetRandomArray(int n)
        {
            Random random = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }
    }
}
