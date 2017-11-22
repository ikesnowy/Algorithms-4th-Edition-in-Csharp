using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._6
{
    /*
     * 2.1.6
     * 
     * 在所有主键都相同时，选择排序和插入排序谁更快？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 插入排序
            // 选择排序还需要一个寻找最小值的过程，
            // 至少需要 n + (n-1) + (n-2) + ... + 1 = n^2/2 次比较
            // 插入排序只需要 n 次就够了
        }
    }
}
