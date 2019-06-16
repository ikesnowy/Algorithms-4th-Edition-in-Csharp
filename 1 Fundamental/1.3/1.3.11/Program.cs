using System;
using Generics;

namespace _1._3._11
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string[] input = "7 16 * 5 + 16 * 3 + 16 * 1 +".Split(' ');

            foreach (string n in input)
            {
                if (n == " ")
                {
                    continue;
                }
                else if (n == "+")
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (n == "-")
                {
                    int temp = stack.Pop();
                    stack.Push(stack.Pop() - temp);
                }
                else if (n == "*")
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (n == "/")
                {
                    int temp = stack.Pop();
                    stack.Push(stack.Pop() / temp);
                }
                else
                {
                    stack.Push(int.Parse(n));
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
