﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;

// ReSharper disable PossibleNullReferenceException
// ReSharper disable CognitiveComplexity

namespace Geometry;

/// <summary>
/// Point2D 二维点类。
/// </summary>
[SuppressMessage("Interoperability", "CA1416:验证平台兼容性")]
public sealed class Point2D : IComparable<Point2D>
{
    /// <summary>
    /// 以 X 坐标升序排序。
    /// </summary>
    /// <value>以 X 坐标升序排序的静态比较器。</value>
    public static readonly Comparer<Point2D> XOrderComparer = new XOrder();

    /// <summary>
    /// 以 Y 坐标升序排序。
    /// </summary>
    /// <value>以 Y 坐标升序排序的静态比较器。</value>
    public static readonly Comparer<Point2D> YOrderComparer = new YOrder();

    /// <summary>
    /// 以极半径升序排序。
    /// </summary>
    /// <value>以极半径升序排序的静态比较器。</value>
    public static readonly Comparer<Point2D> ROrderComparer = new ROrder();

    /// <summary>
    /// 二维点的 X 坐标。
    /// </summary>
    /// <value>X 坐标。</value>
    public double X { get; }

    /// <summary>
    /// 二维坐标的 Y 坐标。
    /// </summary>
    /// <value>Y 坐标。</value>
    public double Y { get; }

    /// <summary>
    /// 绘制时点的半径，以像素为单位，默认值为 2。
    /// </summary>
    /// <value>点的半径，以像素为单位。</value>
    public int Radius { get; set; }

    /// <summary>
    /// 构造一个二维点。
    /// </summary>
    /// <param name="x">点的 X 轴坐标。</param>
    /// <param name="y">点的 Y 轴坐标。</param>
    /// <exception cref="ArgumentException">当 <paramref name="x"/> 或 <paramref name="y"/> 为±无穷时抛出此异常。</exception>
    /// <exception cref="ArgumentNullException">当 <paramref name="x"/> 或 <paramref name="y"/> 为 <see cref="double.NaN"/> 时抛出。</exception>
    public Point2D(double x, double y)
    {
        if (double.IsInfinity(x) || double.IsInfinity(y))
        {
            throw new ArgumentException("x, y must be finite");
        }

        if (double.IsNaN(x) || double.IsNaN(y))
        {
            throw new ArgumentNullException(nameof(x), "Coordinate cannot be NaN");
        }

        X = x;
        Y = y;
        Radius = 2;
    }

    /// <summary>
    /// 返回极半径。
    /// </summary>
    /// <returns>极半径。</returns>
    public double R()
    {
        return Math.Sqrt(X * X + Y * Y);
    }

    /// <summary>
    /// 返回极角。
    /// </summary>
    /// <returns>极角。</returns>
    public double Theta()
    {
        return Math.Atan2(Y, X);
    }

    /// <summary>
    /// 返回两个点之间的角度。
    /// </summary>
    /// <param name="that">要计算角度的另一个点。</param>
    /// <returns>返回与点 <paramref name="that"/> 构成的角度。</returns>
    private double AngleTo(Point2D that)
    {
        var dx = that.X - X;
        var dy = that.Y - Y;
        return Math.Atan2(dy, dx);
    }

