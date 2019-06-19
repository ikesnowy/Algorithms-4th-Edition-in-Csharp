using System;
using Generics;

namespace _1._3._15
{
    class Program
    {
        static void Main(string[] args)
        {
            var queue = new Queue<string>();
            var input = "1 2 3 4 5 6 7 8 9 10".Split(' ');
            var k = 4;

            foreach (var s in input)
            {
                queue.Enqueue(s);
            }

            var count = queue.Size() - k;
            for (var i = 0; i < count; i++)
            {
                queue.Dequeue();
            }

            Console.WriteLine(queue.Peek());
        }
    }
}
