using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._4
{
    /*
     * 1.4.4
     * 
     * 参照表 1.4.4 为 TwoSum 建立一张类似的表格。
     * 
     */
    class Program
    {
        public static int Count(int[] a)
        { //                                                                                
            int n = a.Length;
            int count = 0;
            for (int i = 0; i < n; ++i)
            {// 
                for (int j = i + 1; j < n; ++j)
                {// 
                    if (a[i] + a[j] == 0)
                    {
                        count++;// 
                    }
                }
            }
            return count;
        }

        // 句块   单次执行时间    频率             总时间
        //  D        t0        x（输入相关）        xt0
        //  C        t1        N^2/2 - N/2         t1(N^2/2 - N/2)
        //  B        t2            N               t2N
        //  A        t3            1               t3
        // 
        // 计
        // N^2/2)t1
        //  + N(t2 - t1/2)
        //      + t3 + xt0
        // 为（当 x 很小时）
        // N^2/2)t1
        // 长的数量级
        // ^2
    }
}
