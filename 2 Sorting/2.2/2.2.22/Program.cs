using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._22
{
    /*
     * 2.2.22
     * 
     * 三向归并排序。
     * 假设每次我们是把数组分成三个部分而不是两个部分并将它们分别排序。
     * 然后进行三向归并。
     * 这种算法的运行时间的增长数量级是多少。
     * 
     */
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
