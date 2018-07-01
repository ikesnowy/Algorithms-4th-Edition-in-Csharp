using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2._8
{
    /*
     * 2.2.8
     * 
     * 假设将算法 2.4 修改为：
     * 只要 a[mid] <= a[mid+1] 就不调用 merge() 方法，
     * 请证明用归并排序处理一个已经有序的数组所需的比较次数是线性级别的。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 修改后的算法对已经有序的情况做了优化
            // 数组对半切分并排序后，
            // 如果 a[mid] < a[mid+1]
            // （左半部分的最后一个元素小于右半部分的第一个元素）
            // 那么我们可以直接合并数组，不需要再做多余的操作
            // 现在的输入是一个已经排序的数组
            // 算法唯一的比较发生在判断 a[mid] < a[mid+1] 这个条件时
            // 假定数组有 N 个元素
            // 比较次数满足 T(N) = 2 * T(N/2) + 1, T(1) = 0
            // 转化为非递归形式即为：T(N) = cN/2 + N - 1
            // 其中 c 为任意正整数
        }
    }
}
