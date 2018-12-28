using System;
using System.Diagnostics;
using PriorityQueue;

namespace _2._4._36
{
    /*
     * 2.4.36
     * 性能测试Ⅰ。
     * 编写一个性能测试用例，用插入元素操作填满一个优先队列，
     * 然后用删除最大元素操作删去一半元素，再用插入元素操作填满优先队列，
     * 再用删除最大元素操作删去所有元素。
     * 用一列随机的长短不同的元素多次重复以上过程，测量每次运行的用时，
     * 打印平均用时或是将其绘制成图表。
     * 
     */
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int repeatTime = 5;
            int n = 100000;

            long totalTime = 0;
            for (int i = 0; i < repeatTime; i++)
            {
                Console.Write("n=" + n + "\t");
                MaxPQ<int> pq = new MaxPQ<int>(n);
                long time = Test(pq, n);
                Console.WriteLine("第" + (i + 1) + "次测试的用时为" + time);
                totalTime += time;
                n *= 2;
            }
            Console.WriteLine("平均用时：" + totalTime / repeatTime);
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
