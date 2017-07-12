using System;

namespace _1._3._29
{
    /*
     * 1.3.29
     * 
     * 用环形链表实现 Queue。
     * 环形链表也是一条链表，只是没有任何结点的链接为空，且只要链表非空则 last.next 的值为 first。
     * 只能使用一个 Node 类型的实例变量（last）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string input = "to be or not to - be - - that - - - is";
            string[] s = input.Split(' ');
            Queue<string> queue = new Queue<string>();

            foreach (string n in s)
            {
                if (!n.Equals("-"))
                    queue.Enqueue(n);
                else if (!queue.IsEmpty())
                    Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine($"({queue.Size()}) left on queue");
            Console.WriteLine(queue);
        }
    }
}
