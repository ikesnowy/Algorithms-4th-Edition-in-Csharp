﻿using System;
using Sort;

namespace _2._1._22
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Transaction[] a = new Transaction[4];

            // 样例输入  
            // Turing 6/17/1990 644.08
            // Tarjan 3/26/2002 4121.85
            // Knuth 6/14/1999 288.34
            // Dijkstra 8/22/2007 2678.40

            for (int i = 0; i < a.Length; i++)
            {
                string input = Console.ReadLine();
                a[i] = new Transaction(input);
            }

            InsertionSort insertionSort = new InsertionSort();

            Console.WriteLine("Unsorted");
            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine(a[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Sort by date");
            insertionSort.Sort(a, new Transaction.WhenOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();

            Console.WriteLine("Sort by customer");
            insertionSort.Sort(a, new Transaction.WhoOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();

            Console.WriteLine("Sort by amount");
            insertionSort.Sort(a, new Transaction.HowMuchOrder());
            for (int i = 0; i < a.Length; i++)
                Console.WriteLine(a[i]);
            Console.WriteLine();
        }
    }
}
