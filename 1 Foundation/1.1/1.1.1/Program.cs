using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._1
{
    /*
     * 1.1.1 给出以下表达式的值
     * 
     * a. (0 + 15) / 2
     * b. 2.0e-6 * 100000000.1
     * c. true && false || true && true
     */
    class Program
    {
        static void Main(string[] args)
        {
            int a = (0 + 15) / 2;
            double b = Math.Pow(2.0, -6) * 100000000.1; //Math.Pow(double x, double y) 求x的y次方
            bool c = true && false || true && true;

            //Console.WriteLine 向控制台窗口输出一行
            Console.WriteLine($"a.{a}");
            Console.WriteLine($"b.{b}");
            Console.WriteLine($"c.{c}");
        }
    }
}
