using System;
using PriorityQueue;

namespace _2._4._6
{
    /*
     * 2.4.6
     * 
     * 按照练习 2.4.1 的规则，
     * 用序列 P R I O * R * * I * T * Y * * * Q U E * * * U * E 
     * 操作一个初始空间为空的面向最大元素的堆，给出每次操作后堆的内容。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //    P
            //    R P
            //    R P I
            //    R P O I
            //    P O I
            //    R P O I
            //    P O I
            //    O I
            //    O I I
            //    I I
            //    T I I
            //    I I
            //    Y I I
            //    I I
            //    I
            //
            //    Q
            //    U Q
            //    U Q E
            //    Q E
            //    E
            //
            //    U
            //
            //    E
            //    

            MaxPQ<char> pq = new MaxPQ<char>();
            string input = "E D A B C";
            foreach (char c in input)
            {
                if (c == ' ')
                    continue;
                else if (c == '*')
                    pq.DelMax();
                else
                    pq.Insert(c);

                foreach (char n in pq)
                    Console.Write(n + " ");
                Console.WriteLine();
            }
        }
    }
}
