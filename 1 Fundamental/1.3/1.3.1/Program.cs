using System;

namespace _1._3._1
{
    /*
     * 1.3.1
     * 
     * 为 FixedCapacityStackOfStrings 添加一个方法 isFull()。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            FixedCapacityStackOfStrings fixedStack = new FixedCapacityStackOfStrings(2);

            fixedStack.Push("lol");
            Console.WriteLine(fixedStack.IsFull()); // alse
            fixedStack.Push("lol2");
            Console.WriteLine(fixedStack.IsFull()); // rue
        }
    }
}
