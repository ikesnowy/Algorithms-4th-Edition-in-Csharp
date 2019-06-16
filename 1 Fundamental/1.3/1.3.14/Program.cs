using System;

namespace _1._3._14
{
    class Program
    {
        public static void Main(string[] args)
        {
            ResizingArrayQueueOfStrings<string> queue = new ResizingArrayQueueOfStrings<string>();
            string[] input = "to be or not to - be - - that - - - is".Split(' ');

            foreach (string s in input)
            {
                if (!s.Equals("-"))
                    queue.Enqueue(s);
                else if (!queue.IsEmpty())
                    Console.Write(queue.Dequeue() + ' ');
            }
            Console.WriteLine("(" + queue.Size() + " left on queue)");
        }
    }
}
