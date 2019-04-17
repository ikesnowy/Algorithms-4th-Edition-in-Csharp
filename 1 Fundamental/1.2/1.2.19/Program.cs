using System;
using Commercial;

namespace _1._2._19
{
    
    class Program
    {
        // 见 Commercial 库中的 Date.cs 和 Transaction.cs
        static void Main(string[] args)
        {
            Date d = new Date("5/22/1939");
            Console.WriteLine(d);

            Transaction a = new Transaction("Turing 01/01/1991 12.12");
            Console.WriteLine(a);
        }
    }
}
