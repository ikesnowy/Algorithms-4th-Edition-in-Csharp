using System;

namespace _1._1._3
{
    class Program
    {
        /*
         * 输入
         * 
         * 用空格隔开的三个整数，例如
         * 3 3 3
         * 
         * 输出
         * 
         * equal 或 not equal
         */
        static void Main(string[] args)
        {
            // Console.ReadLine() 从控制台读入一整行（返回int）
            // string.Split(char) 根据提供的分隔符将字符串分割，返回字符串数组
            // Int32.Parse(string) 将字符串转换为相应的整型数据
            string input = Console.ReadLine();
            int a = Int32.Parse(input.Split(' ')[0]);
            int b = Int32.Parse(input.Split(' ')[1]);
            int c = Int32.Parse(input.Split(' ')[2]);

            // Console.WriteLine() 向控制台输出一行
            if (a == b && b == c)
            {
                Console.WriteLine("equal");
            }
            else
            {
                Console.WriteLine("not equal");
            }
        }
    }
}
