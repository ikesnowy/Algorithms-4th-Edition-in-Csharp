using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._36
{
    /*
     * 2.1.36
     * 
     * 不均匀的数据。
     * 编写一个测试用例，
     * 生成不均匀的测试数据，包括：
     * 一半数据是 0，一半数据是 1
     * 一半数据是 0，1/4 是 1，1/4 是 2，以此类推
     * 一半数据是 0，一半是随机 int 值。
     * 评估并验证这些输入数据对本节讨论的算法的性能的影响。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
        }

        /// <summary>
        /// 获取一半是 0 一半是 1 的随机 <see cref="int"/> 数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>一半是 0 一半是 1 的 <see cref="int"/>数组。</returns>
        static int[] HalfZeroHalfOne(int n)
        {
            int[] result = new int[n];
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                if (random.NextDouble() >= 0.5)
                {
                    result[i] = 0;
                }
                else
                {
                    result[i] = 1;
                }
            }
            return result;
        }

        static int[] HalfAndHalf(int start, int number, int length, int[] array)
        {
            if (length == 0)
                return array;

            for (int i = 0; i < length; i++)
            {

            }
        }
    }
}
