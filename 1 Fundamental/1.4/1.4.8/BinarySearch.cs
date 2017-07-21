using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._8
{
    public class BinarySearch
    {
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
