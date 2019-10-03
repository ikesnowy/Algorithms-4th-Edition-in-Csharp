using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BSTBalanced<TKey, TValue> : BST<TKey, TValue> where TKey : IComparable<TKey>
    {
        public BSTBalanced(KeyValuePair<TKey, TValue>[] init)
        {
            Array.Sort(init, (left, right) => left.Key.CompareTo(right.Key));
            root = BuildTree(init, 0, init.Length - 1);
        }

        private Node BuildTree(KeyValuePair<TKey, TValue>[] init, int lo, int hi)
        {
            if (lo > hi)
            {
                return null;
            }

            var mid = (hi - lo) / 2 + lo;
            var current = new Node(init[mid].Key, init[mid].Value, 1);
            current.Left = BuildTree(init, lo, mid - 1);
            current.Right = BuildTree(init, mid + 1, hi);
            if (current.Left != null)
            {
                current.Size += current.Left.Size;
            }

            if (current.Right != null)
            {
                current.Size += current.Right.Size;
            }
            return current;
        }
    }
}