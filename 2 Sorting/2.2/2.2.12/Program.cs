using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._12
{
    /*
     * 2.2.12
     * 
     * 次线性的额外空间。
     * 用大小 M 的数组分为 N/M 块（简单起见，设 M 是 N 的约数）。
     * 实现一个归并方法，使之所需的额外空间减少到 max(M, N/M)：
     * （i）可以先将一个块看作一个元素，将块的第一个元素作为块的主键，用选择排序将块排序；
     * （ii）遍历数组，将第一块和第二块归并，完成后将第二块和第三块归并，等等。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 中文版的翻译比较难理解
            // 实际上就是另一种归并排序的实现方式
            // 先把数组分成若干个大小为 M 的块
            // 对于每个块，用选择排序进行排序
            // 随后遍历数组，将各个块归并起来
            int[] a = new int[] { 1, 3, 5, 7, 9, 2, 4, 6, 8 };
            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(a, 3);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
