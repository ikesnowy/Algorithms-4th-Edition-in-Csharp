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
            // 明组合计算公式：
            // (N,3) = N! / [(N-3)! × 3!] 
            //  [(N - 2) * (N - 1) * N] / 3!
            //  N(N - 1)(N - 2) / 6

            // .使用数学归纳法证明排列数公式。
            // 先，显然有 A(n,1) = n （在 n 个数中取 1 个数的排列共有 n 种）
            // 后，设有 a1,a2,...,an 这 n 个数，从这些数中取 r 个数组成的排列表示为 A(n,r)。
            //  A(n,r) 中，以 a1 为首的排列有 A(n-1,r-1) 种，对 a2,...,an 同理。
            // 以有 A(n,r) = nA(n-1,r-1)。
            // 合 A(n,1) = n，可以推得排列数公式 A(n,r) = n!/(n-r)!
            // .由排列数公式推得组合数公式。
            // 排列数 A(n,r) 中，相同的 r 个数有 r! 种排列。
            // 此对于组合数而言，这 r! 种排列只能算 1 种组合。
            //  C(n,r) = A(n,r) / r! = n! / (n-r)!r!
            //  r = 3，得出 C(N,3) = N(N-1)(N-2) / 6，此证。
        }
    }
}
