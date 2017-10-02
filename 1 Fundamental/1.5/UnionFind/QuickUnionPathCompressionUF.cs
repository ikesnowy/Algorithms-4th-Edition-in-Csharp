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
    public class QuickUnionPathCompressionUF
    {
        private int[] id;   // 记录各结点的上一级结点。
        private int count;  // 记录并查集中独立的连通分量总数。

        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public QuickUnionPathCompressionUF(int n)
        {
            this.id = new int[n];
            this.count = n;
            for (int i = 0; i < n; ++i)
            {
                this.id[i] = i;
            }
        }

        /// <summary>
        /// 返回并查集连通分量的数目。
        /// </summary>
        /// <returns>并查集连通分量的数目。</returns>
        public int Count()
        {
            return this.count;
        }

        /// <summary>
        /// 获得 id 数组。
        /// </summary>
        /// <returns>返回 id 数组。</returns>
        public int[] GetId()
        {
            return this.id;
        }

        /// <summary>
        /// 寻找结点所属的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>结点所属的连通分量。</returns>
        public int Find(int p)
        {
            int root = p;
            while (root != this.id[root])
            {
                root = this.id[root];
            }
            while (p != root)
            {
                int newp = this.id[p];
                this.id[p] = root;
                p = newp;
            }
            return p;
        }

        /// <summary>
        /// 检查两个结点是否同属于一个连通分量。
        /// </summary>
        /// <param name="p">需要检查的结点。</param>
        /// <param name="q">需要检查的另一个结点。</param>
        /// <returns>如果同属于一个连通分量，返回 true，否则返回 false。</returns>
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的第一个结点。</param>
        /// <param name="q">需要合并的第二个结点。</param>
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }
            this.id[rootP] = rootQ;
            this.count--;
        }
    }
}
