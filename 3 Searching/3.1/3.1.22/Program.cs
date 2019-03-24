using System;
using SymbolTable;

namespace _3._1._22
{
    /*
     * 3.1.22
     * 
     * 自组织查找。
     * 自组织查找指的是一种能够将数组元素重新排序
     * 使得被访问频率较高的元素更容易被找到的查找算法。
     * 请修改你为习题 3.1.2 给出的答案，在每次查找命中时：
     * 将被找到的键值对移动到数组的开头，将所有中间的键值对向右移动一格。
     * 这个启发式的过程被称为前移编码。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            MoveToFrontArrayST<string, string> st = new MoveToFrontArrayST<string, string>();
            st.Put("alpha", "α");
            st.Put("beta", "β");
            st.Put("omega", "ω");

            foreach (string s in st.Keys())
                Console.WriteLine(s);

            st.Get("beta");
            Console.WriteLine("Get(\"beta\")");

            foreach (string s in st.Keys())
                Console.WriteLine(s);
        }
    }
}
