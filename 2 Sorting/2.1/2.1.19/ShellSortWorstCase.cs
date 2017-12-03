using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._19
{
    class ShellSortWorstCase
    {
        public static int[] GetWorst(int[] p, int n)
        {
            int l = 0;
            int?[] a = new int?[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = null;
            }

            int pTemp = p[p.Length / 2];
            for (int i = 1; l < 100; i++)
            {
                int temp = pTemp * i;
                for (int j = 1; j <= n; j++)
                {
                    if (a[j] == null && temp - j >= 0)
                    {
                        l++;
                        a[j] = l;
                    }
                }
            }

            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = (int)a[i + 1];
            }

            return b;
        }
    }
}
