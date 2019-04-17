using System;
using Quick;

namespace _2._3._5
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Sort2Distinct sort2Distinct = new Sort2Distinct();
            int[] a = new int[] { 2, 1, 2, 2, 1, 2, 1, 2, 1, 1 };
            sort2Distinct.Sort(a);
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine();
        }
    }
}
