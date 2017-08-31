using System;

namespace _1._4._31
{
    /*
     * 1.4.31
     * 
     * 三个栈实现的双向队列。
     * 使用三个栈实现一个双向队列，
     * 使得双向队列的每个操作所需的栈操作均摊之后为一个常数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Deque<string> deque = new Deque<string>();

            deque.PushLeft("first");
            deque.PushRight("second");
            deque.PushRight("third");
            deque.PushRight("fourth");

            Console.WriteLine($"size:{deque.Size()}");
            while (!deque.IsEmpty())
            {
                Console.WriteLine(deque.PopLeft());
            }

            Console.WriteLine();

            deque.PushLeft("fourth");
            deque.PushRight("third");
            deque.PushRight("second");
            deque.PushRight("first");

            while (!deque.IsEmpty())
            {
                Console.WriteLine(deque.PopRight());
            }
        }
    }
}
