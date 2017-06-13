using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._1
{
    /// <summary>
    /// Point2D 二维点类
    /// </summary>
    class Point2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double R { get; }
        public double Theta { get; }
        public int Radius { get; set; }

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;

            this.R = Math.Sqrt(X * X + Y * Y);
            this.Theta = Math.Acos(X / R);
            this.Radius = 2;
        }

        /// <summary>
        /// 基于当前点返回一个 Point 类对象
        /// </summary>
        /// <returns>Point 类对象</returns>
        public Point GetPoint()
        {
            return new Point((int)X, (int)Y);
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

        public void Draw(Graphics g)
        {
            g.FillEllipse(Brushes.Black, (int)X - Radius, (int)Y - Radius, Radius * 2, Radius * 2);
        }
    }
}
