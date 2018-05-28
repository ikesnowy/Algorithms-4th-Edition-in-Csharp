using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._6
{
    /// <summary>
    /// 自底向上的归并排序法。
    /// </summary>
    class MergeSortBU : BaseSort
    {
        /// <summary>
        /// 数组访问计数。
        /// </summary>
        private int arrayVisitCount = 0;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MergeSortBU() { }

        /// <summary>
        /// 获得数组访问计数。
        /// </summary>
        /// <returns>数组访问计数值。</returns>
        public int GetArrayVisitCount()
        {
            return this.arrayVisitCount;
        }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public void ClearArrayVisitCount()
        {
            this.arrayVisitCount = 0;
        }

        /// <summary>
        /// 利用归并排序将数组按升序排序。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            int n = a.Length;
            T[] aux = new T[n];
            for (int len = 1; len < n; len *= 2)
            {
                for (int lo = 0; lo < n - len; lo += len + len)
                {
                    int mid = lo + len - 1;
                    int hi = Math.Min(lo + len + len - 1, n - 1);
                    Merge(a, aux, lo, mid, hi);
                }
            }
        }

        /// <summary>
        /// 将指定范围内的元素归并。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="aux">辅助数组。</param>
        /// <param name="lo">范围起点。</param>
        /// <param name="mid">范围中点。</param>
        /// <param name="hi">范围终点。</param>
        private void Merge<T>(T[] a, T[] aux, int lo, int mid, int hi) where T : IComparable<T>
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
                this.arrayVisitCount++;
            }

            int i = lo, j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                {
                    a[k] = aux[j];
                    j++;
                }
                else if (j > hi)
                {
                    a[k] = aux[i];
                    i++;
                }
                else if (Less(aux[j], aux[i]))
                {
                    a[k] = aux[j];
                    j++;
                }
                else
                {
                    a[k] = aux[i];
                    i++;
                }
                this.arrayVisitCount++;
            }
        }
    }
}
