using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._4._16
{
    /*
     * 2.4.16
     * 
     * 对于 N=32，构造数组使得堆排序使用的比较次数最多以及最少。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 最好情况
            // 比较简单，键值完全相同的数组即可。
            // 最坏情况
            // 

            int[] a = { 11, 8, 7, 6, 5, 4, 3, 2, 1 };
            PriorityQueue.Heap.Sort(a);
            foreach (int i in a)
                Console.Write(i + " ");
            Console.WriteLine();
        }
    }
}
