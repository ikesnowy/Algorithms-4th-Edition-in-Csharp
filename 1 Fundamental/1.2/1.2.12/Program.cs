using System;

namespace _1._2._12
{
    
    class Program
    {
        static void Main(string[] args)
        {
            SmartDate Today = new SmartDate(DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Year);
            Console.WriteLine(Today.DayOfTheWeek());
        }
    }
}
