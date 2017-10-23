using System;

namespace _1._3._17
{
    /*
     * 1.3.17
     * 
     * 为 Transaction 类完成练习 1.3.16
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 用 Ctrl + Z 标记结束输入
            Transaction[] t = Transaction.ReadTransactions();

            foreach (Transaction n in t)
            {
                Console.WriteLine(n.ToString());
            }
        }
    }
}
