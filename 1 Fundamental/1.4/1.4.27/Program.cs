using System;

namespace _1._4._27
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new StackQueue<string>();
            var input = "to be or not to - be - - that - - - is".Split(' ');
            
            foreach (var s in input)
            {
                if (s == "-")
                {
                    Console.WriteLine(queue.Dequeue());
                }
                else
                {
                    queue.Enqueue(s);
                }
            }
        }
    }
}
