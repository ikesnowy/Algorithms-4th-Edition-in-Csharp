using System;
using Generics;

namespace _1._3._10
{
    /*
     * 1.3.10
     * 
     * 编写一个过滤器 InfixToPostfix，
     * 将算术表达式由中序表达式转为后序表达式。
     * 
     */
    class InfixToPostfix
    {
        // 其实就是把右括号换成相应运算符
        // 对于 (A + B)，忽略左括号，数字直接输出，运算符入栈，遇到右括号时再弹出
        // 结果 A B +，变成后序表达式
        static void Main(string[] args)
        {
            Stack<string> stack = new Stack<string>();
            string[] input = "( 2 + ( ( 3 + 4 ) * ( 5 * 6 ) ) )".Split(' ');
            foreach (string n in input)
            {
                if (n == " ")
                    continue;
                else if (n == "+" || n == "-" || n == "*" || n == "/")
                {
                    stack.Push(n);
                }
                else if (n == ")")
                {
                    Console.Write(stack.Pop() + " ");
                }
                else if (n == "(")
                {
                    continue;
                }
                else
                {
                    Console.Write(n + " ");
                }
            }
            Console.WriteLine();
        }
    }
}
