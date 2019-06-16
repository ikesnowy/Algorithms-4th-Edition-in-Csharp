using System;
using Generics;

namespace _1._3._22
{
    class Program
    {
        // 将 t 插入到 x 之后
        static void Main(string[] args)
        {
            Node<string> first = new Node<string>();
            Node<string> second = new Node<string>();
            Node<string> third = new Node<string>();
            Node<string> fourth = new Node<string>();

            first.item = "first";
            second.item = "second";
            third.item = "third";
            fourth.item = "fourth";

            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = null;

            Node<string> current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }

            Node<string> t = new Node<string>();
            t.item = "t";

            t.next = second.next;
            second.next = t;

            Console.WriteLine();

            current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }
        }
    }
}
