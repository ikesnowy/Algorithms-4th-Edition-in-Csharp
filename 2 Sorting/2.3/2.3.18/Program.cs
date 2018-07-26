using System;
using Quick;

namespace _2._3._18
{
    /*
     * 2.3.18
     * 
     * 三取样切分。
     * 为快速排序实现正文所述的三取样切分（参见 2.3.3.2 节）。
     * 运行双倍测试来确认这项改动的效果。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickNormal = new QuickSort();
            QuickSortMedian quickMedian = new QuickSortMedian
            {
                SampleArraySize = PivotArraySize.MedianOf3  //三取样切分。
            };
            int arraySize = 10000;                          // 初始数组大小。
            const int trialTimes = 5;                       // 每次实验的重复次数。
            const int trialLevel = 10;                      // 双倍递增的次数。

            Console.WriteLine("n\tmedian\tnormal\tratio");
            for (int i = 0; i < trialLevel; i++)
            {
                double timeMedian = 0;
                double timeNormal = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(arraySize);
                    int[] b = new int[a.Length];
                    a.CopyTo(b, 0);
                    timeNormal += SortCompare.Time(quickNormal, b);
                    timeMedian += SortCompare.Time(quickMedian, a);

                }
                timeMedian /= trialTimes;
                timeNormal /= trialTimes;
                Console.WriteLine(arraySize + "\t" + timeMedian + "\t" + timeNormal + "\t" + timeMedian / timeNormal);
                arraySize *= 2;
            }
        }
    }
}
