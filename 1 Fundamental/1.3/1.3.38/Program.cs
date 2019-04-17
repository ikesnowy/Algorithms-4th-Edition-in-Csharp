using System;

namespace _1._3._38
{
    
    class Program
    {
        static void Main(string[] args)
        {
            ArrayBasedGeneralizeQueue<string> a = new ArrayBasedGeneralizeQueue<string>();
            LinkedListBasedGeneralizeQueue<string> b = new LinkedListBasedGeneralizeQueue<string>();

            a.Insert("first");
            b.Insert("first");
            a.Insert("second");
            b.Insert("second");
            a.Insert("third");
            b.Insert("third");

            Console.WriteLine(a.Delete(2));
            Console.WriteLine(b.Delete(2));
            Console.WriteLine(a.Delete(3));
            Console.WriteLine(b.Delete(3));
        }
    }
}
