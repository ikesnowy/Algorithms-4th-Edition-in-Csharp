using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._19
{
    /*
     * 2.2.19
     * 
     * 倒置。
     * 编写一个线性对数级别的算法统计给定数组中「倒置」数量
     * （即插入排序所需的交换次数，请见 2.1 节）。
     * 这个数量和 Kendall tau 距离有关，请见 2.5 节。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[] { 1, 3, 5, 7, 2, 0 };
            MergeSort mergeSort = new MergeSort();
            mergeSort.Sort(a);
            Console.WriteLine(mergeSort.Counter);
        }
    }
}
