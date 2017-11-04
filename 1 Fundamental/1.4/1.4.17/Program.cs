using System;

namespace _1._4._17
{
    /*
     * 1.4.17
     * 
     * 最遥远的一对（一维）。
     * 编写一个程序，给定一个含有 N 个 double 值的数组 a[]，
     * 在其中找到一对最遥远的值：两者之差（绝对值）最大的两个数。
     * 程序在最坏情况下所需的运行时间应该是线性级别的。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[5] { 0.1, 0.3, 0.6, 0.8, 0 };
            double min = int.MaxValue;
            double max = int.MinValue;
            
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            Console.WriteLine($"MaxDiff Pair: {min} {max}, Max Difference: {Math.Abs(max - min)}");
        }
    }
}
