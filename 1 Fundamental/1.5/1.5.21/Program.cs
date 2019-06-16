using System;
using UnionFind;

namespace _1._5._21
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int n = 10; n < 10000; n *= 2)
            {
                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    UF uf = new UF(n);
                    total += ErdosRenyi.Count(uf);
                }

                Console.WriteLine("实验结果：" + total / 100);
                Console.WriteLine("1/2NlnN：" + Math.Log(n) * n * 0.5);
                Console.WriteLine();
            }
        }
    }
}
