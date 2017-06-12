using System;

namespace _1._1._12
{
    /*
     * 1.1.12
     * 
     * 以下代码段会打印出什么结果？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];
            for (int i = 0; i < 10; i++)
            {
                a[i] = 9 - i;
            }
            //a[10] = {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
            for (int i = 0; i < 10; i++)
            {
                a[i] = a[a[i]];
            }
            //a[0] = a[9] = 0; a[1] = a[8] = 1; a[2] = a[7] = 2;......
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
