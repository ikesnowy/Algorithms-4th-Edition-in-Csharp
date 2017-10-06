using System;
using System.Diagnostics;
using UnionFind;

namespace _1._5._25
{
    /*
     * 1.5.25
     * 
     * 随机网格的倍率测试。
     * 开发一个性能测试用例，
     * 从命令行接受一个 int 值 T 并进行 T 次以下实验：
     * 使用练习 1.5.18 的用例生成一个 N×N 的随机网格，
     * 所有连接的方向随机且排列随机。
     * 和我们的开发用例一样使用 UnionFind 来检查触点的连通性，
     * 不断循环直到所有触点均相互连通。
     * 对于每个 N，打印出 N 值和平均所需的连接数以及前后两次运行时间的比值。
     * 使用你的程序验证正文中的猜想：
     * quick-find 和 quick-union 算法的运行时间是平方级别的，
     * 加权 quick-union 算法则接近线性级别。
     * 
     * 注意：随着 N 值加倍，网格中触点的数量会乘以 4，
     * 因此平方级别的算法运行时间会变为原来的 16 倍，
     * 线性级别的算法的运行时间则变为原来的 4 倍
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = 20;
            int t = 5;

            // quick-find
            Console.WriteLine("Quick-Find");
            long last = 0;
            long now = 0;
            for (int i = 0; i < t; ++i, n *= 2)
            {
                Console.WriteLine("N:" + n * n);
                var connections = RandomGrid.GetConnections(n);

                QuickFindUF quickFind = new QuickFindUF(n * n);
                now = RunTest(quickFind, connections);
                if (last == 0)
                {
                    Console.WriteLine("平均用时（毫秒）：" + now);
                    last = now;
                }
                else
                {
                    Console.WriteLine("平均用时（毫秒）：" + now + "\t比值：" + (double)now / last);
                    last = now;
                }
            }

            // quick-union
            Console.WriteLine("Quick-Union");
            n = 20;
            for (int i = 0; i < t; ++i, n *= 2)
            {
                Console.WriteLine("N:" + n * n);
                var connections = RandomGrid.GetConnections(n);

                QuickUnionUF quickFind = new QuickUnionUF(n * n);
                now = RunTest(quickFind, connections);
                if (last == 0)
                {
                    Console.WriteLine("平均用时（毫秒）：" + now);
                    last = now;
                }
                else
                {
                    Console.WriteLine("平均用时（毫秒）：" + now + "\t比值：" + (double)now / last);
                    last = now;
                }
            }

            // 加权 quick-union
            Console.WriteLine("Quick-Union");
            n = 20;
            for (int i = 0; i < t; ++i, n *= 2)
            {
                Console.WriteLine("N:" + n * n);
                var connections = RandomGrid.GetConnections(n);

                WeightedQuickUnionUF quickFind = new WeightedQuickUnionUF(n * n);
                now = RunTest(quickFind, connections);
                if (last == 0)
                {
                    Console.WriteLine("平均用时（毫秒）：" + now);
                    last = now;
                }
                else
                {
                    Console.WriteLine("平均用时（毫秒）：" + now + "\t比值：" + (double)now / last);
                    last = now;
                }
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
            long repeatTime = 5;
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
