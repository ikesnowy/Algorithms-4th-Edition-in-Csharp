using System;
using Sort;
using System.Diagnostics;

namespace _2._1._30
{
    /*
     * 2.1.30
     * 
     * 几何级数递增序列。
     * 通过实验找到一个 t，使得对于大小为 N=10^6 的任意随机数组，
     * 使用递增序列 1, [t], [t^2], [t^3], [t^4], ... 的希尔排序的运行时间最短。
     * 给出你能找到的三个最佳 t 值以及相应的递增序列。
     * 以下练习描述的是各种用于评估排序算法的测试用例。
     * 它们的作用是用随机数据帮助你增进对性能特性的理解。
     * 随着命令行指定的实验测试的增大，
     * 可以和 SortCompare 一样在它们中使用 time() 函数来得到更精确的结果。
     * 在以后的几节中我们会使用这些练习来评估更为复杂的算法。
     * 
     */
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
