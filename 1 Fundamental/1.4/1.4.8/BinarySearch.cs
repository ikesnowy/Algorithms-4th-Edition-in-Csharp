using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._8
{
    /// <summary>
    /// 二分查找。
    /// </summary>
    public class BinarySearch
    {
        /// <summary>
        /// 用递归方法进行二分查找。
        /// </summary>
        /// <param name="key">关键字。</param>
        /// <param name="a">查找范围。</param>
        /// <param name="lo">查找的起始下标。</param>
        /// <param name="hi">查找的结束下标。</param>
        /// <returns>返回下标，如果没有找到则返回 -1。</returns>
        public static int Rank(int key, int[] a, int lo, int hi)
        {
            if (hi < lo)
                return -1;
            int mid = (hi - lo) / 2 + lo;
            if (a[mid] == key)
            {
                return mid;
            }
            else if (a[mid] < key)
            {
                return Rank(key, a, mid + 1, hi);
            }
            else
            {
                return Rank(key, a, lo, mid - 1);
            }
        }
    }
}
