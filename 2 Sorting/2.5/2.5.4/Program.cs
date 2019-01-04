using System;

namespace _2._5._4
{
    /*
     * 2.5.4
     * 
     * 实现一个方法 String[] dedup(String[] a)，
     * 返回一个有序的 a[]，并删去其中的重复元素。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] a = new string[] { "dup", "aba", "dup", "aaaaa", "aba", "cs" };
            string[] distinct = Dedup(a);
            for (int i = 0; i < distinct.Length; i++)
            {
                Console.Write(distinct[i] + " ");
            }
        }

        static string[] Dedup(string[] a)
        {
            if (a.Length == 0)
                return a;

            string[] sorted = new string[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                sorted[i] = a[i];
            }
            Array.Sort(sorted);
            // sorted = sorted.Distinct().ToArray();
            string[] distinct = new string[sorted.Length];
            distinct[0] = sorted[0];
            int j = 1;
            for (int i = 1; i < sorted.Length; i++)
            {
                if (sorted[i].CompareTo(sorted[i - 1]) != 0)
                    distinct[j++] = sorted[i];
            }
            return distinct;
        }
    }
}
