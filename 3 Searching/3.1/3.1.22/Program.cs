using System;
using SymbolTable;

namespace _3._1._22
{
    
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
