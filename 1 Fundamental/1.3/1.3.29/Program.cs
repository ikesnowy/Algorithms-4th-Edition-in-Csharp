using System;

namespace _1._3._29
{
    
    class Program
    {
        static void Main(string[] args)
        {
            string input = "to be or not to - be - - that - - - is";
            string[] s = input.Split(' ');
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
        }
    }
}
