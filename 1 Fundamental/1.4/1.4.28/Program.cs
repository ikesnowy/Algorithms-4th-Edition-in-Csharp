using System;

namespace _1._4._28
{
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
