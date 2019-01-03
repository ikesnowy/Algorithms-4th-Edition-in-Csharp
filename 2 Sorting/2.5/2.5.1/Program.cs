using System;

namespace _2._5._1
{
    /*
     * 2.5.1
     * 
     * 在下面这段 String 类型的 compareTo() 方法的实现中，
     * 第三行对提高运行效率有何帮助？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // if (this == that) return 0;
            // 如果比较的两个 string 是同一个对象的引用，直接返回相等结果
            // 而不必再逐字符比较。
            string s = "123456";
            string p = s;
            Console.WriteLine(s.CompareTo(p));  // 输出 0
        }
    }
}
