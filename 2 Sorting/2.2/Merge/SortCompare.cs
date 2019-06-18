using System;
using System.Diagnostics;

namespace Merge
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
        /// <returns>排序的耗时，单位为毫秒。</returns>
        public static double Time<T>(BaseSort sort, T[] a) where T : IComparable<T>
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            sort.Sort(a);
            return stopwatch.ElapsedMilliseconds;
        }

        /// <summary>
        /// 对相应排序算法做多次随机数据测试，返回总耗时。
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
        /// 对相应排序算法做多次有序数据测试，返回总耗时。
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
        public static int[] GetRandomArrayInt(int n)
        {
            Random random = new Random();
            int[] array = new int[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.Next();
            }
            return array;
        }

        /// <summary>
        /// 获取大小为 n 的随机 double 数组。
        /// </summary>
        /// <param name="n">随机数组的大小。</param>
        /// <returns>大小为 n 的随机 double 数组。</returns>
        public static double[] GetRandomArrayDouble(int n)
        {
            Random random = new Random();
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = random.NextDouble() * double.MaxValue;
            }
            return array;
        }

        /// <summary>
        /// 获取符合标准正态分布的 double 数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>符合标准正态分布的 double 数组。</returns>
        public static double[] GetNormalDistributionArray(int n)
        {
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = SortUtil.Normal(0, 1);
            }
            return array;
        }

        /// <summary>
        /// 产生符合泊松分布的随机数组。
        /// </summary>
        /// <param name="n">随机数组的大小。</param>
        /// <returns>符合泊松分布的数组。</returns>
        public static double[] GetPossionDistributionArray(int n)
        {
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = SortUtil.Poission(20);
            }
            return array;
        }


        /// <summary>
        /// 产生符合几何分布的随机数组。
        /// </summary>
        /// <param name="n">随机数组的大小。</param>
        /// <param name="p">几何分布的概率。</param>
        /// <returns>符合几何分布的随机数组。</returns>
        public static double[] GetGeometricDistributionArray(int n, double p)
        {
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = SortUtil.Geometry(p);
            }
            return array;
        }

        /// <summary>
        /// 产生符合指定概率的离散分布的随机数组。
        /// </summary>
        /// <param name="n">随机数组的大小。</param>
        /// <param name="probabilities">各取值的概率数组。</param>
        /// <returns>符合指定概率的离散分布的随机数组。</returns>
        public static double[] GetDiscretDistributionArray(int n, double[] probabilities)
        {
            double[] array = new double[n];
            for (int i = 0; i < n; i++)
            {
                array[i] = SortUtil.Discrete(probabilities);
            }
            return array;
        }
    }
}
