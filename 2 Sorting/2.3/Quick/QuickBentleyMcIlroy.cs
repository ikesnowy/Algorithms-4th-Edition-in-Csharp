using System;
using System.Diagnostics;

namespace Quick
{
    public class QuickBentleyMcIlroy : BaseSort
    {
        /// <summary>
        /// 小于这个数值的数组调用插入排序。
        /// </summary>
        private readonly int INSERTION_SORT_CUTOFF = 8;

        /// <summary>
        /// 小于这个数值的数组调用中位数作为枢轴。
        /// </summary>
        private readonly int MEDIAN_OF_3_CUTOFF = 40;

        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public QuickBentleyMcIlroy() { }

        /// <summary>
        /// 用快速排序对数组 a 进行升序排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        public override void Sort<T>(T[] a)
        {
            Sort(a, 0, a.Length - 1);
            Debug.Assert(IsSorted(a));
        }

        /// <summary>
        /// 对指定范围内的数组进行排序。
        /// </summary>
        /// <typeparam name="T">需要排序的类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="lo">排序的起始下标。</param>
        /// <param name="hi">排序的终止下标。</param>
        private void Sort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int n = hi - lo + 1;

            if (n <= this.INSERTION_SORT_CUTOFF)
            {
                InsertionSort(a, lo, hi);
                return;
            }
            else if (n <= this.MEDIAN_OF_3_CUTOFF)
            {
                // 对于较小的数组，直接选择左中右三个元素中的中位数作为枢轴。
                int m = Median3(a, lo, lo + n / 2, hi);
                Exch(a, m, lo);
            }
            else
            {
                // 对于较大的数组使用 Turkey Ninther 作为枢轴。
                int eps = n / 8;
                int mid = lo + n / 2;
                int m1 = Median3(a, lo, lo + eps, lo + eps + eps);
                int m2 = Median3(a, mid - eps, mid, mid + eps); 
                int m3 = Median3(a, hi - eps - eps, hi - eps, hi);
                int ninther = Median3(a, m1, m2, m3);
                Exch(a, ninther, lo);
            }

            // 三向切分
            int i = lo, j = hi + 1;
            int p = lo, q = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (Less(a[++i], v))
                    if (i == hi)
                        break;
                while (Less(v, a[--j]))
                    if (j == lo)
                        break;

                if (i == j && IsEqual(a[i], v))
                    Exch(a, ++p, i);
                if (i >= j)
                    break;

                Exch(a, i, j);
                if (IsEqual(a[i], v))
                    Exch(a, ++p, i);
                if (IsEqual(a[j], v))
                    Exch(a, --q, j);
            }

            i = j + 1;
            for (int k = lo; k <= p; k++)
                Exch(a, k, j--);
            for (int k = hi; k >= q; k--)
                Exch(a, k, i++);

            Sort(a, lo, j);
            Sort(a, i, hi);
        }

        /// <summary>
        /// 判断两个元素是否值相等。
        /// </summary>
        /// <typeparam name="T">需要判断的元素类型。</typeparam>
        /// <param name="a">进行比较的第一个元素。</param>
        /// <param name="b">进行比较的第二个元素。</param>
        /// <returns>两个元素的值是否相等。</returns>
        private bool IsEqual<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) == 0;
        }

        /// <summary>
        /// 用插入排序对指定范围内的数组排序。
        /// </summary>
        /// <typeparam name="T">数组的元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="lo">排序的起始下标。</param>
        /// <param name="hi">排序的终止下标。</param>
        private void InsertionSort<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            for (int i = lo; i <= hi; i++)
            {
                for (int j = i; j > lo && Less(a[j], a[j - 1]); j--)
                {
                    Exch(a, j, j - 1);
                }
            }
        }

        /// <summary>
        /// 获取三个元素中的中位数。
        /// </summary>
        /// <typeparam name="T">用于排序的元素。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="i">第一个待选元素的下标。</param>
        /// <param name="j">第二个待选元素的下标。</param>
        /// <param name="k">第三个待选元素的下标。</param>
        /// <returns></returns>
        private int Median3<T>(T[] a, int i, int j, int k) where T : IComparable<T>
        {
            return
               (Less(a[i], a[j]) ?
               (Less(a[j], a[k]) ? j : Less(a[i], a[k]) ? k : i) :
               (Less(a[k], a[j]) ? j : Less(a[k], a[i]) ? k : i));
        }
    }
}
