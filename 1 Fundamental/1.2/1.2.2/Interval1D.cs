using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2._2
{
    /// <summary>
    /// 一维闭区间。
    /// </summary>
    class Interval1D
    {
        public static readonly Comparer<Interval1D> Min_Order = new MinEndpointComparer();
        public static readonly Comparer<Interval1D> Max_Order = new MaxEndpointComparer();
        public static readonly Comparer<Interval1D> Length_Order = new LengthComparer();

        public double Min { get; }
        public double Max { get; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="lo">一维区域的下界。</param>
        /// <param name="hi">一维区域的上界。</param>
        public Interval1D(double lo, double hi)
        {
            if (double.IsInfinity(lo) || double.IsInfinity(hi))
            {
                throw new ArgumentException("Endpoints must be finite");
            }
            if (double.IsNaN(lo) || double.IsNaN(hi))
            {
                throw new ArgumentException("Endpoints cannot be NaN");
            }

            if (lo <= hi)
            {
                this.Min = lo;
                this.Max = hi;
            }
            else
            {
                throw new ArgumentException("Illegal interval");
            }
        }

        /// <summary>
        /// 一维区域的长度。
        /// </summary>
        /// <returns>返回长度。</returns>
        public double Length()
        {
            return this.Max - this.Min;
        }

        /// <summary>
        /// 目标值是否处在区域内。
        /// </summary>
        /// <param name="x">如果目标值在区域内则返回 True，否则返回 False。</param>
        /// <returns></returns>
        public bool Contains(double x)
        {
            return x >= this.Min && x <= this.Max;
        }

        /// <summary>
        /// 判断两个区域是否相交。
        /// </summary>
        /// <param name="that">需要判断相交的另一个区域。</param>
        /// <returns>如果相交则返回 True，否则返回 False。</returns>
        public bool Intersect(Interval1D that)
        {
            if (this.Max < that.Min || that.Max < this.Min)
                return false;

            return true;
        }

        /// <summary>
        /// 将区域转换为 string，返回形如 "[lo, hi]" 的字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string s = "[" + this.Min + ", " + this.Max + "]";
            return s;
        }

        /// <summary>
        /// 判断两个区间是否相等。
        /// </summary>
        /// <param name="obj">相比较的区间。</param>
        /// <returns></returns>
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
            Interval1D that = (Interval1D)obj;
            return this.Min == that.Min && this.Max == that.Max;
        }

        /// <summary>
        /// 返回区间的哈希代码。
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            int hash1 = Min.GetHashCode();
            int hash2 = Max.GetHashCode();
            return 31 * hash1 + hash2;
        }

        private class MinEndpointComparer : Comparer<Interval1D>
        {
            public override int Compare(Interval1D a, Interval1D b)
            {
                if (a.Min < b.Min)
                {
                    return -1;
                }
                else if (a.Min > b.Min)
                {
                    return 1;
                }
                else if (a.Max < b.Max)
                {
                    return -1;
                }
                else if (a.Max > b.Max)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private class MaxEndpointComparer : Comparer<Interval1D>
        {
            public override int Compare(Interval1D a, Interval1D b)
            {
                if (a.Max < b.Max)
                {
                    return -1;
                }
                else if (a.Max > b.Max)
                {
                    return 1;
                }
                else if (a.Min < b.Min)
                {
                    return -1;
                }
                else if (a.Min > b.Min)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        private class LengthComparer : Comparer<Interval1D>
        {
            public override int Compare(Interval1D a, Interval1D b)
            {
                double alen = a.Length();
                double blen = b.Length();

                if (alen < blen)
                {
                    return -1;
                }
                else if (alen > blen)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
