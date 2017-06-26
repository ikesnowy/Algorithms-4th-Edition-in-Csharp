using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Commercial;

namespace _1._2._11
{
    /*
     * 1.2.11
     * 
     * 根据 Date 的 API 实现一个 SmartDate 类型，
     * 在日期非法时抛出一个异常。
     * 
     */
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
