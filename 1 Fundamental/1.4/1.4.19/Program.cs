using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._19
{
    /*
     * 1.4.19
     * 
     * 矩阵的局部最小元素。
     * 给定一个含有 N^2 个不同整数的 N×N 数组 a[]。
     * 设计一个运送时间和 N 成正比的算法来找出一个局部最小元素：
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

        }

        static int Minimum(int[,] matrix)
        {
            int min = int.MaxValue;
            int n = matrix.GetLength(0);
            int mid = n / 2;
            //获取矩阵边界以及中间行/中间列中的最小值
            for (int i = 0; i < n; ++i)
            {
                if (min > matrix[0, i])
                {
                    min = matrix[0, i];
                }
                if (min > matrix[n - 1, i])
                {
                    min = matrix[n - 1, i];
                }
                if (min > matrix[mid, i])
                {
                    min = matrix[mid, i];
                }
                if (min > matrix[i, 0])
                {
                    min = matrix[i, 0];
                }
                if (min > matrix[i, n - 1])
                {
                    min = matrix[i, n - 1];
                }
                if (min > matrix[i, mid])
                {
                    min = matrix[i, mid];
                }
            }
        }
    }
}
