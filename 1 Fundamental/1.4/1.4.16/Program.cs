﻿using System;

namespace _1._4._16
{
    
    class Program
    {
        // 总运行时间： NlogN + N = NlogN 
        static void Main(string[] args)
        {
            double[] a = new double[5] { 0.1, 0.3, 0.6, 0.8, 0 };
            Array.Sort(a);// Nlog(N) 具体见 https://msdn.microsoft.com/zh-cn/library/6tf1f0bc(v=vs.110).aspx 备注部分
            double minDiff = double.MaxValue;
            double minA = 0;
            double minB = 0;
            for (int i = 0; i < a.Length - 1; i++)//N
            {
                if (a[i + 1] - a[i] < minDiff)
                {
                    minA = a[i];
                    minB = a[i + 1];
                    minDiff = a[i + 1] - a[i];
                }
            }
            Console.WriteLine($"Min Pair: {minA} {minB}, Min Value: {minDiff}");
        }
    }
}
