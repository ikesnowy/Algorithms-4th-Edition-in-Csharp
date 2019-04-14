using System;
using BinarySearchTree;

namespace _3._2._1
{
    /// <summary>
    /// 将 E A S Y Q U E S T I O N 作为键按顺序插入一棵初始为空的二叉查找树中
    /// （方便起见设第 i 个键对应的值为 i），画出生成的二叉查找树。
    /// 构造这棵树需要多少次比较？
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // 0 + 1 + 1 + 2 + 2 + 3 + 1 + 2 + 4 + 3 + 4 + 5 = 28 次
            //             |--------------------------------E--------------------------------|
            //             A                                                |----------------S----------------|
            //                                                     |--------Q                        |--------Y
            //                                                     I----|                       |----U
            //                                                       |--O                       T
            //                                                       N

            BST<string, int> bst = new BST<string, int>();
            string[] input = "E A S Y Q U E S T I O N".Split(' ');

            for (int i = 1; i <= input.Length; i++)
            {
                Console.WriteLine("Put(" + input[i - 1] + ", " + i + ");");
                bst.Put(input[i - 1], i);
                Console.WriteLine(bst);
            }
        }
    }
}
