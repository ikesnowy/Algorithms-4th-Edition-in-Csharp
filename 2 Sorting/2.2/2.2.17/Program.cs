using System;

namespace _2._2._17
{
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
