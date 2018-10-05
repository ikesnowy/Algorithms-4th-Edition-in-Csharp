using System;
using PriorityQueue;

namespace _2._4._24
{
    /*
     * 2.4.24
     * 
     * 使用链接的优先队列。
     * 用堆排序的二叉树实现一个优先队列，但使用链表结构代替数组。
     * 每个结点都需要三个链接：两个向下，一个向上。
     * 你的实现即使在无法预知队列大小的情况下也能保证优先队列的基本操作所需时间为对数级别。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MaxPQLinked<char> pq = new MaxPQLinked<char>();
            MaxPQ<char> pq2 = new MaxPQ<char>();
            // 利用 2.4.6 的输入做测试
            string input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
            foreach (char c in input)
            {
                if (c == ' ')
                    continue;
                else if (c == '*')
                {
                    Console.WriteLine(pq.DelMax() + " " + pq2.DelMax());
                }
                else
                {
                    pq.Insert(c);
                    pq2.Insert(c);
                }
            }
        }
    }
}
