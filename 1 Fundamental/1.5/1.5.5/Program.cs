using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._5._5
{
    /*
     * 1.5.5
     * 
     * 在一台每秒能够处理 10^9 条指令的计算机上，
     * 估计 quick-find 算法解决含有 10^9 个触点和 10^6 条连接的动态连通性问题所需的最短时间（以天记）。
     * 假设内循环 for 的每一次迭代需要执行 10 条机器指令。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 10^6 条连接 = 10^6 组输入。
             * 对于 quick-find 算法，每次 union() 都要遍历整个数组。
             * 因此总共进行了 10^9 * 10^6 = 10^15 次 for 循环迭代。
             * 每次 for 循环迭代都需要 10 条机器指令，
             * 因此总共执行了 10 * 10^15 = 10^16 条机器指令。
             * 
             * 已知计算机每秒能够执行 10^9 条机器指令，
             * 因此执行完所有指令需要 10^16 / 10^9 = 10^7 秒 = 115.74 天
             * 
             */
        }
    }
}
