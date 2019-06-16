using System;
using Generics;

namespace _1._3._27
{
    class Program
    {
        static void Main(string[] args)
        {
            Node<int> first = new Node<int>();
            Node<int> second = new Node<int>();
            Node<int> third = new Node<int>();
            Node<int> fourth = new Node<int>();

            first.item = 1;
            second.item = 2;
            third.item = 3;
            fourth.item = 4;

            first.next = second;
            second.next = third;
            third.next = fourth;
            fourth.next = null;

            Console.WriteLine("Max:" + Max(first));
        }

        static int Max(Node<int> first)
        {
            int max = 0;

            Node<int> current = first;
            while (current != null)
            {
                if (max < current.item)
                {
                    max = current.item;
                }
                current = current.next;
            }

            return max;
        }
    }
}
