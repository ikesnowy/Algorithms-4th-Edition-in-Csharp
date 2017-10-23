using System;
using Commercial;

namespace _1._2._19
{
    /*
     * 1.2.19
     * 
     * 字符串解析。
     * 为你在练习 1.2.13 中实现的 Date 和 Transaction 类型编写能够解析字符串数据的构造函数。
     * 它接受一个 String 参数指定的初始值，格式如下所示：
     * 
     * Date: 5/22/1939 月/日/年
     * Transaction: Turing 5/22/1939 11.99 姓名 日期 金额
     * 
     */
    class Program
    {
        // 见 Commercial 库中的 Date.cs 和 Transaction.cs
        static void Main(string[] args)
        {
            Date d = new Date("5/22/1939");
            Console.WriteLine(d);

            Transaction a = new Transaction("Turing 01/01/1991 12.12");
            Console.WriteLine(a);
        }
    }
}
