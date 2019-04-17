using System;
using Quick;

namespace _2._3._22
{
    
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickNormal = new QuickSort();
            QuickBentleyMcIlroy quickBentleyMcIlroy = new QuickBentleyMcIlroy();
            int arraySize = 800000;                         // 初始数组大小。
            const int trialTimes = 1;                       // 每次实验的重复次数。
            const int trialLevel = 8;                       // 双倍递增的次数。

            Console.WriteLine("n\t\t3way\tnormal\tratio");
            for (int i = 0; i < trialLevel; i++)
            {
                double timeBentleyMcIlroy = 0;
                double timeNormal = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(arraySize);
                    int[] b = new int[a.Length];
                    a.CopyTo(b, 0);
                    timeNormal += SortCompare.Time(quickNormal, b);
                    timeBentleyMcIlroy += SortCompare.Time(quickBentleyMcIlroy, a);

                }
                timeBentleyMcIlroy /= trialTimes;
                timeNormal /= trialTimes;
                if (arraySize < 10000000)
                    Console.WriteLine(arraySize + "\t\t" + timeBentleyMcIlroy + "\t" + timeNormal + "\t" + timeBentleyMcIlroy / timeNormal);
                else
                    Console.WriteLine(arraySize + "\t" + timeBentleyMcIlroy + "\t" + timeNormal + "\t" + timeBentleyMcIlroy / timeNormal);
                arraySize *= 2;
            }
        }
    }
}
