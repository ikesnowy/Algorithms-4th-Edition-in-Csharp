using System;
using Quick;

namespace _2._3._19
{
    /*
     * 2.3.19
     * 
     * 五取样切分。
     * 实现一种基于随机抽取子数组中 5 个元素并取中位数进行切分的快速排序。
     * 将取样元素放在数组的一侧以保证只有中位数元素参与了切分。
     * 运行双倍测试来确定这项改动的效果，
     * 并和标准的快速排序以及三取样的快速排序（请见上一道练习）进行比较。
     * 附加题：找到一种对于任意输入都只需要少于 7 次比较的五取样算法。
     * 
     */
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
