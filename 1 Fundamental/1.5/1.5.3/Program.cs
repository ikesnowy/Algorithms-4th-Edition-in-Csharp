using System;
using UnionFind;

namespace _1._5._3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
            var weightedQuickUnion = new WeightedQuickUnionUF(10);

            foreach (string s in input)
            {
                weightedQuickUnion.ResetArrayCount();
                string[] numbers = s.Split('-');
                int p = int.Parse(numbers[0]);
                int q = int.Parse(numbers[1]);

                weightedQuickUnion.Union(p, q);
                int[] parent = weightedQuickUnion.GetParent();
                for (int i = 0; i < parent.Length; i++)
                {
                    Console.Write(parent[i] + " ");
                }
                Console.WriteLine("数组访问：" + weightedQuickUnion.ArrayParentVisitCount);
            }
        }
    }
}
