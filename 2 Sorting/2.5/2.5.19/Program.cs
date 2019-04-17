using System;

namespace _2._5._19
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 官方解答：
            // https://algs4.cs.princeton.edu/25applications/KendallTau.java.html
            // https://algs4.cs.princeton.edu/22mergesort/Inversions.java.html

            int[] testA = { 0, 3, 1, 6, 2, 5, 4 };
            int[] testB = { 1, 0, 3, 6, 4, 2, 5 };
            Console.WriteLine(Distance(testA, testB));
        }

        public static long Distance(int[] a, int[] b)
        {
            if (a.Length != b.Length)
                throw new ArgumentException("Array dimensions disagree");
            int n = a.Length;

            int[] ainv = new int[n];
            for (int i = 0; i < n; i++)
            {
                ainv[a[i]] = i;
            }

            int[] bnew = new int[n];
            for (int i = 0; i < n; i++)
            {
                bnew[i] = ainv[b[i]];
            }

            Inversions inversions = new Inversions();
            inversions.Count(bnew);
            return inversions.Counter;
        }
    }
}
