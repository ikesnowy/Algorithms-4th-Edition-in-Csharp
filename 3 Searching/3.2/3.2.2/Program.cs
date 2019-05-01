using BinarySearchTree;
using System;

namespace _3._2._2
{    
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
