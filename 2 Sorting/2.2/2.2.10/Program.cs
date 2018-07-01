using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._10
{
    /*
     * 2.2.10
     * 
     * 快速归并。
     * 实现一个 merge() 方法，按降序将 a[] 的后半部分复制到 aux[]，
     * 然后将其归并回 a[] 中。
     * 这样就可以去掉内循环中检测某半边是否用尽的代码。
     * 注意：这样的排序产生的结果是不稳定的（请见 2.5.1.8 节）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 2, 4, 6, 8, 10, 1, 3, 5, 7 };
            MergeSort merge = new MergeSort();
            merge.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
