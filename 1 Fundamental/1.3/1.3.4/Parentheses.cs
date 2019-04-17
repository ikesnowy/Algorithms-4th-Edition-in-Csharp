using System;
using Generics;

namespace _1._3._4
{
    
    class Parentheses
    {
        static bool isBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char i in input)
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
            string input = "[()]{}{[()()]()}";
            Console.WriteLine(isBalanced(input));
            string input2 = "[(])";
            Console.WriteLine(isBalanced(input2));
        }
    }
}
