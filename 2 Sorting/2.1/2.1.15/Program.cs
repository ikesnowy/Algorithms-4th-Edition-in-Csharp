using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._15
{
    /*
     * 2.1.15
     * 
     * 昂贵的交换。
     * 一家货运公司的一位职工得到了一项任务，
     * 需要将若干大货箱按照发货时间摆放。
     * 比较发货时间很容易（对照标签即可），
     * 但将两个货箱交换位置则很困难（移动麻烦）。
     * 仓库已经快满了，只有一个空闲的仓位。
     * 这位职员应该使用哪种排序算法呢？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 这里指的是比较代价小而交换代价昂贵的情况
            // 显然我们应该使用交换次数最少的排序算法
            // 于是答案就是选择排序，只需要交换 N 次
        }
    }
}
