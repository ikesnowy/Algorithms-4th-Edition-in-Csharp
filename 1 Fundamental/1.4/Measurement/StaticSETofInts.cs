using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measurement
{
    public class StaticSETofInts
    {
        private int[] a;
        public StaticSETofInts(int[] keys)
        {
            this.a = new int[keys.Length];
            for (int i = 0; i < keys.Length; ++i)
            {
                a[i] = keys[i];
            }
            Array.Sort(a);
        }

        public bool Cantains(int key)
        {
            return Rank(key, 0, a.Length - 1) != -1;
        }

        public int HowMany(int key)
        {
            int count = 0;
            int hi = a.Length - 1;
            int lo = 0;
            if (Rank(key, lo, hi) != -1)
            {
                count++;

            }
        }

        public int Rank(int key, int lo, int hi)
        {
            while (lo < hi)
            {
                int mid = (hi - lo) / 2 + lo;
                if (key < a[mid])
                    hi = mid - 1;
                else if (key > a[mid])
                    lo = mid + 1;
                else
                    return mid;
            }
            return -1;
        }
    }
}
