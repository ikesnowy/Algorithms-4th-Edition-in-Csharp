using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sort
{
    /// <summary>
    /// 插入排序类。
    /// </summary>
    public class InsertionSort : Sort
    {
        /// <summary>
        /// 这个类不应该被初始化。
        /// </summary>
        private InsertionSort() { }

        /// <summary>
        /// 利用插入排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public static void Sort(IComparable[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1]); --j)
                {
                    Exch(a, j, j - 1);
                }
                Debug.Assert(IsSorted(a, 0, i));
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用插入排序将数组按排序。（使用指定比较器）
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="c">比较器。</param>
        public static void Sort<T>(T[] a, Comparer<T> c)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
            {
                for (int j = i; j > 0 && Less(a[j], a[j - 1], c); --j)
                {
                    Exch(a, j, j - 1);
                }
                Debug.Assert(IsSorted(a, 0, i, c));
            }
            Debug.Assert(IsSorted(a, c));
        }
    }
}
