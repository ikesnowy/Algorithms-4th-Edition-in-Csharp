using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2._2
{
    class Interval1D
    {
        public double Lo { get; set; }
        public double Hi { get; set; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="lo">一维区域的下界（可以取到）</param>
        /// <param name="hi">一维区域的上界（不可取到）</param>
        public Interval1D(double lo, double hi)
        {
            this.Lo = lo;
            this.Hi = hi;
        }

        /// <summary>
        /// 一维区域的长度。
        /// </summary>
        /// <returns>返回长度</returns>
        public double Length()
        {
            return this.Hi - this.Lo;
        }

        /// <summary>
        /// 目标值是否处在区域内。
        /// </summary>
        /// <param name="x">如果目标值在区域内则返回 True，否则返回 False。</param>
        /// <returns></returns>
        public bool Contains(double x)
        {
            return x >= this.Lo && x < this.Hi;
        }

        /// <summary>
        /// 判断两个区域是否相交。
        /// </summary>
        /// <param name="that">需要判断相交的另一个区域</param>
        /// <returns>如果相交则返回 True，否则返回 False。</returns>
        public bool Intersect(Interval1D that)
        {
            if (this.Hi <= that.Lo || this.Lo >= that.Hi)
                return false;

            return true;
        }

        /// <summary>
        /// 将区域转换为 string，返回形如 "[lo, hi)" 的字符串。
        /// </summary>
        /// <returns>返回形如 "[lo, hi)" 的字符串</returns>
        public override string ToString()
        {
            string s = "[" + Lo + ", " + Hi + ")";
            return s;
        }
    }
}
