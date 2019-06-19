using System;
using UnionFind;

namespace _1._5._11
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] split = { '\n', '\r' };
            var input = TestCase.Properties.Resources.mediumUF.Split(split, StringSplitOptions.RemoveEmptyEntries);
            var size = int.Parse(input[0]);

            var quickFind = new QuickFindUF(size);
            var weightedQuickFind = new WeightedQuickFindUF(size);

            int p, q;
            string[] pair;
            for (var i = 1; i < size; i++)
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
