using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._16
{
    /*
     * 1.2.16
     * 
     * 有理数。
     * 为有理数实现一个不可变数据类型 Rational，支持加减乘除操作。
     * public class Rational
     * {
     *      Rantional(int numerator, int denominator)
     *      Rational plus (Rational b);
     *      Rational minus(Rational b);
     *      Rational times(Rational b);
     *      Rational divides(Rational b);
     *      Boolean equals(Rational that);
     *      String toString();
     * }
     * 无需测试溢出（请见练习 1.2.17），只需使用两个 long 型实例变量表示分子和分母来控制溢出的可能性。
     * 使用欧几里得算法来保证分子和分母没有公因子。
     * 编写一个测试用例检测你实现的所有方法。
     *
     */
    class Program
    {
        static void Main(string[] args)
        {
            Rational a = new Rational(15, 20);
            Rational b = new Rational(2, -9);

            Console.WriteLine(a + " + " + b + "=" + a.Plus(b));
            Console.WriteLine(a + " - " + b + "=" + a.Minus(b));
            Console.WriteLine(a + " * " + b + "=" + a.Multiply(b));
            Console.WriteLine(a + " / " + b + "=" + a.Divide(b));
        }
    }
}
