using System;

namespace _1._1._21
{
    /*
     * 1.1.21
     * 
     * 编写一段程序，从标准输入按行读取数据，其中每行都包含一个名字和两个整数。
     * 然后用 printf() 打印一张表格，
     * 每行的若干列数据包含名字、两个整数和第一个整数除以第二个整数的结果，
     * 精确到小数点后三位。
     * 可以用这种程序将棒球球手的击球命中率或者学生的考试分数制成表格。
     * 
     */
    class Program
    {
        /*
         * 输入示例：
         * 
         * 3
         * hi 1 2
         * hey 1 3
         * hello 1 4
         * 
         */
        static void Main(string[] args)
        {
            int columns = 2;
            int rows = int.Parse(Console.ReadLine());   // 号

            string[] names = new string[rows];          // 名
            int[,] array = new int[rows, columns];      // 入的两个整数
            double[] results = new double[rows];        // 算结果

            for (int i = 0; i < rows; ++i)
            {
                string temp = Console.ReadLine();
                names[i] = temp.Split(' ')[0];
                for (int j = 0; j < columns; ++j)
                {
                    array[i, j] = int.Parse(temp.Split(' ')[j + 1]);
                }
                results[i] = (double)array[i, 0] / array[i, 1];
            }

            PrintArray2D(names, array, results);
        }

        static void PrintArray2D(string[] names, int[,] array, double[] results)
        {
            int rows = array.GetLength(0);// 取行数
            int columns = array.GetLength(1);// 取列数

            for (int i = 0; i < rows; i++)
            {
                Console.Write($"\t{names[i]}");
                for (int j = 0; j < columns - 1; j++)
                {
                    Console.Write($"\t{array[i, j]}");
                }
                Console.Write($"\t{array[i, columns - 1]}");
                Console.Write($"\t{results[i]:N3}");    // 量名:N3 保留三位小数
                Console.Write("\n");
            }
        }
    }
}