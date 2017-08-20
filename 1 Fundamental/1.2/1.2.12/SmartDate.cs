using System;

namespace _1._2._12
{
    /// <summary>
    /// 智能日期类。
    /// </summary>
    class SmartDate
    {
        public int Month { get; }// 
        public int Day { get; }// 
        public int Year { get; }// 

        // 个月对应的天数，第 0 位空出来
        static private int[] dayOfMonth = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        // 星期对应的名称。
        static private string[] dayOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        /// <summary>
        /// 建立一个 SmartDate 对象。
        /// </summary>
        /// <param name="m">月。</param>
        /// <param name="d">日。</param>
        /// <param name="y">年。</param>
        public SmartDate(int m, int d, int y)
        {
            if (Vaildation(m, d, y) == false)
                throw new FormatException("Invaild Date");
            this.Month = m;
            this.Day = d;
            this.Year = y;
        }

        /// <summary>
        /// 计算当前日期是星期几，返回对应的星期名称。
        /// </summary>
        /// <returns></returns>
        public string DayOfTheWeek()
        {
            int d = this.Day;
            int m = this.Month;
            int y = this.Year;
            
            if (m < 3)
            {
                m += 12;
                y--;
            }

            // 用蔡勒公式计算，参见 http:// ww.cnblogs.com/mq0036/p/3534314.html
            int w = (d + 2 * m + 3 * (m + 1) / 5 + y + y / 4 - y / 100 + y / 400) % 7;

            return dayOfWeek[w];
        }

        /// <summary>
        /// 验证日期是否合法。
        /// </summary>
        /// <param name="m">月。</param>
        /// <param name="d">日。</param>
        /// <param name="y">年。</param>
        /// <returns>合法返回 true，否则返回 false。</returns>
        private bool Vaildation(int m, int d, int y)
        {
            if (y < 0)
                return false;

            bool isLeapYear = false;

            if (m > 12 || m < 1)
                return false;
            if (d < 0)
                return false;
            if (m == 2 && d > 29 && isLeapYear)
                return false;
            if (d > dayOfMonth[m])
                return false;

            return true;
        }

        /// <summary>
        /// 检查是否是闰年。
        /// </summary>
        /// <param name="y">年。</param>
        /// <returns>是闰年则返回 true，否则返回 false。</returns>
        private bool IsLeapYear(int y)
        {
            if (y % 400 == 0)
                return true;
            if (y % 100 != 0 && y % 4 == 0)
                return true;

            return false;
        }

        /// <summary>
        /// 返回形如 "01/31/2017" 格式的日期。
        /// </summary>
        /// <returns>返回形如 "01/31/2017" 格式的日期。</returns>
        public override string ToString()
        {
            return this.Month + "/" + this.Day + "/" + this.Year;
        }
    }
}
