using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// Point2D 二维点类。
    /// </summary>
    public sealed class Point2D : IComparable<Point2D>
    {
        public readonly static Comparer<Point2D> X_Order = new XOrder();
        public readonly static Comparer<Point2D> Y_Order = new YOrder();
        public readonly static Comparer<Point2D> R_Order = new ROrder();

        public double X { get; }
        public double Y { get; }
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
        /// 返回极半径。
        /// </summary>
        /// <returns></returns>
        public double R()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        /// <summary>
        /// 返回极角。
        /// </summary>
        /// <returns></returns>
        public double Theta()
        {
            return Math.Atan2(Y, X);
        }

        /// <summary>
        /// 返回两个点之间的角度。
        /// </summary>
        /// <param name="that">要计算角度的另一个点。</param>
        /// <returns></returns>
        private double AngleTo(Point2D that)
        {
            double dx = that.X - this.X;
            double dy = that.Y - this.Y;
            return Math.Atan2(dy, dx);
        }

        /// <summary>
        /// 判断 a,b,c 三个点的关系，如果 {顺时针, 共线, 逆时针} 则返回 {-1, 0, 1}。
        /// </summary>
        /// <param name="a">第一个点。</param>
        /// <param name="b">第二个点。</param>
        /// <param name="c">第三个点。</param>
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
        /// 返回 abc 三个点构成的三角形的面积的平方。
        /// </summary>
        /// <param name="a">第一个点。</param>
        /// <param name="b">第二个点。</param>
        /// <param name="c">第三个点。</param>
        /// <returns></returns>
        public static double Area2(Point2D a, Point2D b, Point2D c)
        {
            return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
        }


        /// <summary>
        /// 返回当前点到另一个点之间的距离。
        /// </summary>
        /// <param name="that">另一个点。</param>
        /// <returns></returns>
        public double DistanceTo(Point2D that)
        {
            double dx = this.X - that.X;
            double dy = this.Y - that.Y;

            return Math.Sqrt(dx * dx + dy * dy);
        }

        /// <summary>
        /// 返回当前点到另一个点之间的距离的平方。
        /// </summary>
        /// <param name="that">另一个点。</param>
        /// <returns></returns>
        public double DistanceSquareTo(Point2D that)
        {
            double dx = this.X - that.X;
            double dy = this.Y - that.Y;

            return dx * dx + dy * dy;
        }

        /// <summary>
        /// 实现 IComparable 接口。
        /// </summary>
        /// <param name="other">需要比较的另一个对象。</param>
        /// <returns></returns>
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

        /// <summary>
        /// 按照 X 顺序比较。
        /// </summary>
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

        /// <summary>
        /// 按照 Y 顺序比较。
        /// </summary>
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

        /// <summary>
        /// 按照极径顺序比较。
        /// </summary>
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

        /// <summary>
        /// 按照 atan2 值顺序比较。
        /// </summary>
        private class Atan2Order : Comparer<Point2D>
        {
            private Point2D parent;
            public Atan2Order() { }
            public Atan2Order(Point2D parent)
            {
                this.parent = parent;
            }
            public override int Compare(Point2D x, Point2D y)
            {
                double angle1 = parent.AngleTo(x);
                double angle2 = parent.AngleTo(y);
                if (angle1 < angle2)
                {
                    return -1;
                }
                else if (angle1 > angle2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 按照极角顺序比较。
        /// </summary>
        private class PolorOrder : Comparer<Point2D>
        {
            private Point2D parent;
            public PolorOrder() { }
            public PolorOrder(Point2D parent)
            {
                this.parent = parent;
            }
            public override int Compare(Point2D q1, Point2D q2)
            {
                double dx1 = q1.X - parent.X;
                double dy1 = q1.Y - parent.Y;
                double dx2 = q2.X - parent.X;
                double dy2 = q2.Y - parent.Y;

                if (dy2 >= 0 && dy2 < 0)
                {
                    return -1;
                }
                else if (dy2 >= 0 && dy1 < 0)
                {
                    return 1;
                }
                else if (dy1 == 0 && dy2 == 0)
                {
                    if (dx1 >= 0 && dx2 < 0)
                    {
                        return -1;
                    }
                    else if (dx2 >= 0 && dx1 < 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return -CCW(this.parent, q1, q2);
                }
            }
        }

        /// <summary>
        /// 按照距离顺序比较。
        /// </summary>
        private class DistanceToOrder : Comparer<Point2D>
        {
            private Point2D parent;
            public DistanceToOrder() { }
            public DistanceToOrder(Point2D parent)
            {
                this.parent = parent;
            }
            public override int Compare(Point2D p, Point2D q)
            {
                double dist1 = parent.DistanceSquareTo(p);
                double dist2 = parent.DistanceSquareTo(q);

                if (dist1 < dist2)
                {
                    return -1;
                }
                else if (dist1 > dist2)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public Comparer<Point2D> Polor_Order()
        {
            return new PolorOrder(this);
        }

        public Comparer<Point2D> Atan2_Order()
        {
            return new Atan2Order(this);
        }

        public Comparer<Point2D> DistanceTo_Order()
        {
            return new DistanceToOrder(this);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            Point2D that = (Point2D)obj;
            return this.X == that.X && this.Y == that.Y;
        }

        public override string ToString()
        {
            return "(" + X + ", " + Y + ")";
        }

        public override int GetHashCode()
        {
            int hashX = X.GetHashCode();
            int hashY = Y.GetHashCode();
            return 31 * hashX + hashY;
        }
    }
}
