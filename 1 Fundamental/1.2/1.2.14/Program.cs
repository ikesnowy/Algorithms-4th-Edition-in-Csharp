using System;
using Commercial;

namespace _1._2._14
{

    class Program
    {
        static void Main(string[] args)
        {
            Transaction a = new Transaction("Turing 01/01/1991 12.12");
            Transaction b = new Transaction("Turing 01/01/1991 12.12");
            Transaction c = new Transaction("Turing 01/01/1991 12.13");

            Console.WriteLine(a.Equals(b)); // True
            Console.WriteLine(a.Equals(c)); // False
        }
    }
}