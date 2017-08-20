using System;

namespace _1._2._18
{
    /// <summary>
    /// 累加器类。
    /// </summary>
    public class Accumulator
    {
        private double m;
        private double s;
        private int N;

        /// <summary>
        /// 添加一个新的数据值。
        /// </summary>
        /// <param name="x">要添加的值。</param>
        public void AddDataValue(double x)
        {
            this.N++;
            this.s = this.s + 1.0 * (this.N - 1) / this.N * (x - this.m) * (x - this.m);
            this.m = this.m + (x - this.m) / this.N;
        }

        /// <summary>
        /// 求所有数据的平均值。
        /// </summary>
        /// <returns>返回平均值。</returns>
        public double Mean()
        {
            return this.m;
        }

        /// <summary>
        /// 计算方差。
        /// </summary>
        /// <returns>返回方差。</returns>
        public double Var()
        {
            return this.s / (this.N - 1);
        }

        /// <summary>
        /// 计算标准差。
        /// </summary>
        /// <returns>返回标准差。</returns>
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
