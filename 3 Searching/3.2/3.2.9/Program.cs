using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using BinarySearchTree;

namespace _3._2._9
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var n = 2; n <= 6; n++)
            {
                Console.WriteLine($"n={n}");
                var list = new List<int>();
                for (var i = 0; i < n; i++)
                {
                    list.Add(i);
                }

                var cases = GetPermutation(list);
                foreach (var test in cases)
                {
                    var tree = new BST<int, int>();
                    foreach (var num in test)
                    {
                        tree.Put(num, num);
                    }
                    Console.WriteLine(tree);
                }
            }
        }
        
        static List<int[]> GetPermutation(List<int> s)
        {
            var permutation = new List<int[]>();
            var temp = new List<int>();
            Permutation(s, temp, permutation);
            return permutation;
        }

        static void Permutation(List<int> pool, List<int> path, List<int[]> result)
        {
            if (pool.Count == 0)
            {
                result.Add(path.ToArray());
                return;
            }

            for (var i = 0; i < pool.Count; i++)
            {
                var item = pool[i];
                path.Add(item);
                pool.RemoveAt(i);
                Permutation(pool, path, result);
                pool.Insert(i, item);
                path.Remove(item);
            }
        }
    }
}
