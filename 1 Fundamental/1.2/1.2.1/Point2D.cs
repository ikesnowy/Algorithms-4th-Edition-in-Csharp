using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._1
{
    /// <summary>
    /// Point2D 二维点类
    /// </summary>
    class Point2D : IComparable<Point2D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public int Radius { get; set; }

        public Point2D(double x, double y)
        {
            if (double.IsInfinity(x) || double.IsInfinity(y))
            {
                throw new ArgumentException("x, y must be finite");
            }

            if (double.IsNaN(x) || double.IsNaN(y))
            {
                throw new ArgumentNullException("Coordinate cannot be NaN");
            }

            this.X = x;
            this.Y = y;
            this.Radius = 2;
        }

        /// <summary>
        /// 返回极半径
        /// </summary>
        /// <returns></returns>
        public double R()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        /// 返回极角
        /// </summary>
        /// <returns></returns>
        public double Theta()
        {
            return Math.Atan2(Y, X);
        }

        /// <summary>
        /// 返回两个点之间的角度
        /// </summary>
        /// <param name="that">要计算角度的另一个点</param>
        /// <returns></returns>
        private double AngleTo(Point2D that)
        {
            double dx = that.X - this.X;
            double dy = that.Y - this.Y;
            return Math.Atan2(dy, dx);
        }


        /// <summary>
        /// 计算两个 Point2D 之间的距离
        /// </summary>
        /// <param name="that">需要计算的另一个点</param>
        /// <returns>返回两点之间的距离</returns>
        public double DistTo(Point2D that)
        {
            double temp = Math.Pow(this.X - that.X, 2) + Math.Pow(this.Y - that.Y, 2);
            return Math.Sqrt(temp);
        }

        /// <summary>
        /// 判断 a,b,c 三个点的关系，如果 {顺时针, 共线, 逆时针} 则返回 {-1, 0, 1}
        /// </summary>
        /// <param name="a">第一个点</param>
        /// <param name="b">第二个点</param>
        /// <param name="c">第三个点</param>
        /// <returns></returns>
        public static int CCW(Point2D a, Point2D b, Point2D c)
        {
            double area2 = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
            if (area2 < 0)
                return -1;
            if (area2 > 0)
                return 1;
            return 0;
        }

        /// <summary>
        /// 返回 abc 三个点构成的三角形的面积的平方
        /// </summary>
        /// <param name="a">第一个点</param>
        /// <param name="b">第二个点</param>
        /// <param name="c">第三个点</param>
        /// <returns></returns>
        public static double Area2(Point2D a, Point2D b, Point2D c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }


        /// <summary>
        /// 返回当前点到另一个点之间的距离
        /// </summary>
        /// <param name="that">另一个点</param>
        /// <returns></returns>
        public double DistanceTo(Point2D that)
        {
            double dx = this.X - that.X;
            double dy = this.Y - that.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// 返回当前点到另一个点之间的距离的平方
        /// </summary>
        /// <param name="that">另一个点</param>
        /// <returns></returns>
        public double DistanceSquareTo(Point2D that)
        {
            double dx = this.X - that.X;
            double dy = this.Y - that.Y;

            return dx * dx + dy * dy;
        }

        int IComparable<Point2D>.CompareTo(Point2D other)
        {
            if (this.Y < other.Y)
                return -1;
            if (this.Y > other.Y)
                return 1;
            if (this.X < other.X)
                return -1;
            if (this.X > other.X)
                return 1;

            return 0;
        }

        private class XOrder : Comparer<Point2D>
        {
            public override int Compare(Point2D x, Point2D y)
            {
                if (x.X < y.X)
                {
                    return -1;
                }

                if (x.X > y.X)
                {
                    return 1;
                }

                return 0;
            }
        }

        private class YOrder : Comparer<Point2D>
        {
            public override int Compare(Point2D x, Point2D y)
            {
                if (x.Y < y.Y)
                {
                    return -1;
                }
                if (x.Y > y.Y)
                {
                    return 1;
                }

                return 0;
            }
        }

        private class ROrder : Comparer<Point2D>
        {
            public override int Compare(Point2D x, Point2D y)
            {
                double delta = (x.X * x.X + x.Y * x.Y) - (y.X * y.X + y.Y * y.Y);
                if (delta < 0)
                {
                    return -1;
                }

                if (delta > 0)
                {
                    return 1;
                }

                return 0;
            }
        }

        private class Atan2Order : Comparer<Point2D>
        {
            public override int Compare(Point2D x, Point2D y)
            {
                double angle1 = x.AngleTo
            }
        }
    }

    
}
