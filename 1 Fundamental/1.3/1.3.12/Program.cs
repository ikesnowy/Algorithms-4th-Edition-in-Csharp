using System;
using Generics;

namespace _1._3._12
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> src = new Stack<string>();
            src.Push("first");
            src.Push("second");
            src.Push("third");

            Stack<string> des = CopyTo(src);
            
            while (!des.IsEmpty())
            {
                Console.WriteLine(des.Pop());
            }

        }

        static Stack<string> CopyTo(Stack<string> src)
        {
            Stack<string> des = new Stack<string>();
            Stack<string> temp = new Stack<string>();

            foreach (string s in src)
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
