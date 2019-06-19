using System;

namespace SortApplication
{
    /// <summary>
    /// 日期类。
    /// </summary>
    public class Date : IComparable<Date>
    {
        /// <summary>
        /// 月份。
        /// </summary>
        /// <value>月份数据。</value>
        public int Month { get; }
        /// <summary>
        /// 日期。
        /// </summary>
        /// <value>日期数据。</value>
        public int Day { get; }
        /// <summary>
        /// 年份。
        /// </summary>
        /// <value>年份数据。</value>
        public int Year { get; }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="date">形如 "05/31/2017" 的字符串。</param>
        /// <exception cref="ArgumentException">输入日期格式不正确时抛出异常。</exception>
        public Date(string date)
        {
            var a = date.Split('/');
            if (a.Length != 3)
                throw new ArgumentException("Illgal Date");
            this.Month = int.Parse(a[0]);
            this.Day = int.Parse(a[1]);
            this.Year = int.Parse(a[2]);
        }

        /// <summary>
        /// 构造函数。
        /// </summary>
        /// <param name="m">交易月份。</param>
        /// <param name="d">交易日。</param>
        /// <param name="y">交易年份。</param>
        public Date(int m, int d, int y)
        {
            this.Month = m;
            this.Day = d;
            this.Year = y;
        }

        /// <summary>
        /// 将日期转换成字符串，格式为 dd/mm/yyyy。
        /// </summary>
        /// <returns>形如 05/22/2017 的字符串。</returns>
        public override string ToString()
        {
            return this.Month + "/" + this.Day + "/" + this.Year;
        }

        /// <summary>
        /// 比较两个日期是否相同。
        /// </summary>
        /// <param name="obj">需要比较的另一个对象。</param>
        /// <returns>相等返回 <c>true</c>，否则返回 <c>false</c>。</returns>
        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            var that = (Date)obj;
            return (this.Year == that.Year) && (this.Month == that.Month) && (this.Day == that.Day);
        }

        /// <summary>
        /// 获取日期的哈希值。
        /// </summary>
        /// <returns>日期的哈希值。</returns>
        public override int GetHashCode()
        {
            var hash = 17;
            hash = 31 * hash + this.Month;
            hash = 31 * hash + this.Year;
            hash = 31 * hash + this.Day;
            return hash;
        }

        /// <summary>
        /// 比较两个日期的先后。
        /// </summary>
        /// <param name="other">另一个日期。</param>
        /// <returns><paramref name="other"/> 较后时返回大于 0 的数，反之返回小于 0 的数，相等返回 0。</returns>
        public int CompareTo(Date other)
        {
            if (this.Year > other.Year)
                return 1;
            else if (this.Year < other.Year)
                return -1;

            if (this.Month > other.Month)
                return 1;
            else if (this.Month < other.Month)
                return -1;

            if (this.Day > other.Day)
                return 1;
            else if (this.Day < other.Day)
                return -1;

            return 0;
        }
    }
}
