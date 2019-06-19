using System;

namespace _1._2._7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Mystery("Hello1"));
        }

        /// <summary>
        /// 输出反向字符串。
        /// </summary>
        /// <param name="s">原字符串。</param>
        /// <returns></returns>
        public static string Mystery(string s)
        {
            var N = s.Length;
            if (N <= 1)
                return s;
            var a = s.Substring(0, N / 2);
            var b = s.Substring(N / 2, N - N / 2);

            return Mystery(b) + Mystery(a);
        }
    }
}