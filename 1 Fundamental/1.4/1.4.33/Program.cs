﻿namespace _1._4._33
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // Integer = 4(int) + 8(对象开销) = 12
            // Date = 3 * 4(int * 3) + 8(对象开销) = 20
            // Counter = 4(String 的引用) + 4(int) + 8(对象开销) = 16
            // int[] = 8(对象开销) + 4(数组长度) + 4N = 12 + 4N
            // double[] = 8(对象开销) + 4(数组长度) + 8N = 12 + 8N
            // double[][] = 8(对象开销) + 4(数组长度) + 4M(引用) + M(12 + 8N)(M 个一维数组) = 12 + 16M + 8MN
            // String = 8(对象开销) + 3*4(int * 3) + 4(字符数组的引用) = 24
            // Node = 8(对象开销) + 4*2(引用*2) = 16
            // Stack = 8(对象开销) + 4(引用) + 4(int) + N(Node + Integer)(元素) = 16 + 28N
        }
    }
}
