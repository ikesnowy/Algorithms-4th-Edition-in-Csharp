using System;

namespace _1._3._49
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "to be or not to - be - - that - - - is";
            string[] s = input.Split(' ');
            StackQueue<string> queue = new StackQueue<string>();

            foreach (string n in s)
            {
                if (!n.Equals("-"))
                    queue.Enqueue(n);
                else
                    Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
