using System;

namespace _1._4._18
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[5] { 1, 2, 5, 3, 5 };
            Console.WriteLine(LocalMinimum(a));
        }

        /// <summary>
        /// 寻找数组的局部最小元素。
        /// </summary>
        /// <param name="a">寻找范围。</param>
        /// <returns>局部最小元素的值。</returns>
        static int LocalMinimum(int[] a)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo <= hi)
            {
                int mid = (hi - lo) / 2 + lo;
                int min = mid;

                // 取左中右最小值的下标
                if (mid != hi && a[min] >= a[mid + 1])
                    min = mid + 1;
                if (mid != lo && a[min] >= a[mid - 1])
                    min = mid - 1;

                if (min == mid)
                    return mid;
                if (min > mid)
                    lo = min;
                else
                    hi = min;
            }
            return -1;
        }
    }
}