using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._3._9
{
    /*
     * 2.3.9
     * 
     * 请说明 Quick.sort() 在处理只有两种主键值时的行为，
     * 以及在处理只有三种主键值的数组时的行为。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 切分时，枢轴左侧都是小于（或等于）枢轴的，
            // 右侧都是大于（或等于）枢轴的
            // 只有两种主键值时，
            // 第一次切分之后，某一侧的元素将全部相同
            // （如果枢轴选了较大的，那么右侧将全部相同，反之则左侧全部相同）
            // 每次切分时
            // 
            // 只有三种主键值时，和一般快速排序并无不同。
            // 但如果第一次切分时选择了中间值作为枢轴，且中间值只有一个
            // 那么只需要一次切分数组便会有序。
        }
    }
}
