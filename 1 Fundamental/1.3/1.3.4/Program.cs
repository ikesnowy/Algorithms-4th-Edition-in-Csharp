using System;
using Generics;

namespace _1._3._4
{
    class Program
    {
        static bool isBalanced(string input)
        {
            var stack = new Stack<char>();

            foreach (var i in input)
            {
                if (i == '(' || i == '[' || i == '{')
                    stack.Push(i);
                else
                {
                    if (stack.Peek() == '(' && i == ')')
                        stack.Pop();
                    else if (stack.Peek() == '{' && i == '}')
                        stack.Pop();
                    else if (stack.Peek() == '[' && i == ']')
                        stack.Pop();
                    else
                        return false;
                }
            }

            return stack.IsEmpty();
        }

        static void Main(string[] args)
        {
            var input = "[()]{}{[()()]()}";
            Console.WriteLine(isBalanced(input));
            var input2 = "[(])";
            Console.WriteLine(isBalanced(input2));
        }
    }
}
