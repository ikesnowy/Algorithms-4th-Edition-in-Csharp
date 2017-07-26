using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            int i = 0;
            double maxDiff = 0;
            double A = 0;
            double B = 0;
            while (i < a.Length - 1)
            {
                if (Math.Abs(a[i] - a[i + 1]) > maxDiff)
                {
                    maxDiff = Math.Abs(a[i] - a[i + 1]);
                    A = a[i];
                    B = a[i + 1];
                }
                i++;
            }

            Console.WriteLine($"MaxDiff Pair: {A} {B}, Max Difference: {maxDiff}");
        }
    }
}
