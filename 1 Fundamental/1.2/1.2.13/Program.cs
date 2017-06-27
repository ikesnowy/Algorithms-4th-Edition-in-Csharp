using System;
using Commercial;

namespace _1._2._13
{
    /*
     * 1.2.13
     * 
     * 用我们对 Date 的实现（请见表 1.2.12）作为模板实现 Transaction 类型。
     * 
     */
    class Program
    {
        //见 Commercial.Transaction
        static void Main(string[] args)
        {
            Transaction[] a = new Transaction[4];
            a[0] = new Transaction("Turing 6/17/1990 644.08");
            a[1] = new Transaction("Tarjan 3/26/2002 4121.85");
            a[2] = new Transaction("Knuth 6/14/1999 288.34");
            a[3] = new Transaction("Dijkstra 8/22/2007 2678.40");

            Console.WriteLine("Unsorted");
            for (int i = 0; i < a.Length; ++i)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Sort by date");
            Array.Sort(a, new Transaction.WhenOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();

            Console.WriteLine("Sort by customer");
            Array.Sort(a, new Transaction.WhoOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();

            Console.WriteLine("Sort by amount");
            Array.Sort(a, new Transaction.HowMuchOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();
        }
    }
}
