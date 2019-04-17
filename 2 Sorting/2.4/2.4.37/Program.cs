using System;
using System.Timers;
using PriorityQueue;

namespace _2._4._37
{
    
    class Program
    {
        static bool isRunning = true;
        static Random random = new Random();

        static void Main(string[] args)
        {
            int doubleTime = 6;
            int repeatTime = 6;
            int n = 1000000;
            for (int i = 0; i < doubleTime; i++)
            {
                int totalDelCount = 0;
                Console.WriteLine("n=" + n);
                for (int j = 0; j < repeatTime; j++)
                {
                    MaxPQ<int> pq = new MaxPQ<int>(n);
                    int delCount = Test(n, pq);
                    totalDelCount += delCount;
                    Console.Write(delCount + "\t");
                }
                Console.WriteLine("平均最大删除次数：" + totalDelCount / repeatTime);
                n *= 2;
            }
        }

        static int Test(int n, MaxPQ<int> pq)
        {
            Timer timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(StopRunning);
            for (int i = 0; i < n; i++)
            {
                pq.Insert(random.Next());
            }

            int delCount = 0;
            StartRunning();
            timer.Start();
            while (isRunning && !pq.IsEmpty())
            {
                pq.DelMax();
                delCount++;
            }
            timer.Stop();
            return delCount;
        }

        static void StartRunning() => isRunning = true;
        static void StopRunning(object source, ElapsedEventArgs e)
            => isRunning = false;
    }
}
