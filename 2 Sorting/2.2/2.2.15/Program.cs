using System;

namespace _2._2._15
{
    /*
     * 2.2.15
     * 
     * 自底向上的有序队列归并排序。
     * 用下面的方法编写一个自底向上的归并排序：
     * 给定 N 个元素，创建 N 个队列，每个队列包含其中一个元素。
     * 创建一个由这 N 个队列组成的队列，
     * 然后不断用练习 2.2.14 中的方法将队列的头两个元素归并，
     * 并将结果重新加入到队列结尾，
     * 直到队列的队列只剩下一个元素为止。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            MergeSortQueue mergeSort = new MergeSortQueue();
            mergeSort.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
