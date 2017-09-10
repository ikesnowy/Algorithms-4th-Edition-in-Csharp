using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    /// <summary>
    /// 使用加权 quick-union 算法的并查集。
    /// </summary>
    public class WeightedQuickUnionUF
    {
        private int[] parent; // 记录各结点的上一级结点。
        private int[] size; // 记录各个树的大小。
        private int count; // 记录连通分量的数目。

        public int ArrayVisitCount { get; private set; } // 记录数组的访问次数。

        /// <summary>
        /// 建立使用加权 quick-union 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public WeightedQuickUnionUF(int n)
        {
            this.count = n;
            this.parent = new int[n];
            this.size = new int[n];
            for (int i = 0; i < n; ++i)
            {
                this.parent[i] = i;
                this.size[i] = 1;
            }
        }

        /// <summary>
        /// 清零数组访问计数。
        /// </summary>
        public void ResetArrayCount()
        {
            this.ArrayVisitCount = 0;
        }

        /// <summary>
        /// 获得 parent 数组。
        /// </summary>
        /// <returns>返回 parent 数组。</returns>
        public int[] GetParent()
        {
            return this.parent;
        }

        /// <summary>
        /// 返回并查集中连通分量的数目。
        /// </summary>
        /// <returns>连通分量的数目。</returns>
        public int Count()
        {
            return this.count;
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public int Find(int p)
        {
            Validate(p);
            while (p != this.parent[p])
            {
                p = this.parent[p];
                this.ArrayVisitCount += 2;
            }
            this.ArrayVisitCount++;
            return p;
        }

        /// <summary>
        /// 两个结点是否同属于一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>如果属于同一个连通分量则返回 true，否则返回 false。</returns>
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ)
            {
                return;
            }

            if (this.size[rootP] < this.size[rootQ])
            {
                this.parent[rootP] = rootQ;
                this.size[rootQ] += this.size[rootP];
            }
            else
            {
                this.parent[rootQ] = rootP;
                this.size[rootP] += this.size[rootQ];
            }
            this.ArrayVisitCount++;
            this.count--;
        }

        /// <summary>
        /// 验证结点是否有效。
        /// </summary>
        /// <param name="p">需要验证的结点。</param>
        private void Validate(int p)
        {
            int n = this.parent.Length;
            if (p < 0 || p >= n)
            {
                throw new ArgumentException("index " + p + " is not between 0 and " + (n - 1));
            }
        }
    }
}
