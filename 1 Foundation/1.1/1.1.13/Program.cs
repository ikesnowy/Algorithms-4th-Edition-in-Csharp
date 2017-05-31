using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._1._13
{
    /*
     * 1.1.13
     * 
     * 编写一段代码，打印出一个 M 行 N 列的二维数组的转置
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int M = 2;
            int N = 3;
            int[,] array = new int[M, N];

            //新建一个二维数组
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    array[i, j] = i + j;
                }
            }

            Console.WriteLine("原二维数组：");
            PrintArray2D(array, M, N);

            Console.WriteLine("转置后：");
            PrintArrayTranspose2D(array, M, N);
        }

        //转置输出
        private static void PrintArrayTranspose2D(int[,] array, int rows, int columns)
        {
            //交换行、列输出顺序
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    Console.Write($"\t{array[j, i]}");
                }
                Console.Write("\n");
            }
        }

        //正常输出
        private static void PrintArray2D(int[,] array, int rows, int columns)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"\t{array[i, j]}");
                }
                Console.Write("\n");
            }
        }
    }
}
