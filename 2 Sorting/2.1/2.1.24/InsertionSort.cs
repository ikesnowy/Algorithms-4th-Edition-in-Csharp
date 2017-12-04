using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Sort;

namespace _2._1._24
{
    /// <summary>
    /// 插入排序类。
    /// </summary>
    public class InsertionSort : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public InsertionSort() { }

        /// <summary>
        /// 利用插入排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            int n = a.Length;
            int min = 0;

            // 获得最小值
            for (int i = 0; i < n; i++)
            {
                if (Less(a[i], a[min]))
                {
                    min = i;
                }
            }

            // 和第一位交换
            T temp = a[0];
            a[0] = a[min];
            a[min] = temp;

            for (int i = 1; i < n; i++)
            {
                for (int j = i; Less(a[j], a[j - 1]); --j)
                {
                    Exch(a, j, j - 1);
                }
                Debug.Assert(IsSorted(a, 0, i));
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用插入排序将数组排序。（使用指定比较器）
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="c">比较器。</param>
        public void Sort<T>(T[] a, IComparer<T> c)
        {
            int n = a.Length;
            int min = 0;

            // 获得最小值
            for (int i = 0; i < n; i++)
            {
                if (Less(a[i], a[min], c))
                {
                    min = i;
                }
            }

            // 和第一位交换
            T temp = a[0];
            a[0] = a[min];
            a[min] = temp;

            for (int i = 1; i < n; i++)
            {
                for (int j = i; Less(a[j], a[j - 1], c); --j)
                {
                    Exch(a, j, j - 1);
                }
                Debug.Assert(IsSorted(a, 0, i, c));
            }
            Debug.Assert(IsSorted(a, c));
        }
    }
}
