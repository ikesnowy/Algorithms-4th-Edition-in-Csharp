using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Merge;

namespace _2._2._11
{
    /*
     * 2.2.11
     * 
     * 改进。
     * 实现 2.2.2 节所述的对归并排序的三项改进：
     * 加快小数组的排序速度，
     * 检测数组是否已经有序以及通过在递归中交换参数来避免复制。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MergeSortX mergeSortX = new MergeSortX();
            int[] a = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            mergeSortX.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
