using System;

namespace _1._3._16
{    
    class Program
    {
        static void Main(string[] args)
        {
            // 输入结束后按 Ctrl + Z 标记结尾
            // 输入格式：06/30/2017
            // 以回车分隔
            Date[] date = Date.ReadDates();
            foreach (Date d in date)
            {
                Console.WriteLine(d);
            }
        }
    }
}
