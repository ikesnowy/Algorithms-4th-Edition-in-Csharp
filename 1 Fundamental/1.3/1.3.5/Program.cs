using System;
using Generics;

namespace _1._3._5
{
    /*
     * 1.3.5
     * 
     * 当 N 为 50 时下面这段代码会打印什么？
     * 从较高的抽象层次描述给定正整数 N 时这段代码的行为。
     * 
     */
    class Program
    {
        // 十进制数 N 转换为二进制数。
        static void Main(string[] args)
        {
            int N = 50;
            Stack<int> stack = new Stack<int>();
            while (N > 0)
            {
                stack.Push(N % 2);
                N = N / 2;
            }
            foreach (int d in stack)
            {
                Console.WriteLine(d);
            }
            Console.WriteLine();
        }
    }
}
