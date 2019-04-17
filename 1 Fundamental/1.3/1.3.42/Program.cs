using System;
using Generics;

namespace _1._3._42
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> s = new Stack<string>();
            s.Push("third");
            s.Push("second");
            s.Push("first");

            Stack<string> t = new Stack<string>(s);

            Console.WriteLine("s:" + s);
            Console.WriteLine("t:" + t);

            t.Pop();
            s.Push("zero");

            Console.WriteLine("s:" + s);
            Console.WriteLine("t:" + t);
        }
    }
}
