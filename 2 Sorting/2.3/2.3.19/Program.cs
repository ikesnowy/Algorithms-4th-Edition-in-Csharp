using System;
using Quick;

namespace _2._3._19
{
    
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickNormal = new QuickSort();
            QuickSortMedian3 quickMedian3 = new QuickSortMedian3();
            QuickSortMedian5 quickMedian5 = new QuickSortMedian5();
            int arraySize = 200000;                         // 初始数组大小。
            const int trialTimes = 4;                       // 每次实验的重复次数。
            const int trialLevel = 6;                       // 双倍递增的次数。

            Console.WriteLine("n\tmedian5\tmedian3\tnormal\tmedian5/normal\t\tmedian5/median3");
            for (int i = 0; i < trialLevel; i++)
            {
                double timeMedian3 = 0;
                double timeMedian5 = 0;
                double timeNormal = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(arraySize);
                    int[] b = new int[a.Length];
                    int[] c = new int[a.Length];
                    a.CopyTo(b, 0);
                    a.CopyTo(c, 0);
                    timeNormal += SortCompare.Time(quickNormal, a);
                    timeMedian3 += SortCompare.Time(quickMedian3, b);
                    timeMedian5 += SortCompare.Time(quickMedian5, c);
                }
                timeMedian5 /= trialTimes;
                timeMedian3 /= trialTimes;
                timeNormal /= trialTimes;
                Console.WriteLine(arraySize + "\t" + timeMedian5 + "\t" + timeMedian3 + "\t" + timeNormal + "\t" + timeMedian5 / timeNormal + "\t" + timeMedian5/timeMedian3);
                arraySize *= 2;
            }
        }
    }
}
