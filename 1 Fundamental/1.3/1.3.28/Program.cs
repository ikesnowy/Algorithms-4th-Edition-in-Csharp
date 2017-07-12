using System;
using Generics;

namespace _1._3._28
{
    /*
     * 1.3.28
     * 
     * 用递归方法解答上一道练习。
     * 
     */
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

        static int Max(Node<int> first, int max = 0)
        {
            if (first == null)
                return max;
            if (max < first.item)
                return Max(first.next, first.item);
            else
                return Max(first.next, max);
        }
    }
}
