using System;
using PriorityQueue;

namespace _2._4._30
{
    /*
     * 2.4.30
     * 
     * 动态中位数查找。
     * 设计一个数据类型，支持在对数时间内插入元素，
     * 常数时间内找到中位数并在对数时间内删除中位数。
     * 提示：用一个面向最大元素的堆再用一个面向最小元素的堆。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 用一个变量单独保存中位数
            // 小于中位数的数存到最大堆中去
            // 大于中位数的数存到最小堆中去
            // 如果两个堆的大小差距大于 1 就更新中位数
            int[] input = new int[] { 1, 3, 5, 7, 9, 10 };
            MedianPQ<int> pq = new MedianPQ<int>(input);
            Console.WriteLine(pq.DelMedian());
            Console.WriteLine(pq.DelMedian());
        }
    }
}
