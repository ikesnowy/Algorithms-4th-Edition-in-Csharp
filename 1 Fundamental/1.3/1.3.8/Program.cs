using System;

namespace _1._3._8
{
    /*
     * 1.3.8
     * 
     * 给定以下输入，给出 DoublingStackOfStrings 的数组的内容和大小。
     * 
     * it was - the best - of times - - - it was - the - -
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            DoublingStackOfStrings stack = new DoublingStackOfStrings();

            string[] input = "it was - the best - of times - - - it was - the - -".Split(' ');


            foreach (string n in input)
            {
                if (n == "-")
                    stack.Pop();
                else
                    stack.Push(n);
            }

            foreach (string s in stack)
            {
                Console.Write(s + ' ');
            }

            Console.WriteLine($"\nStack Size: {stack.Size()}");
        }
    }
}
