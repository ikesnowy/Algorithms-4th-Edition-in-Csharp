using System;
using SortApplication;

namespace _2._5._25
{
    /*
     * 2.5.25
     * 
     * 平面上的点。
     * 为表 1.2.3 的 Point2D 类型编写三个静态的比较器，
     * 一个按照 x 坐标比较，一个按照 y 坐标比较，一个按照点到原点的距离进行比较。
     * 编写两个非静态的比较器，
     * 一个按照两点到第三点的距离比较，
     * 一个按照两点相对于第三点的辐角比较。
     * 
     */
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/25applications/Point2D.java.html
        static void Main(string[] args)
        {
            Point2D[] points = new Point2D[6];
            for (int i = 0; i < points.Length; i++)
            {
                points[i] = new Point2D(i, points.Length - i);
            }

            Console.WriteLine("X-Order");
            Array.Sort(points, Point2D.X_Order);
            PrintArray(points);

            Console.WriteLine("Y-Order");
            Array.Sort(points, Point2D.Y_Order);
            PrintArray(points);

            Console.WriteLine("R-Order");
            Array.Sort(points, Point2D.R_Order);
            PrintArray(points);

            Point2D origin = new Point2D(0, 0);
            Console.WriteLine("Distance to Origin");
            Array.Sort(points, origin.DistanceTo_Order());
            PrintArray(points);

            Console.WriteLine("Polor angle to Origin");
            Array.Sort(points, origin.Polor_Order());
            PrintArray(points);
        }

        static void PrintArray(Point2D[] points)
        {
            foreach (Point2D p in points)
                Console.Write("(" + p.X + ", " + p.Y + ") ");
            Console.WriteLine();
        }
    }
}
