using System;

namespace _1._3._33
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Deque<string> a = new Deque<string>();
            ResizingArrayDeque<string> b = new ResizingArrayDeque<string>();

            a.PushLeft("first");
            b.PushLeft("first");
            a.PushRight("second");
            b.PushRight("second");
            Display(a, b);

            a.PopLeft();
            b.PopLeft();
            Display(a, b);
            a.PopRight();
            b.PopRight();
            Display(a, b);
        }

        static void Display(Deque<string> a, ResizingArrayDeque<string> b)
        {
            foreach (string s in a)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            foreach (string s in b)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
