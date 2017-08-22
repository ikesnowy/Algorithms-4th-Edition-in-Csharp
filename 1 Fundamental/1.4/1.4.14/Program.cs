using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurement;

namespace _1._4._14
{
    /*
     * 1.4.14
     * 
     * 4-sum。
     * 为 4-sum 设计一个算法。
     * 
     */
    class Program
    {
        //见 Measurement.FourSum 类
        static void Main(string[] args)
        {
            //char[] split = new char[1] { '\n' };
            //string[] testcases = TestCase.Properties.Resources._1Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
            //long[] a = new long[testcases.Length];
            //for (int i = 0; i < testcases.Length; ++i)
            //{
            //    a[i] = long.Parse(testcases[i]);
            //}

            long[] a = new long[20] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -1, -2, -3, -4, -5, -6, -7, -8, -9, -10 };

            Stopwatch timer = new Stopwatch();
            FourSum.PrintAll(a);
            Console.WriteLine(timer.ElapsedTime());
        }
    }
}
