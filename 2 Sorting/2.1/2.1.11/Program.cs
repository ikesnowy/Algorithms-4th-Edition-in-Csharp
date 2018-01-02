using System;

namespace _2._1._11
{
    /*
     * 2.1.11
     * 
     * 将希尔排序中实时计算递增序列改为预先计算并存储在一个数组中。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            ShellSort shellSort = new ShellSort();
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 10 - i;
            }
            shellSort.Sort(array);
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
