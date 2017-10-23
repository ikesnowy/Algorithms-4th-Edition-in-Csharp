using System;

namespace _1._2._5
{
    /*
     * 1.2.5
     * 
     * 以下这段代码会打印出什么？
     * String s = "Hello World";
     * s.toUpperCase();
     * s.substring(6, 11);
     * StdOut.println(s);
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string s = "Hello World";
            s.ToUpper();
            s.Substring(6, 5);  // C# 中两个参数分别代表子串起始下标和长度
            Console.WriteLine(s);
        }
    }
}
