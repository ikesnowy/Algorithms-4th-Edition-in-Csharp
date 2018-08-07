using System;
using Quick;

namespace _2._3._16
{
    /*
     * 2.3.16
     * 
     * 最佳情况。
     * 编写一段程序来生成使算法 2.5 中的 sort() 方法表现最佳的数组（无重复元素）：
     * 数组大小为 N 且不包含重复元素，
     * 每次切分后两个子数组的大小最多差 1
     * （子数组的大小与含有 N 个相同元素的数组的切分情况相同）。
     * （对于这道练习，我们不需要在排序开始时打乱数组。）
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QuickSortAnalyze quick = new QuickSortAnalyze
            {
                NeedShuffle = false,            // 关闭打乱
                NeedPath = true                 // 显示排序轨迹
            };
            int[] a = QuickBest.Best(10);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
            quick.Sort(a);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
