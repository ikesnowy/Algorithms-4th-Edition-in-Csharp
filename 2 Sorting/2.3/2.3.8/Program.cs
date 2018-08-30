using System;
using Quick;

namespace _2._3._8
{
    /*
     * 2.3.8
     * 
     * Quick.sort() 在处理 N 个全部重复的元素时大约需要多少次比较？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 约为 NlogN 次
            QuickSortAnalyze sort = new QuickSortAnalyze();
            int N = 100;
            Console.WriteLine("N\tCompare\tNlogN");
            for (int i = 0; i < 4; i++)
            {
                int[] a = new int[N];
                for (int j = 0; j < a.Length; j++)
                {
                    a[j] = 1;
                }
                sort.Sort(a);
                Console.WriteLine(N + "\t" + sort.CompareCount + "\t" + N * Math.Log(N) / Math.Log(2));
                N *= 10;
            }
            
        }
    }
}
