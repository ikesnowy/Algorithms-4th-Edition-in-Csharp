using System;
using BinarySearchTree;

namespace _3._2._30
{
    class Program
    {
        static void Main(string[] args)
        {
            var bst = new BST<int, int>();
            bst.Put(4, 4);
            bst.Put(6, 6);
            bst.Put(10, 10);
            Console.WriteLine(BST<int, int>.IsOrdered(bst));
        }
    }
}
