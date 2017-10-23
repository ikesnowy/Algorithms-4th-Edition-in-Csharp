using System;

namespace _1._1._9
{
    /*
     * 1.1.9
     * 
     * 编写一段代码，将一个正整数N用二进制表示并转换为一个 String 类型的值 s
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int N = 4;

            // 1.直接转换 Convert.ToString(int, int) 第一个为要转换的数，第二个为要转换的进制
            Console.WriteLine($"{Convert.ToString(N, 2)}");

            // 2.转换为二进制数
            string s = "";
            for (int n = N; n > 0; n /= 2)
            {
                s = (n % 2) + s;
            }
            Console.WriteLine(s);
        }
    }
}
