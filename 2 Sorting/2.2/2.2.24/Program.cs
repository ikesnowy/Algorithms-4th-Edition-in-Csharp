using System;
using Merge;

namespace _2._2._24
{
    
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortX mergeSortX = new MergeSortX();
            int n = 10000;
            int trialTimes = 10;
            Console.WriteLine("数组\t平均命中次数");
            for (int i = 0; i < 4; i++)
            {
                int avgHit = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    mergeSortX.ResetHitTime();
                    int[] a = SortCompare.GetRandomArrayInt(n);
                    mergeSortX.Sort(a);
                    avgHit += mergeSortX.GetHitTime();
                }

                Console.WriteLine(n + "\t" + avgHit / trialTimes);
                n *= 10;
            }
        }
    }
}
