using System;
using Generics;

namespace _1._3._12
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = new Stack<string>();
            src.Push("first");
            src.Push("second");
            src.Push("third");

            var des = CopyTo(src);

            while (!des.IsEmpty())
            {
                Console.WriteLine(des.Pop());
            }

        }

        static Stack<string> CopyTo(Stack<string> src)
        {
            var des = new Stack<string>();
            var temp = new Stack<string>();

            foreach (var s in src)
            {
                temp.Push(s);
            }

            while (!temp.IsEmpty())
            {
                des.Push(temp.Pop());
            }

            return des;
        }
    }
}
