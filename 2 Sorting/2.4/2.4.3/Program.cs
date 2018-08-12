using System;
using PriorityQueue;

namespace _2._4._3
{
    /*
     * 2.4.3
     * 
     * 用以下数据结构实现优先队列，支持插入元素和删除最大元素操作：
     * 无序数组、有序数组、无序链表和链表。
     * 将你的 4 种实现中每种操作在最坏情况下的运行时间上下限制成一张表格。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // | 实现    | insert() | delMax() |
            // | ------- | -------- | -------- |
            // | 有序数组 |    N     |     1    |
            // | 有序链表 |    N     |     1    |
            // | 无序数组 |    1     |     N    |
            // | 无序链表 |    1     |     N    |
            test(new OrderedArrayMaxPQ<string>(10));
            test(new UnorderedArrayMaxPQ<string>(10));
            test(new OrderedLinkedMaxPQ<string>());
            test(new UnorderedLinkedMaxPQ<string>());
        }

        static void test(IMaxPQ<string> pq)
        {
            Console.WriteLine(pq.ToString());
            pq.Insert("this");
            pq.Insert("is");
            pq.Insert("a");
            pq.Insert("test");
            while (!pq.IsEmpty())
                Console.Write(pq.DelMax() + " ");
            Console.WriteLine();
        }
    }
}
