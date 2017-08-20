using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._23
{
    /*
     * 1.4.23
     * 
     * 分数的二分查找。
     * 设计一个算法，使用对数级别的比较次数找出有理数 p/q，其中 0<p<q<N，
     * 比较形式为给定的数是否小于 x?
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            double[] a = new double[20];
            int i = 1;
            double j = 0;
            while (i <= 20)
            {
                a[i - 1] = j / i;
                i++;
                j++;
            }

            Console.WriteLine(BinarySearch(a, 7.0 / 8.0));// 
            Console.WriteLine(BinarySearch(a, 5.0 / 8.0));// 1
        }

        // 二分查找中的相等判定条件修改为差值小于 x，其中 x = 1/N^2
        static int BinarySearch(double[] a, double key)
        {
            int lo = 0;
            int hi = a.Length - 1;
            double threshold = 1.0 / (a.Length * a.Length);

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (Math.Abs(a[mid] - key) <= threshold)
                {
                    return mid;
                }
                else if (a[mid] < key)
                {
                    lo = mid + 1;
                }
                else
                {
                    hi = mid - 1;
                }
            }
            return -1;
        }
    }
}
