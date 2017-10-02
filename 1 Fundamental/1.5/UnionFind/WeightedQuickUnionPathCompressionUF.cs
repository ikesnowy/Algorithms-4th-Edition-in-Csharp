using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    /// <summary>
    /// 使用路径压缩的加权 quick-union 并查集。
    /// </summary>
    public class WeightedQuickUnionPathCompressionUF : WeightedQuickUnionUF
    {
        private int[] size;     // 记录连接至该结点的节点数量。

        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public WeightedQuickUnionPathCompressionUF(int n) : base(n)
        {
            this.size = new int[n];

            for (int i = 0; i < n; ++i)
            {
                this.size[i] = 1;
            }
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            int root = p;
            while (root != this.parent[p])
            {
                root = this.parent[p];
            }
            while (p != root)
            {
                int newP = this.parent[p];
                this.parent[p] = root;
                p = newP;
            }
            return root;
        }
    }
}
