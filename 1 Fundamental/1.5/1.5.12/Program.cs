using System;
using UnionFind;

namespace _1._5._12
{
    /*
     * 1.5.12
     * 
     * 使用路径压缩的 quick-union 算法。
     * 根据路径压缩修改 quick-union 算法（请见 1.5.2.3 节），
     * 在 find() 方法中添加一个循环来将从 p 到根节点的路径上的每个触点都连接到根节点。
     * 给出一列输入，使该方法能够产生一条长度为 4 的路径。
     * 注意：该算法的所有操作的均摊成本已知为对数级别。
     * 
     */
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
