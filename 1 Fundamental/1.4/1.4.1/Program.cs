using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._1
{
    /*
     * 1.4.1
     * 
     * 证明从 N 个数中取三个整数的不同组合总数为 N(N - 1)(N - 2) / 6
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //组合计算公式：
            //C(3,N) = N! / [(N-3)! × 3!] 
            //= [(N - 2) * (N - 1) * N] / 3!
            //= N(N - 1)(N - 2) / 6
        }
    }
}
