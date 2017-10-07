using System;
using System.Diagnostics;
using UnionFind;

namespace _1._5._23
{
    /*
     * 1.5.23
     * 
     * 在 Erdös-Renyi 模型下比较 quick-find 算法和 quick-union 算法。
     * 开发一个性能测试用例，从命令行接受一个 int 值 T 并进行 T 次以下实验：
     * 使用练习 1.5.17 的用例生成随机连接。
     * 保存这些连接并和我们的开发用例一样分别用 quick-find 和 quick-union 算法检查触点的连通性，
     * 不断循环直到所有触点均相互连通。
     * 对于每个 N，打印出 N 值和两种算法的运行时间比值。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = 2000;
            for (int t = 0; t < 5; ++t)
            {
                Connection[] input = ErdosRenyi.Generate(n);
                QuickFindUF quickFind = new QuickFindUF(n);
                QuickUnionUF quickUnion = new QuickUnionUF(n);

                Console.WriteLine("N:" + n);

                long quickFindTime = RunTest(quickFind, input);
                long quickUnionTime = RunTest(quickUnion, input);

                Console.WriteLine("quick-find 耗时（毫秒）：" + quickFindTime);
                Console.WriteLine("quick-union 耗时（毫秒）：" + quickUnionTime);
                Console.WriteLine("比值：" + (double)quickFindTime / quickUnionTime);
                Console.WriteLine();

                n *= 2;
            }
        }

        /// <summary>
        /// 进行若干次随机试验，输出平均 union 次数，返回平均耗时。
        /// </summary>
        /// <param name="uf">用于测试的并查集。</param>
        /// <param name="connections">用于测试的输入。</param>
        /// <returns>平均耗时。</returns>
        static long RunTest(UF uf, Connection[] connections)
        {
            Stopwatch timer = new Stopwatch();
            int repeatTime = 5;
            timer.Start();
            for (int i = 0; i < repeatTime; ++i)
            {
                ErdosRenyi.Count(uf, connections);
            }
            timer.Stop();

            return timer.ElapsedMilliseconds / repeatTime;
        }
    }
}
