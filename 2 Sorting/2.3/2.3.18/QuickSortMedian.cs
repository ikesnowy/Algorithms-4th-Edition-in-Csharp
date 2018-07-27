using System;
using System.Diagnostics;
using Quick;

namespace _2._3._18
{
    /// <summary>
    /// 枢轴选取的数组大小。
    /// </summary>
    public enum PivotArraySize
    {
        MedianOf3,
        MedianOf5
    }

    /// <summary>
    /// 快速排序类。
    /// </summary>
    public class QuickSortMedian : BaseSort
    {
        /// <summary>
        /// 取样数组大小。
        /// </summary>
        public PivotArraySize SampleArraySize { get; set; }

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public QuickSortMedian()
        {
            // 默认三取样
            this.SampleArraySize = PivotArraySize.MedianOf3;
        }

        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Shuffle(a);
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 用快速排序对数组 a 的 lo ~ hi 范围排序。
        /// </summary>
        /// <typeparam name="T">需要排序的数组类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="lo">排序范围的起始下标。</param>
        /// <param name="hi">排序范围的结束下标。</param>
        private void Sort<T>(T[] a, int lo, int hi) where T: IComparable<T>
        {
            if (hi <= lo)                   // 别越界
                return;
            int j = Partition(a, lo, hi);
            Sort(a, lo, j - 1);
            Sort(a, j + 1, hi);
        }

        /// <summary>
        /// 对数组进行切分，返回枢轴位置。
        /// </summary>
        /// <typeparam name="T">需要切分的数组类型。</typeparam>
        /// <param name="a">需要切分的数组。</param>
        /// <param name="lo">切分的起始点。</param>
        /// <param name="hi">切分的末尾点。</param>
        /// <returns>枢轴下标。</returns>
        private int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int i = lo, j = hi + 1;

            if (this.SampleArraySize == PivotArraySize.MedianOf3 && hi - lo >= 3)
            {
                if (Less(a[lo + 1], a[lo]))
                    Exch(a, lo + 1, lo);
                if (Less(a[lo + 2], a[lo]))
                    Exch(a, lo + 2, lo);
                if (Less(a[lo + 2], a[lo + 1]))
                    Exch(a, lo + 1, lo + 2);
                Exch(a, lo, lo + 1);
            }
            else if (this.SampleArraySize == PivotArraySize.MedianOf5 && hi - lo >= 5)
            {
                if (Less(a[lo], a[lo + 1]))
                    Exch(a, lo, lo + 1);
                if (Less(a[lo + 2], a[lo + 3]))
                    Exch(a, lo + 2, lo + 3);
                if (Less(a[lo], a[lo + 2]))
                {
                    Exch(a, lo, lo + 2);
                    Exch(a, lo + 1, lo + 3);
                }
                if (Less(lo + 1, lo + 4))
                    Exch(a, lo + 1, lo + 4);
                if (Less(a[lo + 2], a[lo + 1]))
                {
                    if (Less(a[lo + 4], a[lo + 2]))
                        Exch(a, lo, lo + 2);
                    else
                        Exch(a, lo, lo + 4);
                }
                else
                {
                    if (Less(a[lo + 3], a[lo + 1]))
                        Exch(a, lo, lo + 1);
                    else
                        Exch(a, lo, lo + 3);
                }
            }

            T v = a[lo];
            while (true)
            {
                while (Less(a[++i], v))
                    if (i == hi)
                        break;
                while (Less(v, a[--j])) ;
                if (i >= j)
                    break;
                Exch(a, i, j);
            }
            Exch(a, lo, j);
            return j;
        }

        /// <summary>
        /// 打乱数组。
        /// </summary>
        /// <typeparam name="T">需要打乱的数组类型。</typeparam>
        /// <param name="a">需要打乱的数组。</param>
        private void Shuffle<T>(T[] a)
        {
            Random random = new Random();
            for (int i = 0; i < a.Length; i++)
            {
                int r = i + random.Next(a.Length - i);
                T temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }
        }
    }
}
