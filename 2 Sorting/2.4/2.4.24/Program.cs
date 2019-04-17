using System;
using PriorityQueue;

namespace _2._4._24
{
    
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
