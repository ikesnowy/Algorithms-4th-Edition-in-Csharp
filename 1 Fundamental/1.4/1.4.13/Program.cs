using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._13
{
    /*
     * 1.4.13
     * 
     * 根据正文中的假设分别给出表示以下数据类型的一个对象所需的内存量：
     * a. Accumulator
     * b. Transaction
     * c. FixedCapacityStackOfStrings，其容量为 C 且含有 N 个元素。
     * d. Point2D
     * e. Interval1D
     * f. Interval2D
     * g. Double
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            /*   a.Accumulator
             *      = int * 1 + double * 2 + Object * 1
             *      = 4 * 1 + 8 * 2 + 16 * 1 = 36
             *      = 40（填充到 8 的倍数）
             *   b.Transaction
             *      = string * 1 + Date * 1 + double * 1 + Object * 1
             *      = 8 * 1 + 8 * 1 + 8 * 1 + 16 * 1
             *      = 40
             *   c.FixedCapacityStackOfStrings
             *      = string[] * 1 + string * C + int * 1 +  Object
             *      = 24 * 1 + 8C + 4 + 24 + 16
             *      = 8C + 44
             *      = 8C + 48（填充）
             *   d.Point2D
             *      = double * 2 + Comparator * 3
             *      = 8 * 2 + 
             */
        }
    }
}
