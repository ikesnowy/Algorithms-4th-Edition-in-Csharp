using System;
using PriorityQueue;

namespace _2._4._29
{
    /*
     * 2.4.29
     * 
     * 同时面向最大和最小元素的优先队列。
     * 设计一个数据类型，支持如下操作：
     * 插入元素、删除最大元素、删除最小元素（所需时间均为对数级别），
     * 以及找到最大元素、找到最小元素（所需时间均为常数级别）。
     * 提示：用两个堆。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 其实就是同时维护两个堆，一个最大堆一个最小堆。
            // 插入元素时复制成两个孪生结点，分别插入到最大堆和最小堆中。
            // 孪生结点中存有元素的值，自身在数组的下标以及指向另一个孪生结点的指针。
            // 重写最大堆和最小堆的 Exch 函数，只交换元素值以及指针，不交换下标的值。
            // 删除结点时需要去另一个堆删除对应的孪生结点。
            // 方法是令待删除结点等于堆顶结点的复制，然后对待删除结点执行 Swim()。
            // 然后执行一次 DelMax()，待删除结点被删除。
            MinMaxPQ<int> pq = new MinMaxPQ<int>();
            pq.Insert(1);
            pq.Insert(2);
            pq.Insert(3);
            Console.WriteLine(pq.DelMin());
            Console.WriteLine(pq.DelMax());
            pq.Insert(3);
            Console.WriteLine(pq.DelMin());
            Console.WriteLine(pq.DelMax());
        }
    }
}
