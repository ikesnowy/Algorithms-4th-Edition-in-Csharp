using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._28
{
    /*
     * 3.1.28
     * 
     * 有序的插入。
     * 修改 BinarySearchST，使得插入一个比当前所有键都大的键只需要常数时间
     * （这样在构造符号表时有序的使用 put() 插入键值对就只需要线性时间了）。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 100000;

            Stopwatch sw = new Stopwatch();
            var bst = new BinarySearchST<int, int>();
            var bstOrdered = new BinarySearchSTOrderedInsertion<int, int>();

            Console.WriteLine("n = " + n);
            Console.Write("Origin: ");
            sw.Start();
            for (int i = 0; i < n; i++)
                bst.Put(i, i);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.Write("Modified: ");
            sw.Restart();
            for (int i = 0; i < n; i++)
                bstOrdered.Put(i, i);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}
