using System;
using System.Collections.Generic;

namespace _1._2._2
{
    /*
     * 1.2.2
     * 
     * 编写一个 Interval1D 的用例，从命令行接受一个整数 N。
     * 从标准输入中读取 N 个间隔（每个间隔由一对 double 值定义）并打印出所有相交的间隔对。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the value of N:");
            int N = int.Parse(Console.ReadLine());
            List<Interval1D> intervalList = new List<Interval1D>();

            if (N < 2)
            {
                Console.WriteLine("Make sure there are at least 2 Intervals");
                return;
            }

            //读取并建立间隔数组
            Console.WriteLine("Type the data, make sure there is a space between two numbers.\nExample: 0.5 1");
            for (int i = 0; i < N; ++i)
            {
                string temp = Console.ReadLine();
                double lo = double.Parse(temp.Split(' ')[0]);
                double hi = double.Parse(temp.Split(' ')[1]);

                if (lo > hi)
                {
                    double t = lo;
                    lo = hi;
                    hi = t;
                }

                intervalList.Add(new Interval1D(lo, hi));
            }

            for (int i = 0; i < N; ++i)
            {
                for (int j = i + 1; j < N; ++j)
                {
                    if (intervalList[i].Intersect(intervalList[j]))
                    {
                        Console.WriteLine($"{intervalList[i].ToString()} {intervalList[j].ToString()}");
                    }
                }
            }
        }
    }
}