using System;
using UnionFind;

namespace _1._5._11
{
    
    class Program
    {
        static void Main(string[] args)
        {
            char[] split = { '\n', '\r' };
            string[] input = TestCase.Properties.Resources.mediumUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int size = int.Parse(input[0]);

            QuickFindUF quickFind = new QuickFindUF(size);
            WeightedQuickFindUF weightedQuickFind = new WeightedQuickFindUF(size);

            int p, q;
            string[] pair;
            for (int i = 1; i < size; i++)
            {
                pair = input[i].Split(' ');
                p = int.Parse(pair[0]);
                q = int.Parse(pair[1]);
                quickFind.Union(p, q);
                weightedQuickFind.Union(p, q);
            }

            Console.WriteLine("quick-find: " + quickFind.ArrayVisitCount);
            Console.WriteLine("weighted quick-find: " + weightedQuickFind.ArrayVisitCount);
        }
    }
}
