using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sort;

namespace _2._1._21
{
    /*
     * 2.1.21
     * 
     * 可比较的交易。
     * 用我们的 Date 类（请见 2.1.1.4 节）
     * 作为模板扩展你的 Transaction 类（请见练习 1.2.13），
     * 实现 Comparable 接口，使交易能够按照金额排序。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Transaction[] a = new Transaction[4];
            a[0] = new Transaction("Turing 6/17/1990 644.08");
            a[1] = new Transaction("Tarjan 3/26/2002 4121.85");
            a[2] = new Transaction("Knuth 6/14/1999 288.34");
            a[3] = new Transaction("Dijkstra 8/22/2007 2678.40");

            Console.WriteLine("Unsorted");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Sort by amount");
            InsertionSort insertionSort = new InsertionSort();
            insertionSort.Sort(a, new Transaction.HowMuchOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();
        }
    }
}
