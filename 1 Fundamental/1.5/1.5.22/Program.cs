using System;
using System.Diagnostics;
using UnionFind;

namespace _1._5._22
{
    /*
     * 1.5.22
     * 
     * Erdös-Renyi 的倍率实验。
     * 开发一个性能测试用例，
     * 从命令行接受一个 int 值 T 并进行 T 次以下实验：
     * 使用练习 1.5.17 的用例生成随机连接，
     * 和我们的开发用例一样使用 UnionFind 来检查触点的连通性，
     * 不断循环知道所有触点都相互连通。
     * 对于每个 N，打印出 N 值和平均所需的连接数以及前后两次运行时间的比值。
     * 使用你的程序验证正文中的猜想：
     * quick-find 算法和 quick-union 算法的运行时间是平方级别的，
     * 加权 quick-union 算法则接近线性级别。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            long lastTimeQuickFind = 0;
            long lastTimeQuickUnion = 0;
            long lastTimeWeightedQuickUnion = 0;

            long nowTime = 0;
            for (int n = 2000; n < 100000; n *= 2)
            {
                Console.WriteLine("N:" + n);
                QuickFindUF quickFindUF = new QuickFindUF(n);
                QuickUnionUF quickUnionUF = new QuickUnionUF(n);
                WeightedQuickUnionUF weightedQuickUnionUF = new WeightedQuickUnionUF(n);

                // quick-find
                Console.WriteLine("quick-find");
                nowTime = RunTest(quickFindUF);
                if (lastTimeQuickFind == 0)
                {
                    Console.WriteLine("用时：" + nowTime);
                    lastTimeQuickFind = nowTime;
                }
                else
                {
                    Console.WriteLine("用时：" + nowTime + 
                        " 比值：" + (double)nowTime / lastTimeQuickFind);
                    lastTimeQuickFind = nowTime;
                }
                Console.WriteLine();

                // quick-union
                Console.WriteLine("quick-union");
                nowTime = RunTest(quickUnionUF);
                if (lastTimeQuickUnion == 0)
                {
                    Console.WriteLine("用时：" + nowTime);
                    lastTimeQuickUnion = nowTime;
                }
                else
                {
                    Console.WriteLine("用时：" + nowTime + 
                        " 比值：" + (double)nowTime / lastTimeQuickUnion);
                    lastTimeQuickUnion = nowTime;
                }
                Console.WriteLine();

                // weighted-quick-union
                Console.WriteLine("weighted-quick-union");
                nowTime = RunTest(weightedQuickUnionUF);
                if (lastTimeWeightedQuickUnion == 0)
                {
                    Console.WriteLine("用时：" + nowTime);
                    lastTimeWeightedQuickUnion = nowTime;
                }
                else
                {
                    Console.WriteLine("用时：" + nowTime + 
                        " 比值：" + (double)nowTime / lastTimeWeightedQuickUnion);
                    lastTimeWeightedQuickUnion = nowTime;
                }
                Console.WriteLine();

                Console.WriteLine();
            }
            
        }

        /// <summary>
        /// 进行若干次随机试验，输出平均 union 次数，返回平均耗时。
        /// </summary>
        /// <param name="uf">用于测试的并查集。</param>
        /// <returns>平均耗时。</returns>
        static long RunTest(UF uf)
        {
            Stopwatch timer = new Stopwatch();
            int total = 0;
            int repeatTime = 10;
            timer.Start();
            for (int i = 0; i < repeatTime; i++)
            {
                total += ErdosRenyi.Count(uf);
            }
            timer.Stop();
            Console.WriteLine("平均次数：" + total / repeatTime);

            return timer.ElapsedMilliseconds / repeatTime;
        }
    }
}
