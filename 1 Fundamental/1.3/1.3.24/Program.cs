﻿using System;
using Generics;

namespace _1._3._24
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = new Node<string>();
            var second = new Node<string>();
            var third = new Node<string>();
            var fourth = new Node<string>();

            first.item = "first";
            second.item = "second";
            third.item = "third";
            fourth.item = "fourth";

            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = null;

            var current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }

            RemoveAfter(second);
            Console.WriteLine();

            current = first;
            while (current != null)
            {
                Console.Write(current.item + " ");
                current = current.next;
            }
        }

        static void RemoveAfter<Item>(Node<Item> i)
        {
            i.next = null;
        }
    }
}
