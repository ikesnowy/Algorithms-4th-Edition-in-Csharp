using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._16
{
    /*
     * 2.2.16
     * 
     * 自然的归并排序。
     * 编写一个自底向上的归并排序，
     * 当需要将两个子数组排序时能够利用数组中已经有序的部分。
     * 首先找到一个有序的子数组（移动指针直到当前元素比上一个元素小为止），
     * 然后再找出另一个并将它们归并。
     * 根据数组大小和数组中递增子数组的最大长度分析算法的运行时间。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortNatural mergeSort = new MergeSortNatural();

            Console.WriteLine("总长度\t有序\t时间\t比率");
            int maxSorted = 1024;
            int repeatTime = 4;
            double previousTime = 1;
            for (int i = 0; i < 4; i++)
            {
                int n = 131072;
                for (int j = 0; j < 6; j++)
                {
                    double time = 0;
                    for (int k = 0; k < repeatTime; k++)
                    {
                        int[] test = new int[n];
                        int[] unsorted = SortCompare.GetRandomArrayInt(n - maxSorted);
                        int[] sorted = SortCompare.GetRandomArrayInt(maxSorted);
                        Array.Sort(sorted);
                        for (int l = 0; l < n - maxSorted; l++)
                        {
                            test[l] = unsorted[l];
                        }
                        for (int l = 0; l < maxSorted; l++)
                        {
                            test[l + n - maxSorted] = sorted[l];
                        }
                        time += SortCompare.Time(mergeSort, test);
                    }
                    if (j == 0)
                        Console.WriteLine(n + "\t" + maxSorted + "\t" + time / repeatTime + "\t---");
                    else
                        Console.WriteLine(n + "\t" + maxSorted + "\t" + time / repeatTime + "\t" + (time / repeatTime) / previousTime);

                    previousTime = time / repeatTime;
                    n *= 2;
                }
                maxSorted *= 4;
            }

        }
    }
}
