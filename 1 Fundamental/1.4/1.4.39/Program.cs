using System;

namespace _1._4._39
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("数据量\t重复次数\t平均耗时");
            for (var n = 125; true; n += n)
            {
                for (var i = 10; i <= 1000; i *= 10)
                {
                    var time = DoubleTest.TimeTrial(n, i);
                    Console.WriteLine($"{n}\t{i}\t{time}");
                }
                Console.WriteLine();
            }
        }
    }
}
