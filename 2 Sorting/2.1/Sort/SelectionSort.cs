using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Sort
{
    /// <summary>
    /// 选择排序类。
    /// </summary>
    public class SelectionSort : Sort
    {
        /// <summary>
        /// 这个类不应该被初始化。
        /// </summary>
        private SelectionSort() { }

        /// <summary>
        /// 利用选择排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public static void Sort(IComparable[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
            {
                int min = i;
                for (int j = i + 1; j < n; ++j)
                {
                    if (Less(a[j], a[i]))
                        min = j;
                }
                Exch(a, i, min);
                Debug.Assert(IsSorted(a, 0, i));
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用选择排序将数组按排序。（使用指定比较器）
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="c">比较器。</param>
        public static void Sort<T>(T[] a, Comparer<T> c)
        {
            int n = a.Length;
            for (int i = 0; i < n; ++i)
            {
                int min = i;
                for (int j = i + 1; j < n; ++j)
                {
                    if (Less(a[j], a[i], c))
                        min = j;
                }
                Exch(a, i, min);
                Debug.Assert(IsSorted(a, 0, i, c));
            }
            Debug.Assert(IsSorted(a, c));
        }
    }
}
