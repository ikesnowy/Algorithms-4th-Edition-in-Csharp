using System;
using System.Collections.Generic;
using System.Text;

namespace _1._2._2
{
    class Interval1D
    {
        public double Lo { get; set; }
        public double Hi { get; set; }

        public Interval1D(double lo, double hi)
        {
            this.Lo = lo;
            this.Hi = hi;
        }

        public double Length()
        {
            return this.Hi - this.Lo;
        }

        public bool Contains(double x)
        {
            return x >= this.Lo && x < this.Hi;
        }

        public bool Intersect(Interval1D that)
        {
            if (this.Hi <= that.Lo || this.Lo >= that.Hi)
                return false;

            return true;
        }

        public override string ToString()
        {
            string s = "[" + Lo + ", " + Hi + ")";
            return s;
        }
    }
}
