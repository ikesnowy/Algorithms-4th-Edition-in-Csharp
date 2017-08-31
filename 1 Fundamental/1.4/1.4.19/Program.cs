using System;

namespace _1._4._19
{
    /*
     * 1.4.19
     * 
     * 矩阵的局部最小元素。
     * 给定一个含有 N^2 个不同整数的 N×N 数组 a[]。
     * 设计一个运行时间和 N 成正比的算法来找出一个局部最小元素：
     * 满足 a[i][j] < a[i+1][j]、a[i][j] < a[i][j+1]、a[i][j] < a[i-1][j] 以及 a[i][j] < a[i][j-1] 的索引 i 和 j。
     * 程序运行时间在最坏情况下应该和 N 成正比。
     * 
     */
    class Program
    {
        //先查找 N/2 行中的最小元素，并令其与上下元素比较，
        //如果不满足题意，则向相邻的最小元素靠近再次查找
        static void Main(string[] args)
        {
            int[,] matrix = new int[5, 5] 
            { 
                { 26, 3, 4 , 10, 11 }, 
                { 5, 1, 6, 12, 13 }, 
                { 7, 8, 9 , 14, 15 }, 
                { 16, 17, 18, 27, 20 }, 
                { 21, 22, 23, 24, 25 }
            };
            Console.WriteLine(MinimumRow(matrix, 0, 5, 0, 5));
        }

        static int MinimumRow(int[,] matrix, int rowStart, int rowLength, int colStart, int colLength)
        {
            int min = int.MaxValue;
            if (rowLength < 3)
                return int.MaxValue;
            int mid = rowStart + rowLength / 2;
            int minCol = 0;
            //获取矩阵中间行的最小值
            for (int i = 0; i < colLength; ++i)
            {
                if (min > matrix[mid, colStart + i])
                {
                    min = matrix[mid, colStart + i];
                    minCol = i;
                }
            }
            //检查是否满足条件
            if (matrix[mid, minCol] < matrix[mid - 1, minCol] && matrix[mid, minCol] < matrix[mid + 1, minCol])
            {
                return matrix[mid, minCol];
            }
            //如果不满足则向较小一侧移动
            if (matrix[mid - 1, minCol] > matrix[mid + 1, minCol])
            {
                return MinimumCol(matrix, rowStart, rowLength, mid + 1, colLength / 2 + 1);
            }
            else
            {
                return MinimumCol(matrix, rowStart, rowLength, colStart, colLength / 2 + 1);
            }
        }

        static int MinimumCol(int[,] matrix, int rowStart, int rowLength, int colStart, int colLength)
        {
            int min = int.MaxValue;
            int n = matrix.GetLength(0);
            int mid = n / 2;
            int minRow = 0;

            //获取矩阵中间列最小值
            for (int i = 0; i < n; ++i)
            {
                if (min > matrix[i, mid])
                {
                    min = matrix[i, mid];
                    minRow = i;
                }
            }
            //检查是否满足条件
            if (matrix[minRow, mid] < matrix[minRow, mid - 1] && matrix[minRow, mid] < matrix[minRow, mid + 1])
            {
                return matrix[minRow, mid];
            }
            //如果不满足则向较小一侧移动
            if (matrix[minRow, mid - 1] > matrix[minRow, mid + 1])
            {
                return MinimumRow(matrix, mid + 1, rowLength / 2 + 1, colStart, colLength);
            }
            else
            {
                return MinimumRow(matrix, rowStart, rowLength / 2 + 1, colStart, colLength);
            }
        }
    }
}
