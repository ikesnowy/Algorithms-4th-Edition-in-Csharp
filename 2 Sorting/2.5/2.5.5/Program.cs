﻿namespace _2._5._5
{
    
    class Program
    {
        static void Main(string[] args)
        {
            // 因为选择排序会交换不直接相邻的元素。
            // 例如 B1 B2 A
            // 排序后变为 A B2 B1
            // B 的相对位置被改变
            // 如果将交换限制在相邻元素之间（插入排序）
            // B1 B2 A
            // B1 A B2
            // A B1 B2
            // 就变成稳定的了
        }
    }
}
