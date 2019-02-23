using System;
using SymbolTable;

namespace _3._1._12
{
    /*
     * 3.1.12
     * 
     * 修改 BinarySearchST，用一个 Item 对象的数组而非两个平行数组来保存键和值。
     * 添加一个构造函数，接受一个 Item 的数组为参数并将其归并排序。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            var items = new Item<string, string>[]
            {
                new Item<string, string>() { Key="gamma", Value = "γ"},
                new Item<string, string>() { Key="alpha", Value="α" },
                new Item<string, string>() { Key="beta", Value = "β"}
            };
            var st = new ItemBinarySearchST<string, string>(items);

            foreach (string s in st.Keys())
                Console.WriteLine(s + " " + st.Get(s));
        }
    }
}
