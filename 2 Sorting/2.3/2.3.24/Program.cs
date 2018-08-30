using System;
using Quick;

namespace _2._3._24
{
    /*
     * 2.3.24
     * 
     * 取样排序。（W.Frazer，A.McKellar）
     * 实现一个快速排序，
     * 取样大小为 2^k-1。首先将取样得到的元素排序，
     * 然后在递归函数中使用样品的中位数切分。
     * 分为两部分的其余样品元素无需再次排序并可以分别应用于原数组的两个子数组。
     * 这种算法称为取样排序。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickNormal = new QuickSort();
            SampleSort sampleSort = new SampleSort();
            int arraySize = 1600000;                        // 初始数组大小。
            const int kSteps = 10;                          // 取样 k 值的递增次数。
            const int trialTimes = 1;                       // 每次实验的重复次数。
            const int trialLevel = 2;                       // 双倍递增的次数。

            Console.WriteLine("k\tn\t\tsample\tnormal\tratio");
            for (int i = 0; i < kSteps; i++)
            {
                int array = arraySize;
                for (int j = 0; j < trialLevel; j++)
                {
                    double timeSample = 0;
                    double timeNormal = 0;
                    for (int k = 0; k < trialTimes; k++)
                    {
                        int[] a = SortCompare.GetRandomArrayInt(array);
                        int[] b = new int[a.Length];
                        a.CopyTo(b, 0);
                        timeNormal += SortCompare.Time(quickNormal, b);
                        timeSample += SortCompare.Time(sampleSort, a);

                    }
                    timeSample /= trialTimes;
                    timeNormal /= trialTimes;
                    if (arraySize < 10000000)
                        Console.WriteLine(sampleSort.K + "\t" + array + "\t\t" + timeSample + "\t" + timeNormal + "\t" + timeSample / timeNormal);
                    else
                        Console.WriteLine(sampleSort.K + "\t" + array + "\t" + timeSample + "\t" + timeNormal + "\t" + timeSample / timeNormal);
                    array *= 2;
                }
                sampleSort.K++;
            }

        }
    }
}
