﻿using System;
using SymbolTable;

namespace _3._1._7
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            const int repeatTime = 50;
            const int multiplyBy10 = 6;
            var arraySize = 10;

            for (var i = 0; i < multiplyBy10; i++)
            {
                Console.Write("n=10^" + (i + 1) + "\t");
                var distinctSum = 0;
                for (var j = 0; j < repeatTime; j++)
                {
                    var st = new ST<int, int>();
                    var data = RandomArray(arraySize);
                    distinctSum += FrequencyCounter.CountDistinct(data, st);
                }
                Console.WriteLine(distinctSum / repeatTime);
                arraySize *= 10;
            }

        }

        static int[] RandomArray(int n)
        {
            var data = new int[n];
            for (var i = 0; i < n; i++)
            {
                data[i] = random.Next(1000);
            }
            return data;
        }
    }
}