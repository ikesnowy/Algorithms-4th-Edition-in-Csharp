using System;
using Generics;

namespace _1._3._12
{
    /*
     * 1.3.12
     * 
     * 编写一个可迭代的 Stack 用例，它含有一个静态的 CopyTo() 方法，
     * 接受一个字符串的栈作为参数并返回该栈的一个副本。
     * 注意：这种能力是迭代器价值的一个重要体现，
     * 因为有了它我们无需改变基本 API 就能实现这种功能。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> src = new Stack<string>();
            src.Push("first");
            src.Push("second");
            src.Push("third");

            Stack<string> des = CopyTo(src);
            
            while (!des.IsEmpty())
            {
                Console.WriteLine(des.Pop());
            }

        }

        static Stack<string> CopyTo(Stack<string> src)
        {
            Stack<string> des = new Stack<string>();
            Stack<string> temp = new Stack<string>();

            foreach (string s in src)
            {
                temp.Push(s);
            }

            while (!temp.IsEmpty())
            {
                des.Push(temp.Pop());
            }

            return des;
        }
    }
}
