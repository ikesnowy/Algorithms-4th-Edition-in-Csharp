using System;

namespace _1._3._40
{    
    class Program
    {
        static void Main(string[] args)
        {
            var move = new MoveToFront<string>();
            Console.WriteLine("输入你的内容，回车分隔，自动返回前移编码后链表的内容。");
            string input;
            while (true)
            {
                input = Console.ReadLine();
                move.Insert(input);
                Console.WriteLine(move);
            }
        }
    }
}
