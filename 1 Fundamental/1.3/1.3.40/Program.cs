using System;

namespace _1._3._40
{
    /*
     * 1.3.40
     * 
     * 前移编码。
     * 从标准输入读取一串字符，使用链表保存这些字符并删除重复字符。
     * 当你读取了一个从未见过的字符时，将它插入表头。
     * 当你读取了一个重复的字符时，将它从链表中删去并再次插入表头。
     * 将你的程序命名为 MoveToFront：
     * 它实现了著名的前移编码策略，这种策略假设最近访问过的元素很可能会再次访问，
     * 因此可以用于缓存、数据压缩等许多场景。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MoveToFront<string> move = new MoveToFront<string>();
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
