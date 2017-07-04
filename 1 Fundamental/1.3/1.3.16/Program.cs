using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3._16
{
    /*
     * 1.3.16
     * 
     * 使用 1.3.1.5 节中的 readInts() 作为模板为 Date 编写一个静态方法 readDates()，
     * 从标准输入中读取由练习 1.2.19 的表格指定的格式的多个日期并返回一个它们的数组。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //输入结束后按 Ctrl + Z 标记结尾
            //输入格式：06/30/2017
            //以回车分隔
            Date[] date = Date.ReadDates();
            foreach (Date d in date)
            {
                Console.WriteLine(d);
            }
        }
    }
}
