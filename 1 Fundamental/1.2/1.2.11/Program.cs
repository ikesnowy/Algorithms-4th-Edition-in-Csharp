using System;
using Commercial;

namespace _1._2._11
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Date d = new Date(2, 29, 2017);
            Console.WriteLine(d);

            SmartDate sd = new SmartDate(2, 29, 2017);//抛出异常
            Console.WriteLine(sd);
        }
    }
}
