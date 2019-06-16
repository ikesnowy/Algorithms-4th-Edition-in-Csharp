using System;
using Generics;

namespace _1._3._47
{    
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> q1 = new Queue<string>();
            q1.Enqueue("first");
            q1.Enqueue("second");

            Queue<string> q2 = new Queue<string>();
            q2.Enqueue("third");
            q2.Enqueue("fourth");

            q1 = Queue<string>.Catenation(q1, q2);
            Console.WriteLine(q1);

            Stack<string> s1 = new Stack<string>();
            s1.Push("first");
            s1.Push("second");

            Stack<string> s2 = new Stack<string>();
            s2.Push("third");
            s2.Push("fourth");

            s2 = Stack<string>.Catenation(s2, s1);
            Console.WriteLine(s2);

            Steque<string> sq1 = new Steque<string>();
            sq1.Push("first");
            sq1.Enqueue("second");

            Steque<string> sq2 = new Steque<string>();
            sq2.Push("third");
            sq2.Enqueue("fourth");

            sq1 = Steque<string>.Catenation(sq1, sq2);
            Console.WriteLine(sq1);
        }
    }
}
