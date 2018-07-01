using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._29
{
    /*
     * 2.2.29
     * 
     * 自然的归并排序。
     * 对于 N=10^3、10^6 和 10^9，类型为 Long 的随机主键数组，
     * 根据经验给出自然的归并排序（请见练习 2.2.16）所需要的遍数。
     * 
     * 提示：
     * 不需要实现这个排序
     * （甚至不需要生成所有完整的 64 位主键）
     * 也能完成这道练习。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 完全有序时只需要一次归并（直接输出）
            // 逆序时需要 n - 1 次归并（退化为插入排序）
            // 平均需要 n/2 次归并
            // 所以分别需要 500，500000，500000000 次归并
        }
    }
}
