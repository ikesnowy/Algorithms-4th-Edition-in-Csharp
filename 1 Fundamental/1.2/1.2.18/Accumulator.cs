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
            N++;
            s = s + 1.0 * (N - 1) / N * (x - m) * (x - m);
            m = m + (x - m) / N;
        }
        public double Mean()
        {
            return m;
        }
        public double Var()
        {
            return s / (N - 1);
        }
        public double Stddev()
        {
            return Math.Sqrt(Var());
        }
        public override string ToString()
        {
            return "Mean (" + N + " values): " + string.Format("{0, 7:F5}", Mean());
        }
    }
}
