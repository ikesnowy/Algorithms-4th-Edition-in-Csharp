using System;

namespace _1._4._12
{
    /*
     * 1.4.12
     * 
     * 编写一个程序，有序打印给定的两个有序数组（含有 N 个 int 值） 中的所有公共元素，
     * 程序在最坏情况下所需的运行时间应该和 N 成正比。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[4] { 2, 3, 4, 10 };
            int[] b = new int[6] { 1, 3, 3, 5, 10, 11 };

            // 2N 次数组访问，数组 a 和数组 b 各遍历一遍
            for (int i = 0, j = 0; i < a.Length && j < b.Length; )
            {
                if (a[i] < b[j])
                {
                    i++;
                }
                else if (a[i] > b[j])
                {
                    j++;
                }
                else
                {
                    Console.WriteLine($"Common Element:{a[i]}, First index: (a[{i}], b[{j}])");
                    i++;
                    j++;
                }
            }

        }
    }
}
