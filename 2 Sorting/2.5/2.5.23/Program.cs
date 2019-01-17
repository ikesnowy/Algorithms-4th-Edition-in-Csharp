using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._5._23
{
    /*
     * 2.5.23
     * 
     * 选择的取样：实验使用取样来改进 select() 函数的想法。
     * 提示：使用中位数可能并不总是有效。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 2, 4, 1, 3, 5, 7, 9, 6 };
            int t = Select(a, 2);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine(t);
        }

        /// <summary>
        /// 令 a[k] 变成第 k 小的元素。
        /// </summary>
        /// <typeparam name="T">元素类型。</typeparam>
        /// <param name="a">需要排序的数组。</param>
        /// <param name="k">序号</param>
        /// <returns></returns>
        static T Select<T>(T[] a, int k) where T : IComparable<T>
        {
            if (k < 0 || k > a.Length)
                throw new IndexOutOfRangeException("Select elements out of bounds");
            Shuffle(a);
            int lo = 0, hi = a.Length - 1;
            while (hi > lo)
            {
                int i = Partition(a, lo, hi);
                if (i > k)
                    hi = i - 1;
                else if (i < k)
                    lo = i + 1;
                else
                    return a[i];
            }
            return a[lo];
        }

        /// <summary>
        /// 对数组进行切分，返回枢轴位置。
        /// </summary>
        /// <typeparam name="T">需要切分的数组类型。</typeparam>
        /// <param name="a">需要切分的数组。</param>
        /// <param name="lo">切分的起始点。</param>
        /// <param name="hi">切分的末尾点。</param>
        /// <returns>枢轴下标。</returns>
        static int Partition<T>(T[] a, int lo, int hi) where T : IComparable<T>
        {
            int i = lo, j = hi + 1;
            T v = a[lo];
            while (true)
            {
                while (Less(a[++i], v))
                    if (i == hi)
                        break;
                while (Less(v, a[--j]))
                    if (j == lo)
                        break;
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
        private static void Shuffle<T>(T[] a)
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

        /// <summary>
        /// 比较第一个参数是否小于第二个参数。
        /// </summary>
        /// <param name="v">第一个参数。</param>
        /// <param name="w">第二个参数。</param>
        /// <returns>如果第一个参数小于第二个参数则返回 true，
        /// 否则返回 false。</returns>
        static bool Less<T>(T v, T w) where T : IComparable<T>
        {
            return v.CompareTo(w) < 0;
        }

        /// <summary>
        /// 交换数组中下标为 i, j 的两个元素。
        /// </summary>
        /// <typeparam name="T">元素的类型。</typeparam>
        /// <param name="a">元素所在的数组。</param>
        /// <param name="i">需要交换的第一个元素。</param>
        /// <param name="j">需要交换的第二个元素。</param>
        static void Exch<T>(T[] a, int i, int j)
        {
            T t = a[i];
            a[i] = a[j];
            a[j] = t;
        }
    }
}
