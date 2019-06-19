using System;

namespace _1._1._33
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var x = new double[] { 1, 2, 3 };

            var a = new double[][]
            {
                new double[] {1, 2, 3},
                new double[] {4, 5, 6}
            };

            var b = new double[][]
            {
                new double[] {1, 4},
                new double[] {2, 5},
                new double[] {3, 6}
            };

            var c = Matrix.Mult(a, b);

            Console.WriteLine("a:");
            Matrix.PrintMatrix(a);

            Console.WriteLine("b:");
            Matrix.PrintMatrix(b);

            Console.WriteLine("a * b =");
            Matrix.PrintMatrix(c);

            Console.WriteLine("a^T = ");
            Matrix.PrintMatrix(Matrix.Transpose(a));

            Console.WriteLine("x:");
            Matrix.PrintVector(x);

            Console.WriteLine("a * x =");
            Matrix.PrintVector(Matrix.Mult(a, x));

            Console.WriteLine("x * b =");
            Matrix.PrintVector(Matrix.Mult(x, b));
        }
    }
}