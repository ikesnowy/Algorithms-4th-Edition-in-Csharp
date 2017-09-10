using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnionFind;

namespace _1._5._1
{
    /*
     * 1.5.1
     * 
     * 使用 quick-find 算法处理序列 9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2 。
     * 对于输入的每一对整数，给出 id[] 数组的内容和访问数组的次数。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = "9-0 3-4 5-8 7-2 2-1 5-7 0-3 4-2".Split(' ');
            var quickFind = new QuickFindUF(10);

            foreach (string s in input)
            {
                quickFind.ResetArrayCount();

                string[] numbers = s.Split('-');
                int p = int.Parse(numbers[0]);
                int q = int.Parse(numbers[1]);

                int[] id = quickFind.GetID();
                quickFind.Union(p, q);
                foreach (int root in id)
                {
                    Console.Write(root + " ");
                }
                Console.WriteLine("数组访问：" + quickFind.ArrayVisitCount);
            }
        }
    }
}
