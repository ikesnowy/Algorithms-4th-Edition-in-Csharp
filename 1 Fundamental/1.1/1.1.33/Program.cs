using System;

namespace _1._1._33
{
    /*
     * 1.1.33
     * 
     * 矩阵库
     * 编写一个矩阵库并实现下列 API
     * 
     * public class Matrix
     *  static double dot(double[] x, double[] y)           //向量点乘
     *  static double[][] mult(double[][] a, double[][] b)  //矩阵与矩阵之积
     *  static double[][] transpose(double[][] a)           //矩阵转置
     *  static double[] mult(double[][] a, double[] x)      //矩阵和向量之积
     *  static double[] mult(double[] y, double[][] a)      //向量和矩阵之积
     *  
     */
    class Program
    {
        static void Main(string[] args)
        {
            double[][] a = new double[][]
            {
                new double[] {1, 2, 3},
                new double[] {4, 5, 6}
            };

            double[][] b = new double[][]
            {
                new double[] {1, 4},
                new double[] {2, 5},
                new double[] {3, 6}
            };

            double[][] c;

            c = Matrix.Mult(a, b);
            Matrix.Transpose(a);
        }
    }
}