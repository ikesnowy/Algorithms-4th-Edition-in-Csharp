using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Measurement;

namespace _1._4._11
{
    /*
     * 1.4.11
     * 
     * 为 StaticSETofInts （请见表 1.2.15） 添加一个实例方法 howMany()，
     * 找出给定键的出现次数且在最坏情况下所需的运行时间应该和 log(N) 成正比。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = new int[5] { 5, 5, 5, 5, 1 };
            StaticSETofInts set = new StaticSETofInts(a);
            Console.WriteLine(set.HowMany(5));
        }
    }
}
