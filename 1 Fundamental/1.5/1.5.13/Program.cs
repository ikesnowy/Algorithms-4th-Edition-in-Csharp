using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._13
{
    /*
     * 1.5.13
     * 
     * 使用路径压缩的加权 quick-union 算法。
     * 修改加权 quick-union 算法（算法 1.5），
     * 实现如练习 1.5.12 所述的路径压缩。给出一列输入，
     * 使该方法能产生一棵高度为 4 的树。
     * 注意：该算法的所有操作的均摊成本已知被限制在反 Ackermann 函数的范围之内，
     * 且对于实际应用中可能出现的所有 N 值均小于 5。
     * 
     */
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

            int[] id = UF.GetParent();
            for (int i = 0; i < id.Length; ++i)
            {
                Console.Write(id[i]);
            }
            Console.WriteLine();
        }
    }
}
