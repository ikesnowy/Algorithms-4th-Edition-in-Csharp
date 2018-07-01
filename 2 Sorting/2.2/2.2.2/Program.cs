using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._2
{
    /*
     * 2.2.2
     * 
     * 按照算法 2.4 所示轨迹的格式给出自顶向下的归并排序是如何
     * 将数组 E A S Y Q U E S T I O N 排序的。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // lo mi hi  0 1 2 3 4 5 6 7 8 9 10 11
            //           E A S Y Q U E S T I O  N
            // 0  0  1   A E S Y Q U E S T I O  N
            // 0  1  2   A E S Y Q U E S T I O  N
            // 3  3  4   A E S Q Y U E S T I O  N
            // 3  4  5   A E S Q U Y E S T I O  N
            // 0  2  5   A E S Q U Y E S T I O  N
            // 6  6  7   A E S Q U Y E S T I O  N
            // 6  7  8   A E S Q U Y E S T I O  N
            // 9  9  10  A E S Q U Y E S T I O  N
            // 9  10 11  A E S Q U Y E S T I N  O
            // 6  8  11  A E S Q U Y E I N O S  T
            // 0  5  11  A E E I N O Q S S T U  Y
            //           A E E I N O Q S S T U  Y
        }
    }
}
