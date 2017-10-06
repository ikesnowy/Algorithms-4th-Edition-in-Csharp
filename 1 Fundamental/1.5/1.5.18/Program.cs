using System;
using UnionFind;

namespace _1._5._18
{
    /*
     * 1.5.18
     * 
     * 随机网格生成器。编写一个程序 RandomGrid，从命令行接受一个 int 值 N，
     * 生成一个 N×N 的网格中的所有连接。
     * 它们的排列随机且方向随机（即 (p q) 和 (q p) 出现的可能性是相等的），
     * 将这个结果打印到标准输出中。
     * 可以使用 RandomBag 将所有连接随机排列（请见练习 1.3.34），
     * 并使用如右下所示的 Connection 嵌套类来将 p 和 q 封装到一个对象中。
     * 将程序打包成两个静态方法：generate()，接受参数 N 并返回一个连接的数组；
     * main()，从命令行接受参数 N，调用 generate()，便利返回的数组并打印出所有连接。
     * 
     * private class Connection
     * {
     *     int p;
     *     int q;
     * 
     *     public Connection(int p, int q)
     *     {
     *         this.p = p;
     *         this.q = q;
     *     }
     * }
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            var result = RandomGrid.Generate(5);
            foreach (var i in result)
            {
                Console.WriteLine($"({i.P}, {i.Q})");
            }
        }
    }
}
