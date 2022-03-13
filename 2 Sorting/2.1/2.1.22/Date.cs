using System;

namespace _2._1._22;

public class Date : IComparable<Date>
{
    public int Month { get; }   // 月
    public int Day { get; }     // 日
    public int Year { get; }    // 年

    /// <summary>
    /// 构造函数。
    /// </summary>
    /// <param name="date">形如 "05/31/2017" 的字符串。</param>
    public Date(string date)
    {
        var a = date.Split('/');
        if (a.Length != 3)
            throw new ArgumentException("Illgal Date");
        Month = int.Parse(a[0]);
        Day = int.Parse(a[1]);
        Year = int.Parse(a[2]);
    }

    /// <summary>
    /// 构造函数。
    /// </summary>
    /// <param name="m">交易月份。</param>
    /// <param name="d">交易日。</param>
    /// <param name="y">交易年份。</param>
    public Date(int m, int d, int y)
    {
        Month = m;
        Day = d;
        Year = y;
    }

    /// <summary>
    /// 返回形如 05/22/2017 的字符串。
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Month + "/" + Day + "/" + Year;
    }

    /// <summary>
    /// 比较两个日期是否相同。
    /// </summary>
    /// <param name="obj">需要比较的另一个对象。</param>
    /// <returns></returns>
    public override bool Equals(object obj)
    {
        if (obj == this)
            return true;
        if (obj == null)
            return false;
        if (obj.GetType() != GetType())
            return false;
        var that = (Date)obj;
        return (Year == that.Year) && (Month == that.Month) && (Day == that.Day);
    }

    /// <summary>
    /// 获取日期的哈希值。
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
        var hash = 17;
        hash = 31 * hash + Month;
        hash = 31 * hash + Year;
        hash = 31 * hash + Day;
        return hash;
    }

    /// <summary>
    /// 比较两个日期的先后。
    /// </summary>
    /// <param name="other">另一个日期。</param>
    /// <returns></returns>
    public int CompareTo(Date other)
    {
        if (Year > other.Year)
            return 1;
        if (Year < other.Year)
            return -1;

        if (Month > other.Month)
            return 1;
        if (Month < other.Month)
            return -1;

        if (Day > other.Day)
            return 1;
        if (Day < other.Day)
            return -1;

        return 0;
    }
}