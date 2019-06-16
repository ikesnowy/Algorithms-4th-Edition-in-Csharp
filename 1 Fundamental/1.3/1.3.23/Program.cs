using System;
using Generics;

namespace _1._3._23
{
    class Program
    {
        // x.next = t        x 的下一个是 t
        // t.next = x.next   t 的下一个和 x 的下一个相同（也就是 t）
        // 于是 t.next = t, 遍历会出现死循环。
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

            second.next = t;
            t.next = second.next;

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
