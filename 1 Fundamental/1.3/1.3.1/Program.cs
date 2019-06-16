using System;

namespace _1._3._1
{
    
    class Program
    {
        static void Main(string[] args)
        {
            FixedCapacityStackOfStrings fixedStack = new FixedCapacityStackOfStrings(2);

            fixedStack.Push("lol");
            Console.WriteLine(fixedStack.IsFull()); // false
            fixedStack.Push("lol2");
            Console.WriteLine(fixedStack.IsFull()); // true
        }
    }
}
