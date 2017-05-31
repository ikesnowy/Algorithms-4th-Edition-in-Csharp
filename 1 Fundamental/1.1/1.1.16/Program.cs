using System;

namespace _1._1._16
{
    /*
     * 1.1.16
     * 
     * 给出 exR1(6) 的返回值
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{exR1(6)}");
        }

        //exR1(6) = 
        //exR1(3) + 6 + exR1(4) + 6
        //exR1(0) + 3 + exR1(1) + 3 + 6 + exR1(4) + 6
        //"" + 3 + exR1(-2) + 1 + exR1(-1) + 1 + 3 + 6 + exR1(4) + 6
        //"" + 3 + "" + 1 + "" + 1 + 3 + 6 + exR1(4) + 6
        //"31136" + exR1(4) + 6
        //......

        public static string exR1(int n)
        {
            if (n <= 0)
            {
                return "";
            }

            return exR1(n - 3) + n + exR1(n - 2) + n;
        }
    }
}