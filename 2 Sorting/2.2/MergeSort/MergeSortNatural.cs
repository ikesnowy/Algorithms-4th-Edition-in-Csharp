using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge
{
    /// <summary>
    /// 自然的归并排序。
    /// </summary>
    public class MergeSortNatural : BaseSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public MergeSortNatural() { }

        /// <summary>
        /// 利用自然的归并排序进行自底向上的排序。
        /// </summary>
        /// <typeparam name="T">用于排序的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            T[] aux = new T[a.Length];

            // 首先找到一个有序数组
            int lo, mid, hi;
            lo = 0;
            mid = 0;
            while (mid < a.Length - 1)
            {
                if (Less(a[mid], a[mid + 1]) || a[mid].Equals(a[mid + 1]))
                    mid++;
                else
                    break;
            }

            hi = mid + 1;
            while (hi < a.Length - 1)
            {
                // 找到下一个有序数组
                while (hi < a.Length - 1)
                {
                    if (Less(a[hi], a[hi + 1]) || a[hi].Equals(a[hi + 1]))
                        hi++;
                    else
                        break;
                }
                // 归并
                Merge(lo, mid, hi, a, aux);
                // 修改值
                mid = hi;
                hi = mid + 1;
            }

            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 利用自然的归并排序进行自底向上的排序。利用队列进行了优化。
        /// </summary>
        /// <typeparam name="T">用于排序的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public void SortX<T>(T[] a) where T : IComparable<T>
        {
            T[] aux = new T[a.Length];
            Queue<int> blockPairs = new Queue<int>();
            blockPairs.Enqueue(0);
            for (int i = 1; i < a.Length; i++)
            {
                if (!Less(a[i - 1], a[i]))
                {
                    blockPairs.Enqueue(i - 1);
                    blockPairs.Enqueue(i);
                }
            }
            blockPairs.Enqueue(a.Length - 1);
            while (blockPairs.Count >= 4)
            {
                int lo = blockPairs.Dequeue();
                int mid = blockPairs.Dequeue();

                // 如果总共的块数是单数的话，最后会多出一个块
                if (mid > blockPairs.Peek())
                {
                    blockPairs.Enqueue(lo);
                    blockPairs.Enqueue(mid);
                    continue;
                }
                blockPairs.Dequeue();
                int hi = blockPairs.Dequeue();
                Merge(lo, mid, hi, a, aux);
                blockPairs.Enqueue(lo);
                blockPairs.Enqueue(hi);
            }
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 将两个块归并。
        /// </summary>
        /// <typeparam name="T">数组的元素类型。</typeparam>
        /// <param name="lo">第一个块的开始下标。</param>
        /// <param name="mid">第一个块的结束下标（第二个块的开始下标 - 1）。</param>
        /// <param name="hi">第二个块的结束下标。</param>
        /// <param name="a">需要归并的数组。</param>
        /// <param name="aux">辅助数组。</param>
        private void Merge<T>(int lo, int mid, int hi, T[] a, T[] aux) where T : IComparable<T>
        {
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
