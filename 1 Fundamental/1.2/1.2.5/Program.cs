using System;

namespace _1._2._5
{
    
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
