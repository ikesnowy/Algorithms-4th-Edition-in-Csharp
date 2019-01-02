using System;

namespace _2._4._25
{
    /// <summary>
    /// 立方和类，保存 a^3+b^3 的值。
    /// </summary>
    class CubeSum : IComparable<CubeSum>
    {
        /// <summary>
        /// 立方和。
        /// </summary>
        internal readonly long sum;
        /// <summary>
        /// 第一个数。
        /// </summary>
        internal readonly long i;
        /// <summary>
        /// 第二个数。
        /// </summary>
        internal readonly long j;

        /// <summary>
        /// 建立一个立方和类。
        /// </summary>
        /// <param name="i">立方和的第一个数。</param>
        /// <param name="j">立方和的第二个数。</param>
        public CubeSum(long i, long j)
        {
            this.sum = i * i * i + j * j * j;
            this.i = i;
            this.j = j;
        }

        /// <summary>
        /// 比较两个立方和的大小，返回 1, 0, -1 中的一个。
        /// </summary>
        /// <param name="other">需要与之比较的另一个数。</param>
        /// <returns></returns>
        public int CompareTo(CubeSum other)
        {
            return this.sum.CompareTo(other.sum);
        }

        /// <summary>
        /// 返回 "sum = i^3 + j^3" 形式的字符串。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.sum + " = " + this.i + "^3 + " + this.j + "^3";
        }
    }
}
