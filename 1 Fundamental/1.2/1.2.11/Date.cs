using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._11
{
    /// <summary>
    /// 日期类，保存一个日期。
    /// </summary>
    class Date
    {
        public int Month { get; }//月
        public int Day { get; }//日
        public int Year { get; }//年

        public Date(int m, int d, int y)
        {
            this.Month = m;
            this.Day = d;
            this.Year = y;
        }

        public override string ToString()
        {
            return this.Month + "/" + this.Day + "/" + this.Year;
        }
    }
}
