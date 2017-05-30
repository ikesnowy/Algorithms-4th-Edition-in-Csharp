using System;

namespace _1._1._2
{
    /*
     * 1.1.2 给出以下表达式的类型和值
     * 
     * a. (1 + 2.236) / 2
     * b. 1 + 2 + 3 + 4.0
     * c. 4.1 >= 4
     * d. 1 + 2 + "3"
     */
    class Program
    {
        static void Main(string[] args)
        {
            //var 变量名 = 初始值  根据初始值自动判断变量类型
            var a = (1 + 2.236) / 2;
            var b = 1 + 2 + 3 + 4.0;
            var c = 4.1 >= 4;
            var d = 1 + 2 + "3";

            //Console.WriteLine 向控制台输出一行
            //变量名.GetType() 返回变量类型
            //Type.ToString() 将类型名转换为字符串

            Console.WriteLine("\t变量名\t类型     \t值");
            Console.WriteLine($"\ta\t{a.GetType().ToString()}\t{a}");
            Console.WriteLine($"\tb\t{b.GetType().ToString()}\t{b}");
            Console.WriteLine($"\tc\t{c.GetType().ToString()}\t{c}");
            Console.WriteLine($"\td\t{d.GetType().ToString()}\t{d}");
        }
    }
}
