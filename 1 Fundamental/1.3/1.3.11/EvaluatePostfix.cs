using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Generics;

namespace _1._3._11
{
    /*
     * 1.3.11
     * 
     * 编写一段程序 EvaluatePostfix，从标准输入中得到一个后序表达式，求值并打印结果
     * （将上一题的程序中得到的输出用管道传递给这一段程序可以得到和 Evaluate 相同的行为）。
     * 
     */
    class EvaluatePostfix
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            string[] input = "7 16 * 5 + 16 * 3 + 16 * 1 +".Split(' ');

            foreach (string n in input)
            {
                if (n == " ")
                {
                    continue;
                }
                else if (n == "+")
                {
                    stack.Push(stack.Pop() + stack.Pop());
                }
                else if (n == "-")
                {
                    int temp = stack.Pop();
                    stack.Push(stack.Pop() - temp);
                }
                else if (n == "*")
                {
                    stack.Push(stack.Pop() * stack.Pop());
                }
                else if (n == "/")
                {
                    int temp = stack.Pop();
                    stack.Push(stack.Pop() / temp);
                }
                else
                {
                    stack.Push(int.Parse(n));
                }
            }

            Console.WriteLine(stack.Pop());
        }
    }
}
