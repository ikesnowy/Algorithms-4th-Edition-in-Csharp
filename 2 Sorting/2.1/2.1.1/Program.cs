﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._1._1
{
    /*
     * 2.1.1
     * 
     * 按照算法 2.1 所示轨迹的格式给出选择排序是如何将数组 E A S Y Q U E S T I O N 排序的。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //                                    a[]
            // i    min     0   1   2   3   4   5   6   7   8   9   10  11
            //              E   A   S   Y   Q   U   E   S   T   I   O   N
            // 0    1       E   A   S   Y   Q   U   E   S   T   I   O   N
            // 1    1       A   E   S   Y   Q   U   E   S   T   I   O   N
            // 2    6       A   E   S   Y   Q   U   E   S   T   I   O   N
            // 3    9       A   E   E   Y   Q   U   S   S   T   I   O   N
            // 4    11      A   E   E   I   Q   U   S   S   T   Y   O   N
            // 5    10      A   E   E   I   N   U   S   S   T   Y   O   Q
            // 6    11      A   E   E   I   N   O   S   S   T   Y   U   Q
            // 7    7       A   E   E   I   N   O   Q   S   T   Y   U   S
            // 8    11      A   E   E   I   N   O   Q   S   T   Y   U   S
            // 9    11      A   E   E   I   N   O   Q   S   S   Y   U   T
            // 10   10      A   E   E   I   N   O   Q   S   S   T   U   Y
            // 11   11      A   E   E   I   N   O   Q   S   S   T   U   Y
        }
    }
}
