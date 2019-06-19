using System;

namespace _1._1._22
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            rank(9, array);
        }

        /// <summary>
        /// 二分查找，默认查找整个数组。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1, 1);
        }

        /// <summary>
        /// 二分查找。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <param name="lo">查找的下界。</param>
        /// <param name="hi">查找的上界。</param>
        /// <param name="number">递归的深度。</param>
        /// <returns></returns>
        public static int rank(int key, int[] a, int lo, int hi, int number)
        {

            for (var i = 0; i < number; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{number}: {lo} {hi}");

            if (lo > hi)
            {
                return -1;
            }

            var mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1, number + 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi, number + 1);
            }
            else
            {
                return mid;
            }
        }
    }
}