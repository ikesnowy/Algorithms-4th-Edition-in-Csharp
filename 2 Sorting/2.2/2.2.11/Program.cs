using System;
using Merge;

namespace _2._2._11
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortX mergeSortX = new MergeSortX();
            int[] a = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            mergeSortX.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}