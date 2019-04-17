using System;
using PriorityQueue;

namespace _2._4._6
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // P
            // R P
            // R P I
            // R P I O
            // P O I
            // R P I O
            // P O I
            // O I
            // O I I
            // I I
            // T I I
            // I I
            // Y I I
            // I I
            // I
            // 
            // Q
            // U Q
            // U Q E
            // Q E
            // E
            // 
            // U
            // 
            // E

            MaxPQ<char> pq = new MaxPQ<char>();
            string input = "P R I O * R * * I * T * Y * * * Q U E * * * U * E";
            foreach (char c in input)
            {
                if (c == ' ')
                    continue;
                else if (c == '*')
                    pq.DelMax();
                else
                    pq.Insert(c);
                
                Console.WriteLine(pq);
            }
        }
    }
}
