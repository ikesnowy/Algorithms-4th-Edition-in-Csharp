using System;
using Quick;

namespace _2._3._17
{
    
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quick = new QuickSort();
            QuickSortX quickSortX = new QuickSortX();
            int arrayLength = 1000000;
            int[] a = SortCompare.GetRandomArrayInt(arrayLength);
            int[] b = new int[arrayLength];
            a.CopyTo(b, 0);

            double time1 = SortCompare.Time(quick, a);
            double time2 = SortCompare.Time(quickSortX, b);
            Console.WriteLine("QSort\tQSort with Sentinels\t");
            Console.WriteLine(time1 + "\t" + time2 + "\t");
        }
    }
}
