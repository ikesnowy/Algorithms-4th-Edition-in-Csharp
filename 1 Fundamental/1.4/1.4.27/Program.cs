using System;

namespace _1._4._27
{
    class Program
    {
        static void Main(string[] args)
        {
            StackQueue<string> queue = new StackQueue<string>();
            string[] input = "to be or not to - be - - that - - - is".Split(' ');
            
            foreach (string s in input)
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
