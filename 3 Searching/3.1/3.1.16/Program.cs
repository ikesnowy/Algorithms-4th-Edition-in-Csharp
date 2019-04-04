using System;
using SymbolTable;

namespace _3._1._16
{
    /*
     * 3.1.16
     * 
     * 为 BinarySearchST 实现 delete() 方法。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 官方实现：https://algs4.cs.princeton.edu/31elementary/BinarySearchST.java.html

            BinarySearchST<string, string> st = new BinarySearchST<string, string>();
            st.Put("alpha", "α");
            st.Put("beta", "β");
            st.Put("gamma", "γ");

            foreach (string s in st.Keys())
                Console.WriteLine(s);

            st.Delete("beta");
            Console.WriteLine();

            foreach (string s in st.Keys())
                Console.WriteLine(s);
        }
    }
}
