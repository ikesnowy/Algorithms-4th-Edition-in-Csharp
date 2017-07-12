using System;
using Generics;

namespace _1._3._41
{
    /*
     * 1.3.41
     * 
     * 复制队列。
     * 编写一个新的构造函数，使以下代码：
     * Queue r = new Queue(q);
     * 得到的 r 指向队列 q 的一个新的独立的副本。
     * 可以对 q 或 r 进行任意入列或出列操作但它们不会相互影响。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> r = new Queue<string>();
            r.Enqueue("first");
            r.Enqueue("second");
            r.Enqueue("third");

            Queue<string> q = new Queue<string>(r);

            Console.WriteLine("r:" + r);
            Console.WriteLine("q:" + q);

            r.Enqueue("fourth");
            q.Dequeue();

            Console.WriteLine("r:" + r);
            Console.WriteLine("q:" + q);
        }
    }
}
