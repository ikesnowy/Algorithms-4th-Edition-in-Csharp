using System;
using Sort;
using System.Diagnostics;

namespace _2._1._30
{
    
    class Program
    {
        // t = 2, 3, 4
        // t 大于 10 之后，由于每次排序 h 缩减的太快，
        // 时间会越来越近似于直接插入排序。
        static void Main(string[] args)
        {
            int[] array = SortCompare.GetRandomArrayInt(1000000);
            int[] array2 = new int[array.Length];
            array.CopyTo(array2, 0);
            Stopwatch timer = new Stopwatch();

            long[] bestTimes = new long[3];
            long[] bestTs = new long[3];
            for (int i = 0; i < bestTimes.Length; i++)
            {
                bestTimes[i] = long.MaxValue;
                bestTs[i] = int.MaxValue;
            }

            long nowTime = 0;
            ShellSort shellSort = new ShellSort();

            for (int t = 2; t <= 1000000; t++)
            {
                Console.WriteLine(t);
                
                timer.Restart();
                shellSort.Sort(array, t);
                nowTime = timer.ElapsedMilliseconds;
                timer.Stop();
                Console.WriteLine("Elapsed Time:" + nowTime);
                for (int i = 0; i < bestTimes.Length; i++)
                {
                    Console.Write("t:" + bestTs[i]);
                    Console.WriteLine("\tTime:" + bestTimes[i]);
                }
                if (bestTimes[2] > nowTime)
                {
                    bestTimes[2] = nowTime;
                    bestTs[2] = t;
                    Array.Sort(bestTimes, bestTs);
                }

                array2.CopyTo(array, 0);
            }

            for (int i = 0; i < bestTimes.Length; i++)
            {
                Console.Write("t:" + bestTs[i]);
                Console.Write("\tTime:" + bestTimes[i]);
            }
        }
    }
}
