using System;

namespace _1._3._50
{
    /*
     * 1.3.50
     * 
     * 快速出错的迭代器。
     * 修改 Stack 的迭代器代码，
     * 确保一旦用例在迭代器中（通过 push() 或 pop() 操作）修改集合数据就抛出一个
     * java.util.ConcurrentModificationException 异常。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            stack.Push("first");
            stack.Push("second");
            stack.Push("third");
            stack.Push("fourth");

            foreach (string s in stack)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();
            foreach (string s in stack)
            {
                Console.Write(s + " ");
                stack.Pop();// 出异常
            }
        }
    }
}
