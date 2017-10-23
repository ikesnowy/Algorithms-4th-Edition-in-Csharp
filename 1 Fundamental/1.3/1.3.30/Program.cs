using System;
using Generics;

namespace _1._3._30
{
    /*
     * 1.3.30
     * 
     * 编写一个函数，接受一条链表的首结点作为参数，
     * （破坏性地）将链表反转并返回链表的首结点。
     * 
     */
    class Program
    {
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

            first = Reverse(first);
            Console.WriteLine();

            current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }
        }

        // 使用书中的递归方式实现
        static Node<Item> Reverse<Item>(Node<Item> first)
        {
            if (first == null)
                return null;
            if (first.next == null)
                return first;
            Node<Item> second = first.next;
            Node<Item> rest = Reverse(second);
            second.next = first;
            first.next = null;
            return rest;
        }
    }
}
