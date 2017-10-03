using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._3
{
    /*
     * 1.5.3
     * 
     * 使用加权 quick-union 算法（请见算法 1.5）完成练习 1.5.1 。
     * 
     */
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
                for (int i = 0; i < parent.Length; ++i)
                {
                    if (parent[i] == i)
                    {
                        Console.WriteLine("|---- " + i);
                        DFS(parent, i, 1);
                    }
                }
                Console.WriteLine("数组访问：" + weightedQuickUnion.ArrayParentVisitCount);
            }
        }

        static void DFS(int[] parent, int root, int level)
        {
            for (int i = 0; i < parent.Length; ++i)
            {
                if (parent[i] == root && i != root)
                {
                    for (int j = 0; j < level; ++j)
                    {
                        Console.Write("    ");
                    }
                    Console.WriteLine("|---- " + i);
                    DFS(parent, i, level + 1);
                }
            }
        }
    }
}
