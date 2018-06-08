using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._23
{
    /*
     * 2.2.23
     * 
     * 改进。
     * 用实验评估正文中所提到的归并排序的三项改进（请见练习 2.2.11）的效果，
     * 并比较正文中实现的归并排序和练习 2.2.10 所实现的归并排序之间的性能。
     * 根据经验给出应该在何时为子数组切换到插入排序。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MergeSort mergeSort = new MergeSort();
            MergeSortX mergeSortX = new MergeSortX();
            MergeSortUnstable mergeSortUnstable = new MergeSortUnstable();

            int n = 1000000;
            int cutoff = 2;
            int trialTime = 4;
            Console.WriteLine("归并排序改进前与改进后的比较：");
            Console.WriteLine("数组\t耗时1\t耗时2\t阈值\t比率");
            for (int i = 0; i < 20; i++)
            {
                double mergeSortTime = 0;
                double mergeSortXTime = 0;
                mergeSortX.SetCutOff(cutoff);
                for (int j = 0; j < trialTime; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(n);
                    int[] b = new int[a.Length];
                    a.CopyTo(b, 0);
                    mergeSortTime += SortCompare.Time(mergeSort, a);
                    mergeSortXTime += SortCompare.Time(mergeSortX, b);
                }
                mergeSortTime /= trialTime;
                mergeSortXTime /= trialTime;
                Console.WriteLine(n + "\t" + mergeSortTime + "\t" + mergeSortXTime + "\t" + cutoff + "\t" + mergeSortTime / mergeSortXTime);
                cutoff++;
            }

            n = 100000;
            Console.WriteLine("稳定归并排序与不稳定版本的比较：");
            Console.WriteLine("数组\t耗时1\t耗时2\t比率");
            for (int i = 0; i < 6; i++)
            {
                double mergeSortTime = 0;
                double mergeSortUnstableTime = 0;
                for (int j = 0; j < trialTime; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(n);
                    int[] b = new int[a.Length];
                    a.CopyTo(b, 0);
                    mergeSortTime += SortCompare.Time(mergeSort, a);
                    mergeSortUnstableTime += SortCompare.Time(mergeSortUnstable, b);
                }
                mergeSortTime /= trialTime;
                mergeSortUnstableTime /= trialTime;
                Console.WriteLine(n + "\t" + mergeSortTime + "\t" + mergeSortUnstableTime + "\t" + mergeSortTime / mergeSortUnstableTime);
                n *= 2;
            }
        }
    }
}
