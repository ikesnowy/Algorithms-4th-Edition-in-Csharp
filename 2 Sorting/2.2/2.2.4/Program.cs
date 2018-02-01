using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._4
{
    /*
     * 2.2.4
     * 
     * 是否当且仅当两个输入的子数组都有序时原地归并的抽象方法才能得到正确的结果？
     * 证明你的结论，或者给出一个反例。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 是的，必须要两个子数组都有序时归并才能得到正确结果。
            // 如果说数组不有序的话，那么最后只能得到两个数组的混合。
            // 合并后的数组中，属于原有数组的元素的相对顺序不会被改变。
            // 例如子数组 1 3 1 和 2 8 5 原地归并。
            // 结果是 1 2 3 1 8 5，其中 1 3 1 和 2 8 5 的相对顺序不变。 
        }
    }
}
