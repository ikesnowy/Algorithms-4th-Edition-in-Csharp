using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._2
{
    /*
     * 1.5.2
     * 
     * 使用 quick-union 算法（请见 1.5.2.3 节代码框）完成练习 1.5.1。
     * 另外，在处理完输入的每对整数之后画出 id[] 数组表示的森林。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
            var quickUnion = new QuickUnionUF(10);

            foreach (string s in input)
            {
                quickUnion.ResetArrayCount();
                string[] numbers = s.Split('-');
                int p = int.Parse(numbers[0]);
                int q = int.Parse(numbers[1]);

                quickUnion.Union(p, q);
                int[] parent = quickUnion.GetParent();
                for (int i = 0; i < parent.Length; ++i)
                {
                    if (parent[i] == i)
                    {
                        Console.WriteLine("|---- " + i);
                        DFS(parent, i, 1);
                    }
                }
                Console.WriteLine("数组访问：" + quickUnion.ArrayVisitCount);
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
