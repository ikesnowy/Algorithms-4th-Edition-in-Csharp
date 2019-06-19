using System;

namespace _1._3._48
{    
    class Program
    {
        static void Main(string[] args)
        {
            var destack = new DeStack<string>();
            var input = "to be or not to - be - - that - - - is";
            var s = input.Split(' ');

            foreach (var n in s)
            {
                if (!n.Equals("-"))
                    destack.PushRight(n);
                else if (!destack.IsRightEmpty())
                    Console.WriteLine(destack.PopRight());
            }

            foreach (var n in s)
            {
                if (!n.Equals("-"))
                    destack.PushLeft(n);
                else if (!destack.IsLeftEmpty())
                    Console.WriteLine(destack.PopLeft());
            }
        }
    }
}
