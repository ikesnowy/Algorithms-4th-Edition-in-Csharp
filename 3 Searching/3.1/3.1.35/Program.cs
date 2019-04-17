using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._35
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = 8000;
            int multiplyBy2 = 5;
            int repeatTimes = 5;
            double lastTime = -1;
            Console.WriteLine("n\ttime\tratio");
            for (int i = 0; i < multiplyBy2; i++)
            {
                Console.Write(n + "\t");
                long timeSum = 0;
                for (int j = 0; j < repeatTimes; j++)
                {
                    SequentialSearchST<string, int> st = new SequentialSearchST<string, int>();
                    Stopwatch sw = Stopwatch.StartNew();
                    FrequencyCounter.MostFrequentlyWord("tale.txt", n, 0, st);
                    sw.Stop();
                    timeSum += sw.ElapsedMilliseconds;
                }
                timeSum /= repeatTimes;
                Console.Write(timeSum + "\t");
                if (lastTime < 0)
                    Console.WriteLine("--");
                else
                    Console.WriteLine(timeSum / lastTime);
                lastTime = timeSum;
                n *= 2;
            }
        }
    }
}
