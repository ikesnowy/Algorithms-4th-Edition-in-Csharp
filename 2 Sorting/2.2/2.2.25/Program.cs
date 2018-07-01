using System;
using Merge;

namespace _2._2._25
{
    /*
     * 2.2.25
     * 
     * 多向归并排序。
     * 实现一个 k 向（相对双向而言）归并排序程序。
     * 分析你的算法，估计最佳的 k 值并通过实验验证猜想。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortKWay sort = new MergeSortKWay();
            MergeSort sort2Way = new MergeSort();
            int arraySize = 1000000;
            int trialTime = 10;
            int[][] data = new int[arraySize][];

            for (int i = 0; i < trialTime; i++)
            {
                data[i] = SortCompare.GetRandomArrayInt(arraySize);
            }

            double totalTime = 0;
            for (int j = 0; j < trialTime; j++)
            {
                int[] rawData = new int[data.Length];
                data[j].CopyTo(rawData, 0);
                totalTime += SortCompare.Time(sort, rawData);
            }

            for (int k = 2; k < 100000; k*=2)
            {
                Console.Write("k=" + k + "\t");
                totalTime = 0;
                for (int j = 0; j < trialTime; j++)
                {
                    int[] rawData = new int[data.Length];
                    data[j].CopyTo(rawData, 0);
                    totalTime += SortCompare.Time(sort, rawData);
                }
                Console.WriteLine("平均耗时：" + totalTime / trialTime + "ms");
            }
        }
    }
}
