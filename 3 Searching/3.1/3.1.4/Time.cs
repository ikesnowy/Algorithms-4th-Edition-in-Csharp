using System;
using System.Text;

namespace _3._1._4
{
    /// <summary>
    /// 时间类。
    /// </summary>
    public class Time : IComparable<Time>
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public Time() : this(0, 0, 0) { }

        public Time(int hour, int minute, int second)
        {
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }

        public int CompareTo(Time other)
        {
            var result = this.Hour.CompareTo(other.Hour);
            if (result == 0)
                result = this.Minute.CompareTo(other.Minute);
            if (result == 0)
                result = this.Second.CompareTo(other.Second);
            return result;
        }

        public override bool Equals(object obj)
        {
            if (this == obj)
                return true;
            return CompareTo((Time)obj) == 0;
        }

        public override int GetHashCode()
        {
            var result = 1;
            result += this.Hour;
            result *= 31;
            result += this.Minute;
            result *= 31;
            result += this.Second;
            return result;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append(this.Hour < 10 ? "0" + this.Hour : this.Hour.ToString());
            sb.Append(":");
            sb.Append(this.Minute < 10 ? "0" + this.Minute : this.Minute.ToString());
            sb.Append(":");
            sb.Append(this.Second < 10 ? "0" + this.Second : this.Second.ToString());
            return sb.ToString();
        }
    }
}
