using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._2
{
    /*
     * 2.3.2
     * 
     * 按照本节中快速排序所示轨迹的格式给出快速排序是如何将数组 E A S Y Q U E S T I O N 排序的
     * （出于练习的目的，可以忽略开头打乱数组的部分）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //                             a[]
            // lo  j  hi  0  1  2  3  4  5  6  7  8  9  10  11
            //            E  A  S  Y  Q  U  E  S  T  I   O   N
            // 0   2  11  E  A  E  Y  Q  U  S  S  T  I   O   N
            // 0   1   1  A  E  E  Y  Q  U  S  S  T  I   O   N
            // 0       0  A  E  E  Y  Q  U  S  S  T  I   O   N
            // 3  11  11  A  E  E  N  Q  U  S  S  Y  I   O   Y
            // 3   4  10  A  E  E  I  N  U  S  S  T  Q   O   Y
            // 3       3  A  E  E  I  N  U  S  S  T  Q   O   Y
            // 5  10  10  A  E  E  I  N  O  S  S  T  Q   U   Y
            // 5   5   9  A  E  E  I  N  O  S  S  T  Q   U   Y
            // 6   7   9  A  E  E  I  N  O  Q  S  T  S   U   Y
            // 6       6  A  E  E  I  N  O  Q  S  T  S   U   Y
            // 8   9   9  A  E  E  I  N  O  Q  S  S  T   U   Y
            // 8       8  A  E  E  I  N  O  Q  S  S  T   U   Y
            //            A  E  E  I  N  O  Q  S  S  T   U   Y
        }
    }
}
