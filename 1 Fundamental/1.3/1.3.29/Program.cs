using System;

namespace _1._3._29
{    
    class Program
    {
        static void Main(string[] args)
        {
            var input = "to be or not to - be - - that - - - is";
            var s = input.Split(' ');
            var queue = new Queue<string>();

            foreach (var n in s)
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
