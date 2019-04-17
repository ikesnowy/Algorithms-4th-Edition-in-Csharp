using System;
using Merge;

namespace _2._2._16
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortNatural mergeSort = new MergeSortNatural();

            Console.WriteLine("总长度\t有序\t时间\t比率");
            int maxSorted = 256;
            int repeatTime = 4;
            double previousTime = 1;
            for (int i = 0; i < 4; i++)
            {
                int n = 16384;
                for (int j = 0; j < 6; j++)
                {
                    double time = 0;
                    for (int k = 0; k < repeatTime; k++)
                    {
                        int[] test = new int[n];
                        int[] unsorted = SortCompare.GetRandomArrayInt(n - maxSorted);
                        int[] sorted = SortCompare.GetRandomArrayInt(maxSorted);
                        Array.Sort(sorted);
                        for (int l = 0; l < n - maxSorted; l++)
                        {
                            test[l] = unsorted[l];
                        }
                        for (int l = 0; l < maxSorted; l++)
                        {
                            test[l + n - maxSorted] = sorted[l];
                        }
                        time += SortCompare.Time(mergeSort, test);
                    }
                    if (j == 0)
                        Console.WriteLine(n + "\t" + maxSorted + "\t" + time / repeatTime + "\t---");
                    else
                        Console.WriteLine(n + "\t" + maxSorted + "\t" + time / repeatTime + "\t" + (time / repeatTime) / previousTime);

                    previousTime = time / repeatTime;
                    n *= 2;
                }
                maxSorted *= 4;
            }

        }
    }
}
