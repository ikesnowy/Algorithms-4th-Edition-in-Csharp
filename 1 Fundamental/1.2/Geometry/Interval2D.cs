using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Geometry
{
    /// <summary>
    /// 二维闭合区间
    /// </summary>
    public class Interval2D
    {
        private readonly Interval1D X;
        private readonly Interval1D Y;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="x">x 轴上的范围</param>
        /// <param name="y">y 轴上的范围</param>
        public Interval2D(Interval1D x, Interval1D y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 判断两个平面是否相交
        /// </summary>
        /// <param name="that">需要判断的另一个平面</param>
        /// <returns></returns>
        public bool Intersects(Interval2D that)
        {
            if (!this.X.Intersect(that.X))
            {
                return false;
            }

            if (!this.Y.Intersect(that.Y))
            {
                return false;
            }

            return true;
        }

    }
}
