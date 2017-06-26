using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercial
{
    public class Date : IComparable<Date>
    {
        public int Month { get; }//月
        public int Day { get; }//日
        public int Year { get; }//年

        public Date(string date)
        {
            string[] a = date.Split('/');
            if (a.Length != 3)
                throw new ArgumentException("Illgal Date");
            Month = int.Parse(a[0]);
            Day = int.Parse(a[1]);
            Year = int.Parse(a[2]);
        }

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

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null)
                return false;
            if (obj.GetType() != this.GetType())
                return false;
            Date that = (Date)obj;
            return (this.Year == that.Year) && (this.Month == that.Month) && (this.Day == that.Day);
        }

        public override int GetHashCode()
        {
            int hash = 17;
            hash = 31 * hash + this.Month;
            hash = 31 * hash + this.Year;
            hash = 31 * hash + this.Day;
            return hash;
        }

        int IComparable<Date>.CompareTo(Date other)
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
