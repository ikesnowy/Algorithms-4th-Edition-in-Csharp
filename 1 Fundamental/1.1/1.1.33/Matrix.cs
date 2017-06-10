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
        static double dot(double[] x, double[] y)
        {
            if (x.Length != y.Length)
            {
                throw new FormatException("向量不等长");
            }

            double result = 0;
            for (int i = 0; i < x.Length; ++i)
            {
                result += x[i] * y[i];
            }

            return result;
        }
    }
}
