﻿using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._36
{
    /*
     * 3.1.36
     * 
     * 性能验证 Ⅱ。
     * 解释 FrequencyCounter 
     * 在使用 BinarySearchST 时比
     * 使用 SequentialSearchST 时的性能提高程度好于预期的原因。
     * 
     */
    class Program
    {
        // 绝大部分单词都位于符号表的中部，因此二分查找所需的时间较少。
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
                    BinarySearchST<string, int> st = new BinarySearchST<string, int>();
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