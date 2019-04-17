using System;
using UnionFind;

namespace _1._5._12
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var UF = new QuickUnionPathCompressionUF(10);

            // 使用书中提到的最坏情况，0 连 1，1 连 2，2 连 3……
            for (int i = 0; i < 4; i++)
            {
                UF.Union(i, i + 1);
            }

            int[] id = UF.GetParent();
            for (int i = 0; i < id.Length; i++)
            {
                Console.Write(id[i]);
            }
            Console.WriteLine();
        }
    }
}
