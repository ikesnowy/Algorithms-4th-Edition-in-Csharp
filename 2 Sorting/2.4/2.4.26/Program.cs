using System;
using System.Diagnostics;
using PriorityQueue;

namespace _2._4._26
{
    class Program
    {
        static void Main(string[] args)
        {
            var repeatTime = 1000000;
            double totalTime = 0;
            for (var i = 0; i < repeatTime; i++)
            {
                var pq = new MaxPQ<char>();
                totalTime += test(pq);
            }
            Console.WriteLine("Normal MaxPQ: " + totalTime);

            totalTime = 0;
            for (var i = 0; i < repeatTime; i++)
            {
                var pqNoExch = new MaxPQNoExch<char>();
                totalTime += test(pqNoExch);
            }
            Console.WriteLine("MaxPQ without Exch: " + totalTime);
        }

        static long test(IMaxPQ<char> pq)
        {
            var sw = new Stopwatch();
            sw.Restart();
            var input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
            foreach (var c in input)
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