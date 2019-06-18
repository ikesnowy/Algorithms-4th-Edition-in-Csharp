using System;
using PriorityQueue;

namespace _2._4._31
{
    class Program
    {
        static void Main(string[] args)
        {
            // 在 swim 中新建一个数组 path，
            // 保存从插入结点到根结点路径上结点的下标。
            // 对 path 进行二分查找，获得的 lo 即为插入结点的正确位置。
            // 删除最小元素则不需要改变。
            MinPQX<char> pq = new MinPQX<char>();
            string input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
            foreach (char c in input)
            {
                if (c == ' ')
                    continue;
                else if (c == '*')
                {
                    Console.WriteLine(pq.DelMin());
                }
                else
                {
                    pq.Insert(c);
                }
            }
        }
    }
}