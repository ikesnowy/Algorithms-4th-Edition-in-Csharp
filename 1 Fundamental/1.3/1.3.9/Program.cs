using System;
using Generics;

namespace _1._3._9
{
    /*
     * 1.3.9
     * 
     * 编写一段程序，从标准输入得到一个缺少左括号的表达式并打印出补全括号之后的中序表达式。
     * 例如，给定输入：
     * 1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )
     * 你的程序应该输出：
     * ( ( 1 + 2 ) * ( ( 3 - 4 ) * ( 5 - 6 ) ) )
     * 
     */
    class Program
    {
        //在计算中序表达式算法的基础上做修改
        //压入数字时将该数字所在的位置也一并压入
        //弹出数字进行运算时在位置靠前的数字前加上左括号
        //A + B ) * C + D ) ) 为例
        //A 压入栈中并记录位置                                        
        //+ 压入栈中                                               
        //B 压入栈中并记录位置                                             
        //) 计算，在 A 之前加入左括号，结果 E 压入栈中，位置为 A 的位置
        //* 压入栈中                                                    
        //C 压入栈中并记录位置
        //+ 压入栈中
        //D 压入栈中并记录位置
        //) 计算，在 C 之前加入左括号，结果 F 压入栈中，位置为 C 的位置
        //) 计算，在 E 之前加入左括号（也就是 A 之前），结果 G 压入栈中，位置为 E 的位置。
        static void Main(string[] args)
        {
            string input = "1 + 2 ) * 3 - 4 ) * 5 - 6 ) ) )";
            Stack<char> operators = new Stack<char>();
            Stack<Number> numbers = new Stack<Number>();
            int[] leftBrackets = new int[input.Length];
            
            for (int i = 0; i < input.Length; ++i)
            {
                if (input[i] == ' ')
                    continue;
                else if (input[i] == '+' || input[i] == '-' || input[i] == '*' || input[i] == '/')
                {
                    operators.Push(input[i]);
                }
                else if (input[i] == ')')
                {
                    Number B = numbers.Pop();
                    Number A = numbers.Pop();
                    char operation = operators.Pop();
                    Number C = new Number();
                    C.Position = A.Position;
                    leftBrackets[A.Position]++;

                    switch (operation)
                    {
                        case '+':
                            C.Value = A.Value + B.Value;
                            break;
                        case '-':
                            C.Value = A.Value - B.Value;
                            break;
                        case '*':
                            C.Value = A.Value * B.Value;
                            break;
                        case '/':
                            C.Value = A.Value / B.Value;
                            break;
                    }
                    numbers.Push(C);
                }
                else
                {
                    Number num = new Number();
                    num.Position = i;
                    num.Value = input[i] - '0';
                    numbers.Push(num);
                }
            }

            for (int i = 0; i < input.Length; ++i)
            {
                while (leftBrackets[i] != 0)
                {
                    Console.Write("( ");
                    leftBrackets[i]--;
                }

                Console.Write(input[i]);
            }
        }
    }

    struct Number
    {
        public int Value;
        public int Position;
    }
}
