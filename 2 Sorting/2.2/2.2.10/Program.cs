using System;

namespace _2._2._10
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 2, 4, 6, 8, 10, 1, 3, 5, 7 };
            MergeSort merge = new MergeSort();
            merge.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
