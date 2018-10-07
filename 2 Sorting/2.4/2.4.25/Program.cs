using System;
using System.IO;
using PriorityQueue;

namespace _2._4._25
{
    /*
     * 2.4.25
     * 
     * 计算数论。
     * 编写程序 CubeSum.java，
     * 在不使用额外空间的条件下，
     * 按大小顺序打印所有 a^3+b^3 的结果，
     * 其中 a 和 b 为 0 至 N 之间所有的整数。
     * 也就是说，不要全部计算 N^2 个和然后排序，
     * 而是创建一个最小优先队列，
     * 初始状态为 (0^3, 0, 0),(1^3, 0, 0),(2^3, 2, 0),...,(N^3, N, 0)。
     * 这样只要优先队列非空，删除并打印最小的元素 (i^3+j^3, i, j)。
     * 然后如果 j<N，插入元素 (i^3+(j+1)^3, i, j+1)。
     * 用这段程序找出 0 到 10^6 之间
     * 所有满足 a^3+b^3 = c^3+d^3 的不同整数 a, b, c, d。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;

            MinPQ<CubeSum> pq = new MinPQ<CubeSum>();
            Console.WriteLine("正在初始化");
            for (int i = 0; i <= n; i++)
            {
                pq.Insert(new CubeSum(i, i));
            }

            FileStream ostream = new FileStream("./result.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(ostream);
            Console.WriteLine("正在写入文件……");
            CubeSum prev = new CubeSum(-1, -1);
            long pairCount = 0;
            while (!pq.IsEmpty())
            {
                CubeSum s = pq.DelMin();
                if (s.sum == prev.sum)
                {
                    sw.WriteLine(s + " = " + prev.i + "^3 + " + prev.j + "^3");
                    pairCount++;
                }         
                if (s.j < n)
                    pq.Insert(new CubeSum(s.i, s.j + 1));
                prev = s;
            }
            sw.WriteLine("共找到" + pairCount + "对数据");
            Console.WriteLine("共找到" + pairCount + "对数据");
            sw.Close();
            Console.WriteLine("结果已经保存到程序所在目录下的 result.txt 文件中");
        }
    }
}
