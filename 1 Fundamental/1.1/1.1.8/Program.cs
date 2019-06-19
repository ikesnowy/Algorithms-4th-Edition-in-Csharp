using System;

namespace _1._1._8
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine('b');
            Console.WriteLine('b' + 'c'); // char 被隐式转为为 int 类型，取 ascii 码
            Console.WriteLine((char)('a' + 4)); // 强制转换后，ascii 码被转换为相应的字符
        }
    }
}