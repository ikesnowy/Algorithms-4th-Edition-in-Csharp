using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._32
{
    /*
     * 1.4.32
     * 
     * 均摊分析。
     * 请证明，对一个基于大小可变的数组实现的空栈的 M 次操作访问数组的次数和 M 成正比。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //由于 pop 和 push 原理类似（pop 也会调整数组大小，调整的代价等于前一次 push 扩容时的代价），我们假设所有操作均为 push。
            //如果数组不发生扩容，M 次操作访问数组次数即为 M 次，符合正比要求。
            //如果数组发生扩容，假设 M = N + k，N 为小于等于 M 的最大 2 的幂。
            //
        }
    }
}
