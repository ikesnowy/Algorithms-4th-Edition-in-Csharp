using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;

namespace _2._1._30
{
    public class ShellSort : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public ShellSort() { }

        /// <summary>
        /// 利用希尔排序将数组按升序排序，使用几何级数序列。
        /// </summary>
        /// <typeparam name="T">待排序的元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        /// <param name="t">几何级数的底数。</param>
        public void Sort<T>(T[] a, int t) where T : IComparable<T>
        {
            int n = a.Length;
            int h = 1;
            while (h <= a.Length)
            {
                h *= t;
            }

            while (h >= 1)
            {
                for (int i = h; i < n; i++)
                {
                    for (int j = i; j >= h && Less(a[j], a[j - h]); j -= h)
                    {
                        Exch(a, j, j - h);
                    }
                }
                Debug.Assert(IsHSorted(a, h));
                h /= t;
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用希尔排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            int n = a.Length;
            int[] h = new int[2];   // 预先准备好的 h 值数组

            int hTemp = 1;
            int hLength = 0;
            for (hLength = 0; hTemp < n; hLength++)
            {
                if (hLength >= h.Length)  // 如果数组不够大则双倍扩容
                {
                    int[] expand = new int[h.Length * 2];
                    for (int j = 0; j < h.Length; j++)
                    {
                        expand[j] = h[j];
                    }
                    h = expand;
                }
                h[hLength] = hTemp;
                hTemp = hTemp * 3 + 1;
            }

            for (int t = hLength - 1; t >= 0; t--)
            {
                for (int i = h[t]; i < n; i++)
                {
                    for (int j = i; j >= h[t] && Less(a[j], a[j - h[t]]); j -= h[t])
                    {
                        Exch(a, j, j - h[t]);
                    }
                }
                Debug.Assert(IsHSorted(a, h[t]));
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 检查一次希尔排序后的子数组是否有序。
        /// </summary>
        /// <param name="a">排序后的数组。</param>
        /// <param name="h">子数组间隔。</param>
        /// <returns>是否有序。</returns>
        private bool IsHSorted<T>(T[] a, int h) where T : IComparable<T>
        {
            for (int i = h; i < a.Length; i++)
            {
                if (Less(a[i], a[i - h]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
