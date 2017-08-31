using System;

namespace _1._4._29
{
    /*
     * 1.4.29
     * 
     * 两个栈实现的 steque。
     * 用两个栈实现一个 steque（请见练习 1.3.32），
     * 使得每个 steque 操作所需的栈操作均摊后为一个常数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            StackSteque<string> stackSteque = new StackSteque<string>();
            string[] input = "to be or not to - be - - that - - - is".Split(' ');

            foreach (String s in input)
            {
                if (s == "-")
                {
                    Console.WriteLine(stackSteque.Pop());
                }
                else
                {
                    stackSteque.Push(s);
                }
            }

            while (!stackSteque.IsEmpty())
            {
                stackSteque.Pop();
            }
            Console.WriteLine();

            foreach (String s in input)
            {
                if (s == "-")
                {
                    Console.WriteLine(stackSteque.Pop());
                }
                else
                {
                    stackSteque.Enqueue(s);
                }
            }
        }
    }
}
