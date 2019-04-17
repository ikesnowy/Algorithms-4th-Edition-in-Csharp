using System;

namespace _1._4._38
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数据量\t3-sum初级算法（秒）\tThreeSum（秒）\t比值");

            for (int n = 125; true; n += n)
            {
                double timeA = DoubleTest.TimeTrial(n);
                double timeB = Measurement.DoubleTest.TimeTrial(n);

                Console.WriteLine($"{n}\t{timeA}\t{timeB}\t{timeA / timeB}");
            }
        }
    }
}
