using System;
using Generics;

namespace _1._3._37
{
    class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople = 7;
            int callForDeath = 2;

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < numOfPeople; i++)
            {
                queue.Enqueue(i);
            }

            while (!queue.IsEmpty())
            {
                for (int i = 0; i < callForDeath - 1; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
        }
    }
}
