namespace UnionFind
{
    /// <summary>
    /// 使用加权 quick-union 算法的并查集。
    /// </summary>
    public class WeightedQuickUnionUF : QuickUnionUF
    {
        protected int[] size; // 记录各个树的大小。

        public int ArrayParentVisitCount { get; private set; } // 记录 parent 数组的访问次数。
        public int ArraySizeVisitCount { get; private set; } //记录 size 数组的访问次数。

        /// <summary>
        /// 建立使用加权 quick-union 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public WeightedQuickUnionUF(int n) : base(n)
        {
            this.size = new int[n];
            for (int i = 0; i < n; i++)
            {
                this.size[i] = 1;
            }
            this.ArrayParentVisitCount = 0;
            this.ArraySizeVisitCount = 0;
        }

        /// <summary>
        /// 清零数组访问计数。
        /// </summary>
        public override void ResetArrayCount()
        {
            this.ArrayParentVisitCount = 0;
            this.ArraySizeVisitCount = 0;
        }

        /// <summary>
        /// 获取 size 数组。
        /// </summary>
        /// <returns>返回 size 数组。</returns>
        public int[] GetSize()
        {
            return this.size;
        }

        /// <summary>
        /// 寻找一个结点所在的连通分量。
        /// </summary>
        /// <param name="p">需要寻找的结点。</param>
        /// <returns>该结点所属的连通分量。</returns>
        public override int Find(int p)
        {
            Validate(p);
            while (p != this.parent[p])
            {
                p = this.parent[p];
                this.ArrayParentVisitCount += 2;
            }
            this.ArrayParentVisitCount++;
            return p;
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
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
            this.ArrayParentVisitCount++;
            this.ArraySizeVisitCount += 4;
            this.count--;
        }
    }
}
