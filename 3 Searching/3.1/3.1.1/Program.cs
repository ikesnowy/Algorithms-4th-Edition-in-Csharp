using System;
using SymbolTable;

namespace _3._1._1
{
    /*
     * 3.1.1
     * 
     * 编写一段程序，创建一张符号表并建立字母成绩和数值分数的对应关系，如下表所示。
     * 从标准输入读取一系列字母成绩，计算并打印 GPA（字母成绩对应的分数的平均值）。
     * 
     * |  A+  |  A   |  A-  |  B+  |  B   |  B-  |  C+  |  C   |  C-  |  D   |  F   |
     * | 4.33 | 4.00 | 3.67 | 3.33 | 3.00 | 2.67 | 2.33 | 2.00 | 1.67 | 1.00 | 0.00 |
     * 
     */
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/31elementary/GPA.java.html
        // ST.java：https://algs4.cs.princeton.edu/code/edu/princeton/cs/algs4/ST.java.html
        static void Main(string[] args)
        {
            ST<string, double> st = new ST<string, double>();
            st.Put("A+", 4.33);
            st.Put("A", 4.00);
            st.Put("A-", 3.67);
            st.Put("B+", 3.33);
            st.Put("B", 3.00);
            st.Put("B-", 2.67);
            st.Put("C+", 2.33);
            st.Put("C", 2.00);
            st.Put("C-", 1.67);
            st.Put("D", 1.00);
            st.Put("F", 0.00);

            double total = 0;
            string[] gpas = Console.ReadLine().Split(' ');
            foreach (string gpa in gpas)
                total += st.Get(gpa);
            total /= gpas.Length;
            Console.WriteLine("GPA=" + total);
        }
    }
}
