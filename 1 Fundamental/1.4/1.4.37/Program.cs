using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._4._37
{
    /*
     * 1.4.37
     * 
     * 自动装箱的性能代价。
     * 通过实验在你的计算机上计算使用自动装箱所付出的性能代价。
     * 实现一个 FixedCapacityStackOfInts，
     * 并使用类似 DoublingRatio 的用例比较它和泛型 FixedCapacityStack 在进行大量 push() 和 pop() 时的性能。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("测试量\t非泛型耗时（毫秒）\t泛型耗时（毫秒）\t差值");
            for (int n = 250; true; n += n)
            {
                double time = DoubleTest.TimeTrial(n);
                double timeGeneric = DoubleTest.TimeTrialGeneric(n);
                Console.WriteLine($"{n}\t{time}\t{timeGeneric}\t{Math.Abs(time - timeGeneric)}");
            }
        }
    }
}
