using System;

namespace _1._3._50
{    
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("first");
            stack.Push("second");
            stack.Push("third");
            stack.Push("fourth");

            foreach (string s in stack)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            foreach (string s in stack)
            {
                Console.Write(s + " ");
                stack.Pop();// 抛出异常
            }
        }
    }
}
