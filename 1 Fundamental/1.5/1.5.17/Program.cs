using System;
using UnionFind;

namespace _1._5._17
{
    class Program
    {
        static void Main(string[] args)
        {
            var N = 10;
            var edges = new int[5];
            for (var i = 0; i < 5; i++)
            {
                var uf = new UF(N);
                Console.WriteLine(N + "\t" + ErdosRenyi.Count(uf));
                N *= 10;
            }
        }
    }
}
