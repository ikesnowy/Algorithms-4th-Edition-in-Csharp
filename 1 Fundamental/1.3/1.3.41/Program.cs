﻿using System;
using Generics;

namespace _1._3._41
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> r = new Queue<string>();
            r.Enqueue("first");
            r.Enqueue("second");
            r.Enqueue("third");

            Queue<string> q = new Queue<string>(r);

            Console.WriteLine("r:" + r);
            Console.WriteLine("q:" + q);

            r.Enqueue("fourth");
            q.Dequeue();

            Console.WriteLine("r:" + r);
            Console.WriteLine("q:" + q);
        }
    }
}
