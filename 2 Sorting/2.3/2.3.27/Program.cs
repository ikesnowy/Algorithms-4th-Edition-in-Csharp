using System;
using Quick;

namespace _2._3._27
{
    /*
     * 2.3.27
     * 
     * 忽略小数组。
     * 用实验对比以下处理小数组的方法和练习 2.3.25 的处理方法的效果：
     * 在快速排序中直接忽略小数组，仅在快速排序结束后运行一次插入排序。
     * 注意：
     * 可以通过这些实验估计出电脑的缓存大小，
     * 因为当数组大小超出缓存时这种方法的性能可能会下降。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QuickSortInsertion insertion = new QuickSortInsertion();
            QuickSortIgnore ignore = new QuickSortIgnore();
            int arraySize = 20000;                          // 初始数组大小。
            const int mSteps = 1;                           // M 值的递增次数。
            const int trialTimes = 4;                       // 每次实验的重复次数。
            const int trialLevel = 10;                      // 双倍递增的次数。

            Console.WriteLine("M\tn\t\tignore\tinsert\tratio");
            for (int i = 0; i < mSteps; i++)
            {
                int array = arraySize;
                for (int j = 0; j < trialLevel; j++)
                {
                    double timeIgnore = 0;
                    double timeInsertion = 0;
                    for (int k = 0; k < trialTimes; k++)
                    {
                        int[] a = SortCompare.GetRandomArrayInt(array);
                        int[] b = new int[a.Length];
                        a.CopyTo(b, 0);
                        timeInsertion += SortCompare.Time(insertion, b);
                        timeIgnore += SortCompare.Time(ignore, a);

                    }
                    timeIgnore /= trialTimes;
                    timeInsertion /= trialTimes;
                    if (arraySize < 10000000)
                        Console.WriteLine(ignore.M + "\t" + array + "\t\t" + timeIgnore + "\t" + timeInsertion + "\t" + timeIgnore / timeInsertion);
                    else
                        Console.WriteLine(ignore.M + "\t" + array + "\t" + timeIgnore + "\t" + timeInsertion + "\t" + timeIgnore / timeInsertion);
                    array *= 2;
                }
                ignore.M++;
            }
        }
    }
}
