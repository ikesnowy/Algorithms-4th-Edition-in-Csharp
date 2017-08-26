using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._38
{
    /*
     * 1.4.38
     * 
     * 3-sum 的初级算法的实现。
     * 通过实验评估以下 ThreeSum 内循环的实现性能。
     * for (int i = 0; i < N; i++)
     * 	for (int j = 0; j < N; j++)
     * 		for (int k = 0; k < N; k++)
     * 			if (i < j && j < k)
     * 				if (a[i] + a[j] + a[k] == 0)
     * 					cnt++;
     * 为此实现另一个版本的 DoublingTest，计算该程序和 ThreeSum 的运行时间的比例。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数据量\t3-sum初级算法(\tThreeSum\t比值");

            for (int n = 125; true; n += n)
            {
                double timeA = DoubleTest.TimeTrial(n);
                double timeB = Measurement.DoubleTest.TimeTrial(n);

                Console.WriteLine($"{n}\t{timeA}\t{timeB}\t{timeA / timeB}");
            }
        }
    }
}
