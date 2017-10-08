using System;

namespace _1._3._32
{
    /*
     * 1.3.32
     * 
     * Steque
     * 一个以栈为目标的队列（或称 steque），
     * 是一种支持 push、pop 和 enqueue 操作的数据类型。
     * 为这种抽象数据类定义一份 API 并给出一份基于链表的实现。
     * 
     */
    class Program
    {
        // 见 Steque.cs
        static void Main(string[] args)
        {
            Steque<string> steque = new Steque<string>();
            steque.Push("first");
            steque.Push("second");
            steque.Push("third");
            steque.Enqueue("fourth");
            Console.WriteLine(steque.ToString());
            steque.Pop();
            steque.Pop();
            steque.Pop();
            steque.Pop();
            Console.WriteLine(steque.ToString());
            steque.Enqueue("first");
            steque.Push("zero");
            Console.WriteLine(steque.ToString());
        }
    }
}
