using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._21
{
    /*
     * 1.5.21
     * 
     * Erdös-Renyi 模型。
     * 使用练习 1.5.17 的用例验证这个猜想：
     * 得到单个连通分量所需生成的整数对数量为 ~1/2NlnN。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            for (int n = 10; n < 10000; n *= 2)
            {
                int total = 0;
                for (int i = 0; i < 100; ++i)
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
