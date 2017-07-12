using System;
using Generics;

namespace Generics_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Bag<string> bag = new Bag<string>();
            bag.Add("lalala");
            bag.Add("lalala");
            bag.Add("lalala");

            Console.WriteLine(bag.Size());
            foreach (string n in bag)
            {
                Console.WriteLine(n);
            }
            Console.WriteLine();

            Stack<string> stack = new Stack<string>();
            string input = "to be or not to - be - - that - - - is";
            string[] s = input.Split(' ');

            foreach (string n in s)
            {
                if (!n.Equals("-"))
                    stack.Push(n);
                else if (!stack.IsEmpty())
                    Console.WriteLine(stack.Pop());
            }

            Console.WriteLine($"({stack.Size()}) left on stack");
            Console.WriteLine(stack);
            Console.WriteLine();

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

            LinkedList<string> link = new LinkedList<string>();
            link.Insert("first");
            link.Insert("second");
            link.Insert("third");
            link.Insert("fourth");

            Console.WriteLine(link.ToString());
            Console.WriteLine(link.Find(2));
            Console.WriteLine(link.Delete(2));
            Console.WriteLine(link.ToString());
            link.Insert("second", 2);
            Console.WriteLine(link.ToString());
        }
    }
}
