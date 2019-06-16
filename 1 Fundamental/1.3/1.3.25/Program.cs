using System;
using Generics;

namespace _1._3._25
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<string> first = new Node<string>();
            Node<string> second = new Node<string>();
            Node<string> third = new Node<string>();

            first.item = "first";
            second.item = "second";
            third.item = "third";

            first.next = second;
            second.next = null;

            Node<string> current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }

            InsertAfter(second, third);
            Console.WriteLine();

            current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }
        }

        static void InsertAfter<Item>(Node<Item> A, Node<Item> B)
        {
            if (A == null || B == null)
                return;
            B.next = A.next;
            A.next = B;
        }
    }
}
