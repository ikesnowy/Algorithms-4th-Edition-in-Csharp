using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._26
{
    /*
     * 1.4.26
     * 
     * 三点共线。
     * 假设有一个算法，接受平面上的 N 个点并能够返回在同一直线上的三个点的组数。
     * 证明你能够用这个算法解决 3-sum 问题。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 明点 A(a, a^3) B(b, b^3) C(c, c^3) 当且仅当 a + b + c = 0 时共线。
            // 
            // 点 A,B,C 共线，直线 AB 斜率必定和直线 BC 斜率相等，列方程有：
            // b^3 - a^3)/(b - a) = (c^3 - b^3)/(c - b)
            // 立方差公式化简，有：
            // ^2 + ab + a^2 = c^2 + bc + b^2
            // 去 b^2，将 c 设为未知数有
            // ^2 +bc - a^2 - ab = 0
            // 十字相乘法进行因式分解有
            // a + b + c)(c - a) = 0
            // 方程有：
            //  = -a - b 或 c = a
            // 此当 c != a 时，当且仅当 a + b + c = 0 时 A, B, C 三点共线。
            // 证。
        }
    }
}
