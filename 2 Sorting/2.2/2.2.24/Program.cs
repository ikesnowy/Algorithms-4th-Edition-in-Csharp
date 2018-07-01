using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._24
{
    /*
     * 2.2.24
     * 
     * 改进的有序测试。
     * 在实验中用大型随机数组评估练习 2.2.8 所做的修改的效果。
     * 根据经验用 N（被排序的原始数组的大小）的函数描述条件语句
     * （a[mid] <= a[mid + 1]）成立（无论数组是否有序）的次数。
     * 
     */
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
