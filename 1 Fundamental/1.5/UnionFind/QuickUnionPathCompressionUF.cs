using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    /// <summary>
    /// 使用路径压缩的 quick-union 并查集。
    /// </summary>
    public class QuickUnionPathCompressionUF : UF
    {
        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public QuickUnionPathCompressionUF(int n) : base(n) { }

        /// <summary>
        /// 获得 parent 数组。
        /// </summary>
        /// <returns>返回 parent 数组。</returns>
        public int[] GetParent()
        {
            return this.parent;
        }

        /// <summary>
        /// 寻找结点所属的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            int root = p;
            while (root != this.parent[root])
            {
                root = this.parent[root];
            }
            while (p != root)
            {
                int newp = this.parent[p];
                this.parent[p] = root;
                p = newp;
            }
            return p;
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的第一个结点。</param>
        /// <param name="q">需要合并的第二个结点。</param>
        public override void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }
            this.parent[rootP] = rootQ;
            this.count--;
        }
    }
}
