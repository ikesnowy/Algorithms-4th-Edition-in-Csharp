using System;

namespace _1._1._11
{
    /*
     * 1.1.11 
     * 
     * 编写一段代码，打印出一个二维布尔数组的内容。
     * 其中，使用 * 表示真，空格表示假，打印出行号和列号
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            bool[,] array = new bool[,]
            {
                { true, true },
                { false, false },
                { true, false }
            };

            PrintArray2D(array);//打印二维数组
        }

        static void PrintArray2D(bool[,] array)
        {
            int rows = array.GetLength(0);//获取行数
            int columns = array.GetLength(1);//获取列数

            //输出列号
            for (int i = 0; i < columns; i++)
            {
                Console.Write($"\t{i + 1}");
            }

            Console.Write("\n");

            for (int i = 0; i < rows; i++)
            {
                //输出行号
                Console.Write($"{i + 1}");
                for (int j = 0; j < columns; j++)
                {
                    if (array[i, j])
                    {
                        Console.Write($"\t*");
                    }
                    else
                    {
                        Console.Write($"\t ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
