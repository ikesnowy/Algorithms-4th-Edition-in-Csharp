using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    /// <summary>
    /// 用 QuickFind 算法实现的并查集。
    /// </summary>
    public class QuickFindUF : UF
    {
        public int ArrayVisitCount { get; private set; } //记录数组访问的次数。

        /// <summary>
        /// 新建一个使用 quick-find 实现的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public QuickFindUF(int n) : base(n) { }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public void ResetArrayCount()
        {
            this.ArrayVisitCount = 0;
        }
        
        /// <summary>
        /// 寻找 p 所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>返回 p 所在的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            this.ArrayVisitCount++;
            return this.parent[p];
        }

        /// <summary>
        /// 判断两个结点是否属于同一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>如果属于同一个连通分量则返回 true，否则返回 false。</returns>
        public override bool IsConnected(int p, int q)
        {
            Validate(p);
            Validate(q);
            this.ArrayVisitCount += 2;
            return this.parent[p] == this.parent[q];
        }

        /// <summary>
        /// 将两个结点所在的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
        {
            Validate(p);
            Validate(q);
            int pID = this.parent[p];
            int qID = this.parent[q];
            this.ArrayVisitCount += 2;

            // 如果两个结点同属于一个连通分量，那么什么也不做。
            if (pID == qID)
            {
                return;
            }

            for (int i = 0; i < this.parent.Length; ++i)
            {
                if (this.parent[i] == pID)
                {
                    this.parent[i] = qID;
                    this.ArrayVisitCount++;
                }
            }

            this.ArrayVisitCount += this.parent.Length;
            this.count--;
            return;
        }

        /// <summary>
        /// 获得 parent 数组。
        /// </summary>
        /// <returns>id 数组。</returns>
        public int[] GetParent()
        {
            return this.parent;
        }
    }
}
