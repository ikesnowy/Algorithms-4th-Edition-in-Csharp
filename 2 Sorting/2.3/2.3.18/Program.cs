using System;
using Quick;

namespace _2._3._18
{
    class Program
    {
        static void Main(string[] args)
        {
            Quick3Way quick = new Quick3Way();
            int arraySize = 10000;                  // 初始数组大小。
            const int trialTimes = 5;               // 每次实验的重复次数。
            const int trialLevel = 10;              // 双倍递增的次数。

            Console.WriteLine("n\ttime\tratio");
            double previousTime = 0;
            for (int i = 0; i < trialLevel; i++)
            {
                double time = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(arraySize);
                    time += SortCompare.Time(quick, a);
                }
                time /= trialTimes;
                if (i == 0)
                    Console.WriteLine(arraySize + "\t" + time + "\t" + "-");
                else
                    Console.WriteLine(arraySize + "\t" + time + "\t" + time / previousTime);
                arraySize *= 2;
                previousTime = time;
            }
        }
    }
}
