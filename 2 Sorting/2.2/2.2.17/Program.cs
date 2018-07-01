using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._17
{
    /*
     * 2.2.17
     * 
     * 链表排序。
     * 实现对链表的自然排序
     * （这是将链表排序的最好方法，
     * 因为它不需要额外的空间且运行时间是线性对数级别的）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<int> a = new LinkedList<int>();
            a.Insert(1);
            a.Insert(2);
            a.Insert(3);
            a.Insert(4);
            a.Insert(5);
            a.Insert(6);
            a.Insert(7);
            a.Insert(8);
            a.Insert(9);
            a.Insert(10);

            MergeSortNatural mergeSort = new MergeSortNatural();
            mergeSort.Sort(a);
            foreach (int i in a)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
    }
}
