using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnionFind
{
    public class ErdosRenyi
    {
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
    }
}
