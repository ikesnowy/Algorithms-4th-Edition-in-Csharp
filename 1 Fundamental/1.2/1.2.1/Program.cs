using System;
using System.Collections.Generic;

namespace _1._2._1
{
    /*
     * 1.2.1
     * 
     * 编写一个 Point2D 的用例，从命令行接受一个整数 N。
     * 在单位正方形中生成 N 个随机点，然后计算两点之间的最近距离。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type the value of N:");
            int N = int.Parse(Console.ReadLine());
            List<Point2D> pointlist = new List<Point2D>();
            Random random = new Random();

            if (N <= 2)
            {
                Console.WriteLine("Make sure there are 2 points at least");
                return;
            }

            for (int i = 0; i < N; ++i)
            {
                double x = random.NextDouble();
                double y = random.NextDouble();
                pointlist.Add(new Point2D(x, y));
            }

            double min = pointlist[0].DistTo(pointlist[1]);
            for (int i = 0; i < N; ++i)
            {
                for (int j = i + 1; j < N; ++j)
                {
                    if (pointlist[i].DistTo(pointlist[j]) < min)
                    {
                        min = pointlist[i].DistTo(pointlist[j]);
                    }
                }
            }

            Console.WriteLine($"The minimal distance is {min}");
        }
    }
}