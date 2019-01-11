using System;

namespace _2._5._14
{
    /*
     * 2.5.14
     * 
     * 逆域名排序。
     * 为域名编写一个数据类型 Domain 并为它实现一个 compareTo() 方法，
     * 使之能够按照逆向的域名排序。
     * 例如，域名 cs.princeton.edu 的逆是 edu.princeton.cs。
     * 这在网络日志处理时很有用。
     * 提示：使用s.split("\.") 将域名用点分为若干部分。
     * 编写一个 Domain 的用例，
     * 从标准输入读取域名并将他们按照逆域名有序地打印出来。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Domain[] domains = new Domain[5];
            domains[0] = new Domain("edu.princeton.cs");
            domains[1] = new Domain("edu.princeton.ee");
            domains[2] = new Domain("com.google");
            domains[3] = new Domain("edu.princeton");
            domains[4] = new Domain("com.apple");
            Array.Sort(domains);
            for (int i = 0; i < domains.Length; i++)
            {
                Console.WriteLine(domains[i]);
            }
        }
    }
}
