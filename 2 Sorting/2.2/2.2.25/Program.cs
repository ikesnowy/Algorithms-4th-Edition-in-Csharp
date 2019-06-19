using System;
using Merge;

namespace _2._2._25
{
    class Program
    {
        static void Main(string[] args)
        {
            var sort = new MergeSortKWay();
            var sort2Way = new MergeSort();
            var arraySize = 1000000;
            var trialTime = 10;
            var data = new int[arraySize][];

            for (var i = 0; i < trialTime; i++)
            {
                data[i] = SortCompare.GetRandomArrayInt(arraySize);
            }

            double totalTime = 0;
            for (var j = 0; j < trialTime; j++)
            {
                var rawData = new int[data.Length];
                data[j].CopyTo(rawData, 0);
                totalTime += SortCompare.Time(sort, rawData);
            }

            for (var k = 2; k < 100000; k *= 2)
            {
                Console.Write("k=" + k + "\t");
                totalTime = 0;
                for (var j = 0; j < trialTime; j++)
                {
                    var rawData = new int[data.Length];
                    data[j].CopyTo(rawData, 0);
                    totalTime += SortCompare.Time(sort, rawData);
                }
                Console.WriteLine("平均耗时：" + totalTime / trialTime + "ms");
            }
        }
    }
}