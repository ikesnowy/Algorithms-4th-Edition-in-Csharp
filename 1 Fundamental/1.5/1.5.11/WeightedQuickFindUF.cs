using System;

namespace _1._5._11
{
    /// <summary>
    /// 用加权 QuickFind 算法实现的并查集。
    /// </summary>
    public class WeightedQuickFindUF
    {
        private int[] size; // 记录每个连通分量的大小。
        private int[] id; // 记录每个结点的连通分量。
        private int count;// 连通分量总数。

        public int ArrayVisitCount { get; private set; } //记录数组访问的次数。

        /// <summary>
        /// 新建一个使用加权 quick-find 实现的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public WeightedQuickFindUF(int n)
        {
            this.count = n;
            this.id = new int[n];
            this.size = new int[n];
            for (var i = 0; i < n; i++)
            {
                this.id[i] = i;
                this.size[i] = 1;
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
            var pID = this.id[p];
            var qID = this.id[q];
            this.ArrayVisitCount += 2;

            // 如果两个结点同属于一个连通分量，那么什么也不做。
            if (pID == qID)
            {
                return;
            }

            // 判断较大的连通分量和较小的连通分量。
            var larger = 0;
            var smaller = 0;
            if (this.size[pID] > this.size[qID])
            {
                larger = pID;
                smaller = qID;
                this.size[pID] += this.size[qID];
            }
            else
            {
                larger = qID;
                smaller = pID;
                this.size[qID] += this.size[pID];
            }

            // 将较小的连通分量连接到较大的连通分量上，
            // 这会减少赋值语句的执行次数，略微减少数组访问。
            for (var i = 0; i < this.id.Length; i++)
            {
                if (this.id[i] == smaller)
                {
                    this.id[i] = larger;
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
            var n = this.id.Length;
            if (p < 0 || p > n)
            {
                throw new ArgumentException("index " + p + " is not between 0 and " + (n - 1));
            }
        }
    }
}
