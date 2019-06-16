using System;

namespace _1._2._18
{
    public class Accumulator
    {
        private double m;
        private double s;
        private int N;

        public void AddDataValue(double x)
        {
            this.N++;
            this.s = this.s + 1.0 * (this.N - 1) / this.N * (x - this.m) * (x - this.m);
            this.m = this.m + (x - this.m) / this.N;
        }
        public double Mean()
        {
            return this.m;
        }
        public double Var()
        {
            return this.s / (this.N - 1);
        }
        public double Stddev()
        {
            return Math.Sqrt(this.Var());
        }
        public override string ToString()
        {
            return "Mean (" + this.N + " values): " + string.Format("{0, 7:F5}", Mean());
        }
    }
}
