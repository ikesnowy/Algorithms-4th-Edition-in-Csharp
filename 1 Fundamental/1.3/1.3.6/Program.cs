using System;
using Generics;

namespace _1._3._6
{
    class Program
    {
        // 将队列反序
        static void Main(string[] args)
        {
            var q = new Queue<string>();
            q.Enqueue("first");
            q.Enqueue("second");
            q.Enqueue("third");
            q.Enqueue("fourth");
            var stack = new Stack<string>();
            while (!q.IsEmpty())
                stack.Push(q.Dequeue());
            while (!stack.IsEmpty())
                q.Enqueue(stack.Pop());

            Console.WriteLine(q.ToString());
        }
    }
}
