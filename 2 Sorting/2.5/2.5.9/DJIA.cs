using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.Date = date;
            this.Volume = vol;
        }

        public int CompareTo(DJIA other)
        {
            return this.Volume.CompareTo(other.Volume);
        }
    }
}
