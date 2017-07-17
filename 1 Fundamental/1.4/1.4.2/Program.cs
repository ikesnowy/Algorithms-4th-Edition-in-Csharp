using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurement;

namespace _1._4._2
{
    /*
     * 1.4.2
     * 
     * 修改 ThreeSum，正确处理两个较大 int 值相加可能溢出的情况。
     * 
     */
    class Program
    {
        //将 a[i] + a[j] + a[k] 改为 (long)a[i] + a[j] + a[k] 即可。
        //此时整个式子将按照精度最高（也就是 long）的标准计算。
        static void Main(string[] args)
        {
            int[] a = new int[4];
            a[0] = int.MaxValue;
            a[1] = int.MaxValue;
            a[2] = int.MinValue;
            a[3] = 1;

            Console.WriteLine(ThreeSum.Count(a));//2
        }
    }
}
