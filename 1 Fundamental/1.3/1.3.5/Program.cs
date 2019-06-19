using System;
using Generics;

namespace _1._3._5
{
    class Program
    {
        // 将十进制数 N 转换为二进制数。
        static void Main(string[] args)
        {
            var N = 50;
            var stack = new Stack<int>();
            while (N > 0)
            {
                stack.Push(N % 2);
                N = N / 2;
            }
            foreach (var d in stack)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();
        }
    }
}
