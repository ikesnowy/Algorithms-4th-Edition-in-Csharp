using System;

namespace _1._4._28
{
    /*
     * 1.4.28
     * 
     * 一个队列实现的栈。
     * 使用一个队列实现一个栈，使得每个栈操作所需的队列操作数量为线性级别。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QueueStack<string> stack = new QueueStack<string>();
            string[] input = "to be or not to - be - - that - - - is".Split(' ');

            foreach (string s in input)
            {
                if (s == "-")
                {
                    Console.WriteLine(stack.Pop());
                }
                else
                {
                    stack.Push(s);
                }
            }
        }
    }
}
