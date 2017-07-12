using System;
using Generics;

namespace _1._3._7
{
    /*
     * 1.3.7
     * 
     * 为 Stack 添加一个方法 peek()，
     * 返回栈中最近添加的元素（而不弹出它）。
     * 
     */
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
