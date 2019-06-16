using System;
using UnionFind;

namespace _1._5._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
            var quickFind = new QuickFindUF(10);

            foreach (string s in input)
            {
                quickFind.ResetArrayCount();

                string[] numbers = s.Split('-');
                int p = int.Parse(numbers[0]);
                int q = int.Parse(numbers[1]);

                int[] id = quickFind.GetParent();
                quickFind.Union(p, q);
                foreach (int root in id)
                {
                    Console.Write(root + " ");
                }
                Console.WriteLine("数组访问：" + quickFind.ArrayVisitCount);
            }
        }
    }
}
