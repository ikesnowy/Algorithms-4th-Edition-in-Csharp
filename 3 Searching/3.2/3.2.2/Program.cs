using BinarySearchTree;
using System;

namespace _3._2._2
{
    /*
     * 3.2.2
     * 
     * 将 A X C S E R H 作为键按顺序插入将会构造出一棵最坏情况下的二叉查找树结构，
     * 最下方的结点的两个链接全为空，其它结点都含有一个空链接。
     * 用这些键给出构造最坏情况下的树的其他 5 种排列。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] worstInput =
            {
                "A X C S E R H",
                "X A S C R E H",
                "A C E H R S X",
                "X S R H E C A",
                "X A S R H E C",
                "A X S R H E C"
            };

            foreach (string worst in worstInput)
            {
                string[] keys = worst.Split(' ');
                BST<string, string> bst = new BST<string, string>();
                foreach (string key in keys)
                {
                    bst.Put(key, key);
                }
                Console.WriteLine(bst);
            }
        }
    }
}
