using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._30
{
    /*
     * 1.4.30
     * 
     * 一个栈和一个 steque 实现的双向队列。
     * 使用一个栈和一个 steque 实现一个双向队列（请见练习 1.3.32），
     * 使得双向队列的每个操作所需的栈和 steque 操作均摊后为一个常数。
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
