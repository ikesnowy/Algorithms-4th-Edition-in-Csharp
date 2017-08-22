using System;
using Generics;

namespace _1._3._6
{
    /*
     * 1.3.6
     * 
     * 下面这段代码对队列 q 进行了什么操作？
     * 
     */
    class Program
    {
        //将队列反序
        static void Main(string[] args)
        {
            Queue<string> q = new Queue<string>();
            q.Enqueue("first");
            q.Enqueue("second");
            q.Enqueue("third");
            q.Enqueue("fourth");
            Stack<string> stack = new Stack<string>();
            while (!q.IsEmpty())
                stack.Push(q.Dequeue());
            while (!stack.IsEmpty())
                q.Enqueue(stack.Pop());

            Console.WriteLine(q.ToString());
        }
    }
}
