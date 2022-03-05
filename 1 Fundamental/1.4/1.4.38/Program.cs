using System;
using _1._4._38;

Console.WriteLine("数据量\t3-sum初级算法（秒）\tThreeSum（秒）\t比值");

for (var n = 125;; n += n)
{
    var timeA = DoubleTest.TimeTrial(n);
    var timeB = Measurement.DoubleTest.TimeTrial(n);

    Console.WriteLine($"{n}\t{timeA}\t{timeB}\t{timeA / timeB}");
}