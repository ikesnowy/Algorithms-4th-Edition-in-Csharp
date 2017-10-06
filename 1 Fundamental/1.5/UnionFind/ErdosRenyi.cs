using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class ErdosRenyi
    {
        /// <summary>
        /// 随机生成一组能让并查集只剩一个连通分量的连接。
        /// </summary>
        /// <param name="n">并查集大小。</param>
        /// <returns>一组能让并查集只剩一个连通分量的连接。</returns>
        public static Connection[] Generate(int n)
        {
            Random random = new Random();
            List<Connection> connections = new List<Connection>();
            WeightedQuickUnionPathCompressionUF uf = new WeightedQuickUnionPathCompressionUF(n);

            while (uf.Count() > 1)
            {
                int p = random.Next(n);
                int q = random.Next(n);
                uf.Union(p, q);
                connections.Add(new Connection(p, q));
            }

            return connections.ToArray();
        }

        /// <summary>
        /// 随机生成连接，返回令并查集中只剩一个连通分量所需的连接总数。
        /// </summary>
        /// <param name="uf">用于测试的并查集。</param>
        /// <returns>需要的连接总数。</returns>
        public static int Count(UF uf)
        {
            Random random = new Random();
            int size = uf.Count();
            int edges = 0;
            while (uf.Count() > 1)
            {
                int p = random.Next(size);
                int q = random.Next(size);
                uf.Union(p, q);
                edges++;
            }

            return edges;
        }

        /// <summary>
        /// 使用指定的连接按顺序合并。
        /// </summary>
        /// <param name="uf">需要测试的并查集。</param>
        /// <param name="connections">用于输入的连接集合。</param>
        public static void Count(UF uf, Connection[] connections)
        {
            foreach (Connection c in connections)
            {
                uf.Union(c.P, c.Q);
            }
        }
    }
}
