using System;

namespace _2._5._6
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 非递归官网实现见：https://algs4.cs.princeton.edu/23quicksort/QuickPedantic.java.html
            int[] a = { 2, 4, 1, 3, 5, 7, 9, 6 };
            int t = Select(a, 2, 0, a.Length - 1);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(t);
        }

        /// <summary>
        /// 使 a[k] 变为第 k 小的数，k 从 0 开始。
        /// a[0] ~ a[k-1] 都小于等于 a[k], a[k+1]~a[n-1] 都大于等于 a[k]
        /// </summary>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <param name="a">需要调整的数组。</param>
        /// <param name="k">序号。</param>
        /// <param name="lo">起始下标。</param>
        /// <param name="hi">终止下标。</param>
        /// <returns></returns>
        static T Select<T>(T[] a, int k, int lo, int hi) where T : IComparable<T>
        {
            if (k > a.Length || k < 0)
                throw new ArgumentOutOfRangeException("select out of bound");
            if (lo >= hi)
                return a[lo];

            int i = Partition(a, lo, hi);
            if (i > k)
                return Select(a, k, lo, i - 1);
            else if (i < k)
                return Select(a, k, i + 1, hi);
            else
                return a[i];
        }

        /// <summary>
        /// 对数组进行切分，返回切分的位置。
        /// </summary>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <param name="a">需要切分的数组。</param>
        /// <param name="lo">切分的起始下标。</param>
        /// <param name="hi">切分的终止下标。</param>
        /// <returns></returns>
        static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int i = lo;
            int j = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (a[++i].CompareTo(v) < 0)
                    if (i == hi)
                        break;
                while (v.CompareTo(a[--j]) < 0)
                    if (j == lo)
                        break;
                if (i >= j)
                    break;

                T t = a[i];
                a[i] = a[j];
                a[j] = t;
            }

            T temp = a[lo];
            a[lo] = a[j];
            a[j] = temp;

            return j;
        }
    }
}
