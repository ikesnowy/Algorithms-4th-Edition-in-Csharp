using System;

namespace _1._4._29
{
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
