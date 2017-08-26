using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._39
{
    /*
     * 1.4.39
     * 
     * 改进倍率测试的精度。
     * 修改 DoublingRatio，使它接受另一个命令行参数来指定对于每个 N 值调用 timeTrial() 方法的次数。
     * 用程序对每个 N 执行 10、100 和 1000 遍实验并评估结果的准确程度。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数据量\t重复次数\t平均耗时");
            for (int n = 125; true; n += n)
            {
                for (int i = 10; i <= 1000; i *= 10)
                {
                    double time = DoubleTest.TimeTrial(n, i);
                    Console.WriteLine($"{n}\t{i}\t{time}");
                }
                Console.WriteLine();
            }
        }
    }
}