    /// <summary>
    /// 判断 a,b,c 三个点的关系，如果 {顺时针, 共线, 逆时针} 则返回 {-1, 0, 1}。
    /// </summary>
    /// <param name="a">第一个点。</param>
    /// <param name="b">第二个点。</param>
    /// <param name="c">第三个点。</param>
    /// <returns>如果 {顺时针, 共线, 逆时针} 则返回 {-1, 0, 1}</returns>
    public static int Ccw(Point2D a, Point2D b, Point2D c)
    {
        var area2 = (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
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
    /// <returns><paramref name="a"/> 和 <paramref name="b"/> 和 <paramref name="c"/> 构成的三角形的面积的平方。</returns>
    public static double Area2(Point2D a, Point2D b, Point2D c)
    {
        return (b.X - a.X) * (c.Y - a.Y) - (b.Y - a.Y) * (c.X - a.X);
    }

    /// <summary>
    /// 返回当前点到另一个点之间的距离。
    /// </summary>
    /// <param name="that">另一个点。</param>
    /// <returns>返回到 <paramref name="that"/> 的距离。</returns>
    public double DistanceTo(Point2D that)
    {
        var dx = X - that.X;
        var dy = Y - that.Y;

        return Math.Sqrt(dx * dx + dy * dy);
    }

    /// <summary>
    /// 返回当前点到另一个点之间的距离的平方。
    /// </summary>
    /// <param name="that">另一个点。</param>
    /// <returns>到 <paramref name="that"/> 距离的平方。</returns>
    public double DistanceSquareTo(Point2D that)
    {
        var dx = X - that.X;
        var dy = Y - that.Y;

        return dx * dx + dy * dy;
    }

    /// <summary>
    /// 绘制二维点。
    /// </summary>
    /// <param name="g">原点在左下方，y轴向上，x轴向右的画布。</param>
    public void Draw(Graphics g)
    {
        g.FillEllipse(Brushes.Black, (int)X, (int)Y, Radius, Radius);
    }

    /// <summary>
    /// 优先按照 <see cref="Y"/> 比较，相同时再按照 <see cref="X"/> 比较。
    /// </summary>
    /// <param name="other">需要比较的另一个对象。</param>
    /// <returns>如果 <paramref name="other"/> 较小则返回 -1，反之返回 1，相等返回 0。</returns>
    public int CompareTo(Point2D? other)
    {
        if (other == null)
        {
            return -1;
        }

        if (Y < other.Y)
            return -1;
        if (Y > other.Y)
            return 1;
        if (X < other.X)
            return -1;
        if (X > other.X)
            return 1;

        return 0;
    }

    /// <summary>
    /// 按照 X 顺序比较。
    /// </summary>
    private class XOrder : Comparer<Point2D>
    {
        public override int Compare(Point2D? x, Point2D? y)
        {
            if (x == null || y == null)
            {
                return Equals(x, y) ? 0 : (x == null ? -1 : 1);
            }
            
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
        public override int Compare(Point2D? x, Point2D? y)
        {
            var compareX = x?.Y ?? 0;
            var compareY = y?.Y ?? 0;
            if (compareX < compareY)
            {
                return -1;
            }

            if (compareX > compareY)
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
        public override int Compare(Point2D? x, Point2D? y)
        {
            var delta = (x == null ? 0 : x.X * x.X + x.Y * x.Y) - (y == null ? 0 : y.X * y.X + y.Y * y.Y);
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
        private readonly Point2D _parent;

        public Atan2Order(Point2D parent)
        {
            _parent = parent;
        }

        public override int Compare(Point2D? x, Point2D? y)
        {
            var angle1 = _parent.AngleTo(x!);
            var angle2 = _parent.AngleTo(y!);
            if (angle1 < angle2)
            {
                return -1;
            }

            if (angle1 > angle2)
            {
                return 1;
            }

            return 0;
        }
    }

    /// <summary>
    /// 按照极角顺序比较。
    /// </summary>
    private class PolarOrder : Comparer<Point2D>
    {
        private readonly Point2D _parent;

        public PolarOrder(Point2D parent)
        {
            _parent = parent;
        }

        public override int Compare(Point2D? q1, Point2D? q2)
        {
            var dx1 = q1!.X - _parent.X;
            var dy1 = q1.Y - _parent.Y;
            var dx2 = q2!.X - _parent.X;
            var dy2 = q2.Y - _parent.Y;

            if (dy2 >= 0 && dy2 < 0)
            {
                return -1;
            }

            if (dy2 >= 0 && dy1 < 0)
            {
                return 1;
            }

            if (dy1 == 0 && dy2 == 0)
            {
                if (dx1 >= 0 && dx2 < 0)
                {
                    return -1;
                }

                if (dx2 >= 0 && dx1 < 0)
                {
                    return 1;
                }

                return 0;
            }

            return -Ccw(_parent, q1, q2);
        }
    }

    /// <summary>
    /// 按照距离顺序比较。
    /// </summary>
    private class DistanceToOrder : Comparer<Point2D>
    {
        private readonly Point2D _parent;

        public DistanceToOrder(Point2D parent)
        {
            _parent = parent;
        }

        public override int Compare(Point2D? p, Point2D? q)
        {
            var dist1 = _parent.DistanceSquareTo(p!);
            var dist2 = _parent.DistanceSquareTo(q!);

            if (dist1 < dist2)
            {
                return -1;
            }

            if (dist1 > dist2)
            {
                return 1;
            }

            return 0;
        }
    }

    /// <summary>
    /// 构造一个以到当前点的极角为关键字的升序比较器。
    /// </summary>
    /// <returns>以到当前点的极角为关键字的升序比较器。</returns>
    public Comparer<Point2D> Polor_Order()
    {
        return new PolarOrder(this);
    }

    /// <summary>
    /// 构造一个以到当前点的 Atan2 为关键字的升序比较器。
    /// </summary>
    /// <returns>以到当前点的 Atan2 为关键字的升序比较器。</returns>
    public Comparer<Point2D> Atan2_Order()
    {
        return new Atan2Order(this);
    }

    /// <summary>
    /// 构造一个以到当前点的距离为关键字的升序比较器。
    /// </summary>
    /// <returns>以到当前点的距离为关键字的升序比较器。</returns>
    public Comparer<Point2D> DistanceTo_Order()
    {
        return new DistanceToOrder(this);
    }

    /// <summary>
    /// 比较 <paramref name="obj"/> 是否与自身相等。
    /// </summary>
    /// <param name="obj">要判别相等的另一个对象，</param>
    /// <returns>相等则返回 <c>true</c>，否则返回 <c>false</c>。</returns>
    public override bool Equals(object? obj)
    {
        if (obj == this)
        {
            return true;
        }

        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        var that = (Point2D)obj;
        return Math.Abs(X - that.X) < float.Epsilon * 5 && Math.Abs(Y - that.Y) < float.Epsilon * 5;
    }

    /// <summary>
    /// 获取点的坐标字符串。
    /// </summary>
    /// <returns>形如 "(<see cref="X"/>, <see cref="Y"/>)" 的字符串。</returns>
    public override string ToString()
    {
        return "(" + X + ", " + Y + ")";
    }

    /// <summary>
    /// 获得二维点的哈希值。
    /// </summary>
    /// <returns>哈希值。</returns>
    public override int GetHashCode()
    {
        var hashX = X.GetHashCode();
        var hashY = Y.GetHashCode();
        return 31 * hashX + hashY;
    }
}