using System;

namespace _1._2._16
{
    /// <summary>
    /// 有理数类型。
    /// </summary>
    public class Rational
    {
        public long Numerator { get; }
        public long Denominator { get; }
        private bool isNagative;

        /// <summary>
        /// 构造一个有理数对象，自动变为最简形式。
        /// </summary>
        /// <param name="numerator">分子。</param>
        /// <param name="denominator">分母。</param>
        /// <exception cref="ArgumentException">分母为 0 时抛出。</exception>
        public Rational(long numerator, long denominator)
        {
            if (denominator == 0)
                throw new ArgumentException("Denominator cannot be 0");

            if (numerator < 0 && denominator < 0)
            {
                this.isNagative = false;
                numerator = -numerator;
                denominator = -denominator;
            }
            else if (numerator < 0 || denominator < 0)
            {
                this.isNagative = true;
            }
            else
            {
                this.isNagative = false;
            }

            long gcd = GCD(Math.Abs(numerator), Math.Abs(denominator));
            if (gcd != 1)
            {
                numerator /= gcd;
                denominator /= gcd;
            }
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        /// <summary>
        /// 将两个有理数对象相加，返回一个有理数。
        /// </summary>
        /// <param name="b">加数。</param>
        /// <returns>返回两个有理数的和。</returns>
        public Rational Plus(Rational b)
        {
            Rational result = new Rational(this.Numerator * b.Denominator + b.Numerator * this.Denominator, this.Denominator * b.Denominator);
            return result;
        }

        /// <summary>
        /// 以当前对象为被减数，减去一个有理数。
        /// </summary>
        /// <param name="b">减数。</param>
        /// <returns>返回两个数的差。</returns>
        public Rational Minus(Rational b)
        {
            Rational result = new Rational(this.Numerator * b.Denominator - b.Numerator * this.Denominator, this.Denominator * b.Denominator);
            return result;
        }

        /// <summary>
        /// 将两个有理数对象相乘。
        /// </summary>
        /// <param name="b">乘数。</param>
        /// <returns>返回两个数的积。</returns>
        public Rational Multiply(Rational b)
        {
            Rational result = new Rational(this.Numerator * b.Numerator, this.Denominator * b.Denominator);
            return result;
        }

        /// <summary>
        /// 以当前有理数为被除数，除以一个有理数。
        /// </summary>
        /// <param name="b">除数。</param>
        /// <returns>返回两个数的商。</returns>
        public Rational Divide(Rational b)
        {
            Rational result = new Rational(this.Numerator * b.Denominator, this.Denominator * b.Numerator);
            return result;
        }

        /// <summary>
        /// 求两个正整数的最大公约数。
        /// </summary>
        /// <param name="a">第一个整数。</param>
        /// <param name="b">第二个整数。</param>
        /// <returns>返回两个数的最大公约数。</returns>
        private long GCD(long a, long b)
        {
            if (b == 0)
                return a;
            return GCD(b, a % b);
        }

        /// <summary>
        /// 检查两个有理数是否相等。
        /// </summary>
        /// <param name="obj">另一个对象。</param>
        /// <returns>相等则返回 true，否则返回 false。</returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;

            Rational that = (Rational)obj;
            return (this.Numerator == that.Numerator) && (this.Denominator == that.Denominator);
        }

        /// <summary>
        /// 生成哈希值。
        /// </summary>
        /// <returns>返回一个哈希值。</returns>
        public override int GetHashCode()
        {
            return 31 * this.Numerator.GetHashCode() + this.Denominator.GetHashCode();
        }

        /// <summary>
        /// 返回形如 “分子/分母” 的字符串。
        /// </summary>
        /// <returns>返回形如 “分子/分母” 的字符串。</returns>
        public override string ToString()
        {
            string result = "";
            if (this.isNagative)
                result += "-";
            result += Math.Abs(this.Numerator) + "/" + Math.Abs(this.Denominator);
            return result;
        }
    }
}
