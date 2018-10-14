using System;
using System.Diagnostics;
using PriorityQueue;

namespace _2._4._26
{
    /*
     * 2.4.26
     * 
     * 无需交换的堆。
     * 因为 sink() 和 swim() 中都用到了初级函数 exch()，
     * 所以所有元素都被多加载并存储了一次。
     * 回避这种低效的方式，用插入排序给出新的实现（请见练习 2.1.25）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int repeatTime = 1000000;
            double totalTime = 0;
            for (int i = 0; i < repeatTime; i++)
            {
                MaxPQ<char> pq = new MaxPQ<char>();
                totalTime += test(pq);
            }
            Console.WriteLine("Normal MaxPQ: " + totalTime);

            totalTime = 0;
            for (int i = 0; i < repeatTime; i++)
            {
                MaxPQNoExch<char> pqNoExch = new MaxPQNoExch<char>();
                totalTime += test(pqNoExch);
            }
            Console.WriteLine("MaxPQ without Exch: " + totalTime);
         }
        
        static long test(IMaxPQ<char> pq)
        {
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            string input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
            foreach (char c in input)
            {
                if (c == ' ')
                    continue;
                else if (c == '*')
                {
                    pq.DelMax();
                }
                else
                {
                    pq.Insert(c);
                }
            }
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }
    }
}
