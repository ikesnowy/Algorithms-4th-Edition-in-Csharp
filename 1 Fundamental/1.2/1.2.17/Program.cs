using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._17
{
    /*
     * 1.2.17
     * 
     * 有理数实现的健壮性。
     * 在 Rational （请见练习 1.2.16）的开发中使用断言来防止溢出。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(long.MaxValue, 1);
            Rational b = new Rational(1, 1);
            Rational c = a.Plus(b);
        }
    }
}
