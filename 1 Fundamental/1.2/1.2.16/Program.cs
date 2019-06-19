using System;

namespace _1._2._16
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Rational(15, 20);
            var b = new Rational(2, -9);

            Console.WriteLine(a + " + " + b + "=" + a.Plus(b));
            Console.WriteLine(a + " - " + b + "=" + a.Minus(b));
            Console.WriteLine(a + " * " + b + "=" + a.Multiply(b));
            Console.WriteLine(a + " / " + b + "=" + a.Divide(b));
        }
    }
}
