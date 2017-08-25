using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._36
{
    /*
     * 1.4.36
     * 
     * 下压栈的空间成本。
     * 解释下表中的数据，它显示了各种下压栈实现的一般空间成本，
     * 其中链表的结点为一个静态的嵌套类，从而避免非静态嵌套类的开销。
     * 数据结构             元素类型    N 个 int 值所需的空间（字节）
     * 基于链表             int         ~32N
     * 基于链表             Integer     ~56N
     * 基于大小可变的数组    int         ~4N到~16N之间
     * 基于大小可变的数组    Integer     ~32N到~56N之间
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 1. N 个 Node<int> 对象的空间开销 = N * (16(对象开销) + 4(int) + 8(下一个 Node 的引用) + 4(填充字节)) = 32N
            // 2. 比起上一题来说，空间开销变为 = N * (16(Node 对象开销) + 8(Integer 对象引用) + (16(Integer 对象开销) + 4(int) + 4(填充字节)) + 8(下一个对象的引用) = 32N + 24N = 56N
            // 3. 如果不扩容则是 4N，N 个元素最多可以维持 4N 的栈空间（少于四分之一将缩小）。
            // 4. 比起上一题，数组元素变成了引用每个占用 8 字节，还要额外加上 Integer 对象的每个 24 字节。
            //    (8 + 24)N ~ (8 * 4 + 24)N
        }
    }
}
