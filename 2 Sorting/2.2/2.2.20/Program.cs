using System;

namespace _2._2._20
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort mergeSort = new MergeSort();
            int[] a = new int[] { 2, 4, 6, 8, 1, 3, 5, 7, 9 };

            int[] index = mergeSort.IndexSort(a);

            Console.Write("Index \t");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            Console.Write("Array\t");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();

            Console.Write("Sorted\t");
            for (int i = 0; i < index.Length; i++)
            {
                Console.Write(index[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
