using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._12
{
    /*
     * 1.2.12
     * 
     * 为 SmartDate 添加一个方法 dayOfTheWeek()，
     * 为日期中每周的日返回 Monday、Tuesday、Wednesday、Thursday、Friday、Saturday 或 Sunday 中的适当值。
     * 你可以假定时间是 21 世纪。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            SmartDate Today = new SmartDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
            Console.WriteLine(Today.DayOfTheWeek());
        }
    }
}
