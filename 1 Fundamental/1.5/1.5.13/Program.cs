using System;
using UnionFind;

namespace _1._5._13
{
    class Program
    {
        static void Main(string[] args)
        {
            var UF = new WeightedQuickUnionPathCompressionUF(10);

            // 见中文版 P146 或英文版 P229 中加权 quick-union 的最坏输入。
            UF.Union(0, 1);
            UF.Union(2, 3);
            UF.Union(4, 5);
            UF.Union(6, 7);
            UF.Union(0, 2);
            UF.Union(4, 6);
            UF.Union(0, 4);

            var id = UF.GetParent();
            for (var i = 0; i < id.Length; i++)
            {
                Console.Write(id[i]);
            }
            Console.WriteLine();
        }
    }
}
