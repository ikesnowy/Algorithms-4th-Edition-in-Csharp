using System;
using UnionFind;

namespace _1._5._17
{
    /*
     * 1.5.17
     * 
     * 随机链接。
     * 设计 UF 的一个用例 ErdosRenyi，
     * 从命令行接受一个整数 N，在 0 到 N-1 之间产生随机整数对，
     * 调用 connected() 判断它们是否相连，
     * 如果不是则调用 union() 方法（和我们的开发用例一样）。
     * 不断循环直到所有触点均相互连通并打印出生成的连接总数。
     * 将你的程序打包成一个接受参数 N 并返回连接总数的静态方法 count()，
     * 添加一个 main() 方法从命令行接受 N，调用 count() 并打印它的返回值。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int N = 10;
            int[] edges = new int[5];
            for (int i = 0; i < 5; i++)
            {
                var uf = new UF(N);
                Console.WriteLine(N + "\t" + ErdosRenyi.Count(uf));
                N *= 10;
            }
        }
    }
}
