using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._11
{
    /*
     * 1.5.11
     * 
     * 实现加权 quick-find 算法，其中我们总是将较小的分量重命名为较大分量的标识符。
     * 这种改变会对性能产生怎样的影响？
     * 
     */
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
            for (int i = 1; i < size; ++i)
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
