using System;
using Generics;

namespace _1._3._7
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("first");
            stack.Push("second");

            Console.WriteLine(stack.Peek());
        }
    }
}
