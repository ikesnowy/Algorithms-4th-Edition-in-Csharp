using System;
using Merge;

namespace _2._2._27
{
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
