using System;
using UnionFind;

namespace _1._5._21
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var n = 10; n < 10000; n *= 2)
            {
                var total = 0;
                for (var i = 0; i < 100; i++)
                {
                    var uf = new UF(n);
                    total += ErdosRenyi.Count(uf);
                }

                Console.WriteLine("实验结果：" + total / 100);
                Console.WriteLine("1/2NlnN：" + Math.Log(n) * n * 0.5);
                Console.WriteLine();
            }
        }
    }
}
