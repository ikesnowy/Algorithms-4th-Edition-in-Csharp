using System;
using Merge;

namespace _2._2._22
{
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortThreeWay mergeSortThreeWay = new MergeSortThreeWay();
            int n = 131072;
            int trialTime = 5;
            double previousTime = 1;
            Console.WriteLine("数组\t耗时\t比率");
            for (int i = 0; i < 6; i++)
            {
                double time = SortCompare.TimeRandomInput(mergeSortThreeWay, n, trialTime);
                time /= trialTime;
                if (i == 0)
                    Console.WriteLine(n + "\t" + time + "\t----");
                else
                    Console.WriteLine(n + "\t" + time + "\t" + time / previousTime);
                previousTime = time;
                n *= 2;
            }
        }
    }
}