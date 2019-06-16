using System;

namespace _1._3._48
{    
    class Program
    {
        static void Main(string[] args)
        {
            DeStack<string> destack = new DeStack<string>();
            string input = "to be or not to - be - - that - - - is";
            string[] s = input.Split(' ');

            foreach (string n in s)
            {
                if (!n.Equals("-"))
                    destack.PushRight(n);
                else if (!destack.IsRightEmpty())
                    Console.WriteLine(destack.PopRight());
            }

            foreach (string n in s)
            {
                if (!n.Equals("-"))
                    destack.PushLeft(n);
                else if (!destack.IsLeftEmpty())
                    Console.WriteLine(destack.PopLeft());
            }
        }
    }
}
