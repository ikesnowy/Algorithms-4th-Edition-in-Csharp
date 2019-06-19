using System;

namespace _2._2._19
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 3, 5, 7, 2, 0 };
            var mergeSort = new MergeSort();
            mergeSort.Sort(a);
            Console.WriteLine(mergeSort.Counter);
        }
    }
}
