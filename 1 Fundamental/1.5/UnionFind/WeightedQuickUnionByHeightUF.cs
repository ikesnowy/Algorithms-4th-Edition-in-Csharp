namespace UnionFind
{
    /// <summary>
    /// 按照高度加权的 Quick-Union 并查集。
    /// </summary>
    public class WeightedQuickUnionByHeightUF : QuickUnionUF
    {
        private int[] height;

        /// <summary>
        /// 新建一个以高度作为判断依据的加权 quick-union 并查集。
        /// </summary>
        /// <param name="n">新建并查集的大小。</param>
        public WeightedQuickUnionByHeightUF(int n) : base(n)
        {
            this.height = new int[n];
            for (var i = 0; i < n; i++)
            {
                this.height[i] = 0;
            }
        }

        /// <summary>
        /// 将两个结点所属的连通分量合并。
        /// </summary>
        /// <param name="p">需要合并的结点。</param>
        /// <param name="q">需要合并的另一个结点。</param>
        public override void Union(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);

            if (rootP == rootQ)
            {
                return;
            }

            if (this.height[rootP] < this.height[rootQ])
            {
                this.parent[rootP] = rootQ;
            }
            else if (this.height[rootP] > this.height[rootQ])
            {
                this.parent[rootQ] = rootP;
            }
            else
            {
                this.parent[rootQ] = rootP;
                this.height[rootP]++;
            }
            this.count--;
        }
    }
}
