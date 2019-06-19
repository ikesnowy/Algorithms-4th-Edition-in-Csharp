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
            var doubleTime = 6;
            var repeatTime = 6;
            var n = 1000000;
            for (var i = 0; i < doubleTime; i++)
            {
                var totalDelCount = 0;
                Console.WriteLine("n=" + n);
                for (var j = 0; j < repeatTime; j++)
                {
                    var pq = new MaxPQ<int>(n);
                    var delCount = Test(n, pq);
                    totalDelCount += delCount;
                    Console.Write(delCount + "\t");
                }
                Console.WriteLine("平均最大删除次数：" + totalDelCount / repeatTime);
                n *= 2;
            }
        }

        static int Test(int n, MaxPQ<int> pq)
        {
            var timer = new Timer(1000);
            timer.Elapsed += new ElapsedEventHandler(StopRunning);
            for (var i = 0; i < n; i++)
            {
                pq.Insert(random.Next());
            }

            var delCount = 0;
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