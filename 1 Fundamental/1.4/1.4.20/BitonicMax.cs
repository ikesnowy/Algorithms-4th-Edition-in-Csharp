using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._20
{
    public class BitonicMax
    {
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
