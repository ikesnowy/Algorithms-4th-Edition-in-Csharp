using System;
using System.Diagnostics;
using PriorityQueue;

namespace _2._4._36
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int doubleTime = 5;
            int repeatTime = 5;
            int n = 100000;

            for (int i = 0; i < doubleTime; i++)
            {
                long totalTime = 0;
                Console.WriteLine("n=" + n);
                for (int j = 0; j < repeatTime; j++)
                {
                    MaxPQ<int> pq = new MaxPQ<int>(n);
                    long time = Test(pq, n);
                    Console.Write(time + "\t");
                    totalTime += time;
                }
                Console.WriteLine("平均用时：" + totalTime / repeatTime + "毫秒");
                n *= 2;
            }
        }

        static long Test(MaxPQ<int> pq, int n)
        {
            // 生成数据
            int[] initData = new int[n];
            int[] appendData = new int[n / 2];
            for (int i = 0; i < n; i++)
                initData[i] = random.Next();
            for (int i = 0; i < n / 2; i++)
                appendData[i] = random.Next();

            // 开始测试
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // 插入 n 个元素
            for (int i = 0; i < n; i++)
                pq.Insert(initData[i]);
            // 删去一半
            for (int i = 0; i < n / 2; i++)
                pq.DelMax();
            // 插入一半
            for (int i = 0; i < n / 2; i++)
                pq.Insert(appendData[i]);
            // 删除全部
            for (int i = 0; i < n; i++)
                pq.DelMax();

            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}