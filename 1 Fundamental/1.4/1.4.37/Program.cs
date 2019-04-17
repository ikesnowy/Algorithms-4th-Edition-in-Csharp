using System;

namespace _1._4._37
{
    
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
