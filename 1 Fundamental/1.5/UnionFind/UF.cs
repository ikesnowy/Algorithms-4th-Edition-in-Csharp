using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class UF
    {
        private int[] parent; // 记录各个元素的父级。
        private int[] rank; // 记录各个元素的子树高度。
        private int count; // 元素数量。

        /// <summary>
        /// 新建一个大小为 n 的并查集。
        /// </summary>
        /// <param name="n">并查集的大小。</param>
        public UF(int n)
        {
            if (n < 0)
                throw new ArgumentException();
            this.count = n;
            this.parent = new int[n];
            this.rank = new int[n];
            for (int i = 0; i < n; ++i)
            {
                parent[i] = i;
                rank[i] = 0;
            }
        }


    }
}
