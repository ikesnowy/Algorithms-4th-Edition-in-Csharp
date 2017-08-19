using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._20
{
    /// <summary>
    /// 双调查找类。
    /// </summary>
    public class BitonicMax
    {
        /// <summary>
        /// 生成双调数组。
        /// </summary>
        /// <param name="N">数组的大小。</param>
        /// <returns></returns>
        public static int[] Bitonic(int N)
        {
            Random random = new Random();
            int mid = random.Next(N);
            int[] a = new int[N];
            for (int i = 1; i < mid; ++i)
            {
                a[i] = a[i - 1] + 1 + random.Next(9);
            }

            if (mid > 0)
            {
                a[mid] = a[mid - 1] + random.Next(10) - 5;
            }

            for (int i = mid + 1; i < N; ++i)
            {
                a[i] = a[i - 1] - 1 - random.Next(9);
            }

            return a;
        }

        /// <summary>
        /// 寻找数组中的最大值。
        /// </summary>
        /// <param name="a">查找范围。</param>
        /// <param name="lo">查找起始下标。</param>
        /// <param name="hi">查找结束下标。</param>
        /// <returns>返回数组中最大值的下标。</returns>
        public static int Max(int[] a, int lo, int hi)
        {
            if (lo == hi)
            {
                return hi;
            }
            int mid = lo + (hi - lo) / 2;
            if (a[mid] < a[mid + 1])
            {
                return Max(a, mid + 1, hi);
            }
            if (a[mid] > a[mid + 1])
            {
                return Max(a, lo, mid);
            }
            return mid;
        }
    }
}
