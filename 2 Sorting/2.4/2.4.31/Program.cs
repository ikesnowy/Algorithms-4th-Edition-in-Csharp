using System;
using PriorityQueue;

namespace _2._4._31
{
    /*
     * 2.4.31
     * 
     * 快速插入。
     * 用基于比较的方式实现 MinPQ 的 API，
     * 使得插入元素需要 ~loglogN 次比较，
     * 删除最小元素需要 ~2logN 次比较。
     * 提示：在 swim() 方法中用二分查找来寻找祖先结点。
     * 
     */
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
