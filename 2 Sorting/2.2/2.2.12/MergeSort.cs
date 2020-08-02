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
            var blockNum = (a.Length + M - 1) / M;
            var selection = new SelectionSort();
            // 对块进行选择排序。
            for (var i = 0; i < blockNum; i++)
            {
                var lo = i * M;
                var hi = Math.Min((i + 1) * M - 1, a.Length - 1);
                selection.Sort(a, lo, hi);
            }
            // 将各个块合并。
            var aux = new T[M];
            for (var i = 0; i < blockNum - 1; i++)
            {
                Merge(a, aux, 0, (i + 1) * M - 1, Math.Min((i + 2) * M - 1, a.Length - 1));
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
            for (var k = mid + 1; k <= hi; k++)
            {
                aux[k - mid - 1] = a[k];
            }

            int i = mid, j = hi - mid - 1;
            for (var k = hi; k >= lo; k--)
            {
                if (i < lo)
                {
                    a[k] = aux[j];
                    j--;
                }
                else if (j < 0)
                {
                    a[k] = a[i];
                    i--;
                }
                else if (Less(aux[j], a[i]))
                {
                    a[k] = a[i];
                    i--;
                }
                else
                {
                    a[k] = aux[j];
                    j--;
                }
            }
        }
    }
}
