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
    public class QuickFindUF
    {
        private int[] id; // 记录每个结点的连通分量。
        private int count;// 连通分量总数。

        public int ArrayVisitCount { get; private set; } //记录数组访问的次数。

        /// <summary>
        /// 新建一个使用 quick-find 实现的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public QuickFindUF(int n)
        {
            this.count = n;
            this.id = new int[n];
            for (int i = 0; i < n; ++i)
            {
                this.id[i] = i;
            }
        }

        /// <summary>
        /// 重置数组访问计数。
        /// </summary>
        public void ResetArrayCount()
        {
            this.ArrayVisitCount = 0;
        }

        /// <summary>
        /// 表示并查集中连通分量的数量。
        /// </summary>
        /// <returns>返回并查集中连通分量的数量。</returns>
        public int Count()
        {
            return this.count;
        }
        
        /// <summary>
        /// 寻找 p 所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>返回 p 所在的连通分量。</returns>
        public int Find(int p)
        {
            Validate(p);
            this.ArrayVisitCount++;
            return this.id[p];
        }

        /// <summary>
        /// 判断两个结点是否属于同一个连通分量。
        /// </summary>
        /// <param name="p">需要判断的结点。</param>
        /// <param name="q">需要判断的另一个结点。</param>
        /// <returns>如果属于同一个连通分量则返回 true，否则返回 false。</returns>
        public bool IsConnected(int p, int q)
        {
            Validate(p);
            Validate(q);
            this.ArrayVisitCount += 2;
            return this.id[p] == this.id[q];
        }

        /// <summary>
        /// 将两个结点所在的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public void Union(int p, int q)
        {
            Validate(p);
            Validate(q);
            int pID = this.id[p];
            int qID = this.id[q];
            this.ArrayVisitCount += 2;

            // 如果两个结点同属于一个连通分量，那么什么也不做。
            if (pID == qID)
            {
                return;
            }

            for (int i = 0; i < this.id.Length; ++i)
            {
                if (this.id[i] == pID)
                {
                    this.id[i] = qID;
                    this.ArrayVisitCount++;
                }
            }

            this.ArrayVisitCount += this.id.Length;
            this.count--;
            return;
        }

        /// <summary>
        /// 获得 id 数组。
        /// </summary>
        /// <returns>id 数组。</returns>
        public int[] GetID()
        {
            return this.id;
        }

        /// <summary>
        /// 验证输入的结点是否有效。
        /// </summary>
        /// <param name="p">需要验证的结点。</param>
        /// <exception cref="ArgumentException">输入的 p 值无效。</exception>
        private void Validate(int p)
        {
            int n = this.id.Length;
            if (p < 0 || p > n)
            {
                throw new ArgumentException("index " + p + " is not between 0 and " + (n - 1));
            }
        }
    }
}
