using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    /// <summary>
    /// 排序算法类模板。
    /// </summary>
    public abstract class BaseSort
    {
        public abstract void Sort<T>(T[] a) where T : IComparable<T>;

        /// <summary>
        /// 比较第一个参数是否小于第二个参数。
        /// </summary>
        /// <param name="v">第一个参数。</param>
        /// <param name="w">第二个参数。</param>
        /// <returns>如果第一个参数小于第二个参数则返回 true，
        /// 否则返回 false。</returns>
        protected bool Less<T>(T v, T w) where T :IComparable<T>
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 使用指定的比较器比较第一个参数是否小于第二个参数。
        /// </summary>
        /// <typeparam name="T">比较的元素类型。</typeparam>
        /// <param name="v">比较的第一个元素。</param>
        /// <param name="w">比较的第二个元素</param>
        /// <param name="c">比较器。</param>
        /// <returns></returns>
        protected bool Less<T>(T v, T w, IComparer<T> c)
        {
            return c.Compare(v, w) < 0;
        }

        /// <summary>
        /// 交换数组中下标为 i, j 的两个元素。
        /// </summary>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <param name="a">元素所在的数组。</param>
        /// <param name="i">需要交换的第一个元素。</param>
        /// <param name="j">需要交换的第二个元素。</param>
        protected void Exch<T>(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
        }

        /// <summary>
        /// 将数组的内容打印在一行中。
        /// </summary>
        /// <param name="a">需要打印的数组。</param>
        protected void Show<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 检查数组是否有序（升序）。
        /// </summary>
        /// <param name="a">需要检查的数组。</param>
        /// <returns>有序则返回 true，否则返回 false。</returns>
        public bool IsSorted<T>(T[] a) where T : IComparable<T>
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查数组是否有序。（使用指定的比较器）
        /// </summary>
        /// <param name="a">需要检查的数组。</param>
        /// <param name="c">比较器。</param>
        /// <returns>有序则返回 true，否则返回 false。</returns>
        public bool IsSorted<T>(T[] a, IComparer<T> c)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Less(a[i], a[i - 1], c))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查数组在范围 [lo, hi] 内是否有序（升序）。
        /// </summary>
        /// <param name="a">需要检查的数组。</param>
        /// <param name="lo">检查范围的下界。</param>
        /// <param name="hi">检查范围的上界。</param>
        /// <returns>有序则返回 true，否则返回 false。</returns>
        public bool IsSorted<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            for (int i = lo + 1; i <= hi; i++)
            {
                if (Less(a[i], a[i - 1]))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 检查数组在指定范围内是否有序。（使用指定的比较器）
        /// </summary>
        /// <typeparam name="T">数组的元素类型。</typeparam>
        /// <param name="a">需要检查的数组。</param>
        /// <param name="lo">检查范围的下界。</param>
        /// <param name="hi">检查范围的上界。</param>
        /// <param name="c">比较器。</param>
        /// <returns>有序则返回 true，否则返回 false。</returns>
        public bool IsSorted<T>(T[] a, int lo, int hi, IComparer<T> c)
        {
            for (int i = lo + 1; i <= hi; i++)
            {
                if (Less(a[i], a[i - 1], c))
                    return false;
            }
            return true;
        }
    }
}
