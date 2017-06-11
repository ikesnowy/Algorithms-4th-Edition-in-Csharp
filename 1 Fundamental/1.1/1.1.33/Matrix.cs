using System;
using System.Collections.Generic;
using System.Text;

namespace _1._1._33
{
    public class Matrix
    {
        /// <summary>
        /// 向量点乘
        /// </summary>
        /// <param name="x">需要点乘的向量</param>
        /// <param name="y">需要点乘的另一个向量</param>
        /// <returns>返回点乘的结果</returns>
        /// <exception cref="FormatException"></exception>
        public static double Dot(double[] x, double[] y)
        {
            //确保两向量等长
            if (x.Length != y.Length)
            {
                throw new FormatException("the length of two vectors must be equal");
            }

            //点乘
            double result = 0;
            for (int i = 0; i < x.Length; ++i)
            {
                result += x[i] * y[i];
            }

            return result;
        }

        /// <summary>
        /// 两个矩阵相乘，返回一个矩阵
        /// </summary>
        /// <param name="a">用交错数组表示的 m * p 矩阵</param>
        /// <param name="b">用交错数组表示的 p * n 矩阵</param>
        /// <returns>返回 m * n 的矩阵</returns>
        /// <exception cref="FormatException"></exception>
        /// <example>
        ///     a = {(1,2,3),(4,5,6)}
        ///     b = {(1,4),(2,5),(3,6)}
        ///     Mult(a, b) = {(14,32),(32,77)}
        /// </example>
        public static double[][] Mult(double[][] a, double[][] b)
        {
            if (a[0].Length != b.GetLength(0))
            {
                throw new FormatException("a's column number must be equal to b's row number");
            }

            int m = a.GetLength(0);
            int n = b[0].Length;
            int p = a[0].Length;

            double[][] result = new double[m][];

            for (int i = 0; i < m; ++i)
            {
                double[] resultrow = new double[n];
                for (int j = 0; j < n; ++j)
                {
                    //result[i][j] = 行向量 a[i] 与列向量 b[j] 的点积
                    double[] row = a[i];
                    double[] col = new double[p];
                    //取得列向量
                    for (int k = 0; k < p; ++k)
                    {
                        col[k] = b[k][j];
                    }
                    //点积
                    resultrow[j] = Dot(row, col);
                }
                result[i] = resultrow;
            }
            return result;
        }

        /// <summary>
        /// 将一个矩阵转置
        /// </summary>
        /// <param name="a">待转置的矩阵</param>
        /// <returns>返回转置后的数组</returns>
        public static double[][] Transpose(double[][] a)
        {
            double[][] trans = new double[a[0].Length][];
            for (int i = 0; i < a[0].Length; ++i)
            {
                double[] row = new double[a.GetLength(0)];
                for (int j = 0; j < a.GetLength(0); ++j)
                {
                    row[j] = a[j][i];
                }
                trans[i] = row;
            }
            return trans;
        }
    }
}
