using System;
using Merge;

namespace _2._2._27
{
    /*
     * 2.2.27
     * 
     * 子数组长度。
     * 用归并将大型随机数组排序，
     * 根据经验用 N （某次归并时两个子数组的长度之和）
     * 的函数估计当一个子数组用尽时另一个子数组的平均长度。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int arraySize = 1000000;
            NotifiedMergeSort sort = new NotifiedMergeSort(arraySize);
            for (int i = 0; i < 100; i++)
            {
                int[] data = SortCompare.GetRandomArrayInt(arraySize);
                sort.Sort(data);
            }

            Console.WriteLine("n\trest\ttimes");
            for (int i = 0; i < sort.NArraySize.Length; i++)
            {
                if (sort.NArraySize[i] != 0)
                    Console.WriteLine(i + "\t" + sort.NArraySize[i] / sort.NArraySizeTime[i] + "\t" + sort.NArraySizeTime[i]);
            }
            // 大致上是一个对数函数
        }
    }
}
