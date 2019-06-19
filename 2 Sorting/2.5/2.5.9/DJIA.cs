using System;

namespace _2._5._9
{
    /// <summary>
    /// 道琼斯指数。
    /// </summary>
    class DJIA : IComparable<DJIA>
    {
        public string Date { get; set; }
        public long Volume { get; set; }

        public DJIA(string date, long vol)
        {
            Date = date;
            Volume = vol;
        }

        public int CompareTo(DJIA other)
        {
            return Volume.CompareTo(other.Volume);
        }
    }
}
