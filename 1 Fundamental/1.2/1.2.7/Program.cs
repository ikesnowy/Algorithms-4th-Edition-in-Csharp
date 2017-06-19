using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._2._7
{
    /*
     * 1.2.7
     * 
     * 以下递归函数的返回值是什么？
     * public static String mystery(String s)
     * {
     *      int N = s.length();
     *      if (N <= 1) return s;
     *      String a = s.substring(0, N/2);
     *      String b = s.substring(N/2, N);
     *      return mystery(b) + mystery(a);
     * }
     * 
     */
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
            int N = s.Length;
            if (N <= 1)
                return s;
            string a = s.Substring(0, N / 2);
            string b = s.Substring(N / 2, N - N / 2);

            return Mystery(b) + Mystery(a);
        }
    }
}
