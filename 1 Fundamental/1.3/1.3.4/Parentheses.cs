using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._4
{
    /*
     * 1.3.4
     * 
     * 编写一个 Stack 的用例 Parentheses，
     * 从标准输入中读取一个文本流并使用栈判定其中的括号是否配对完整。
     * 例如，对于 [()]{}{[()()]()} 程序应该打印 true，
     * 对于 [(]) 则打印 false。
     * 
     */
    class Parentheses
    {
        static bool isBalanced(string input)
        {
            Stack<char> stack = new Stack<char>();

            foreach (char i in input)
            {
                if (i == '(' || i == '[' || i == '{')
                    stack.Push(i);
                else
                {
                    if (stack.Peek() == '(' && i == ')')
                        stack.Pop();
                    else if (stack.Peek() == '{' && i == '}')
                        stack.Pop();
                    else if (stack.Peek() == '[' && i == ']')
                        stack.Pop();
                    else
                        return false;
                }
            }

            return stack.IsEmpty();
        }

        static void Main(string[] args)
        {
            string input = "[()]{}{[()()]()}";
            Console.WriteLine(isBalanced(input));
            string input2 = "[(])";
            Console.WriteLine(isBalanced(input2));
        }
    }
}
