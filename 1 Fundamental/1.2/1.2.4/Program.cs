using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._4
{
    /*
     * 1.2.4
     * 
     * 以下这段代码会打印出什么？
     * String string1 = "hello";
     * String string2 = string1;
     * string1 = "world";
     * StdOut.println(string1);
     * StdOut.println(string2);
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string string1 = "hello";
            string string2 = string1;
            string1 = "world";
            Console.WriteLine(string1);
            Console.WriteLine(string2);
        }
    }
}
