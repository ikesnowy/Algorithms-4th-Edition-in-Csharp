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
    public class WeightedQuickUnionPathCompressionUF : UF
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


        public override int Find(int p)
        {
            throw new NotImplementedException();
        }

        public override void Union(int p, int q)
        {
            throw new NotImplementedException();
        }
    }
}
