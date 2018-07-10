using System;

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
            QuickSort sort = new QuickSort();
            int[] a = new int[98];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = 1;
            }
            sort.Sort(a);
            Console.WriteLine(sort.CN);
        }
    }
}
