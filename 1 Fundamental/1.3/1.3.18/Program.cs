using System;
using Generics;

namespace _1._3._18
{
    
    class Program
    {
        // 删除 x 的后一个结点。
        static void Main(string[] args)
        {
            Node<string> x = new Node<string>();
            x.item = "first";
            Node<string> y = new Node<string>();
            y.item = "second";
            x.next = y;
            Node<string> z = new Node<string>();
            z.item = "third";
            y.next = z;

            Console.WriteLine("x: " + x.item);
            Console.WriteLine("x.next: " + x.next.item);
            x.next = x.next.next;
            Console.WriteLine();
            Console.WriteLine("x: " + x.item);
            Console.WriteLine("x.next: " + x.next.item);
        }
    }
}
