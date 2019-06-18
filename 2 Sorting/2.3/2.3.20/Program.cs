using System;
using Quick;

namespace _2._3._20
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickNormal = new QuickSort();
            QuickSortNonRecursive quickNonRecursive = new QuickSortNonRecursive();
            int arraySize = 200000;                         // 初始数组大小。
            const int trialTimes = 4;                       // 每次实验的重复次数。
            const int trialLevel = 5;                       // 双倍递增的次数。

            Console.WriteLine("n\tnon-recursive\tnormal\tratio");
            for (int i = 0; i < trialLevel; i++)
            {
                double timeRecursive = 0;
                double timeNormal = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(arraySize);
                    int[] b = new int[a.Length];
                    a.CopyTo(b, 0);
                    timeNormal += SortCompare.Time(quickNormal, b);
                    timeRecursive += SortCompare.Time(quickNonRecursive, a);

                }
                timeRecursive /= trialTimes;
                timeNormal /= trialTimes;
                Console.WriteLine(arraySize + "\t" + timeRecursive + "\t\t" + timeNormal + "\t" + timeRecursive / timeNormal);
                arraySize *= 2;
            }
        }
    }
}
