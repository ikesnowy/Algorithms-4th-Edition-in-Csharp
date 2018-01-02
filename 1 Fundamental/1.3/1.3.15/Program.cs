using System;
using Generics;

namespace _1._3._15
{
    /*
     * 1.3.15
     * 
     * 编写一个 Queue 的用例，接受一个命令行参数 k 并打印出标准输入中的倒数第 k 个字符串
     * （假设标准输入中至少有 k 个字符串）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string[] input = "1 2 3 4 5 6 7 8 9 10".Split(' ');
            int k = 4;

            foreach(string s in input)
            {
                queue.Enqueue(s);
            }

            int count = queue.Size() - k;
            for(int i = 0; i < count; i++)
            {
                queue.Dequeue();
            }

            Console.WriteLine(queue.Peek());
        }
    }
}
