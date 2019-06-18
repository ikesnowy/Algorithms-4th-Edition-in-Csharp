using System;
using Merge;

namespace _2._2._12
{
    /// <summary>
    /// 归并排序类。
    /// </summary>
    public class MergeSort : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MergeSort() { }

        /// <summary>
        /// 利用归并排序将数组按升序排序。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">待排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Sort(a, 1);
        }

        /// <summary>
        /// 利用分块法进行归并排序。
        /// </summary>
        /// <typeparam name="T">待排序的数组内容。</typeparam>
        /// <param name="a">待排序的数组。</param>
        /// <param name="M">分块大小。</param>
        public void Sort<T>(T[] a, int M) where T : IComparable<T>
        {
            int blockNum = (a.Length + M - 1) / M;
            SelectionSort selection = new SelectionSort();
            // 对块进行选择排序。
            for (int i = 0; i < blockNum; i++)
            {
                int lo = i * M;
                int hi = Math.Min((i + 1) * M - 1, a.Length - 1);
                selection.Sort(a, lo, hi);
            }
            // 将各个块合并。
            for (int i = 0; i < blockNum - 1; i++)
            {
                Merge(a, 0, (i + 1) * M - 1, Math.Min((i + 2) * M - 1, a.Length - 1));
            }
        }

        /// <summary>
        /// 将指定范围内的元素归并。
        /// </summary>
        /// <typeparam name="T">数组元素类型。</typeparam>
        /// <param name="a">原数组。</param>
        /// <param name="lo">范围起点。</param>
        /// <param name="mid">范围中点。</param>
        /// <param name="hi">范围终点。</param>
        private void Merge<T>(T[] a, int lo, int mid, int hi) where T : IComparable<T>
        {
            T[] aux = new T[hi - lo + 1];
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = a[k];
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
            }
        }
    }
}
