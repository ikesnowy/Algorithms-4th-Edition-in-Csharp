using System;

namespace _1._2._18
{
    /*
     * 1.2.18
     * 
     * 累加器的方法。
     * 以下代码为 Accumulator 类添加了 var() 和 stddev() 方法，
     * 它们计算了 addDataValue() 方法的参数的方差和标准差，验证这段代码：
     * 与直接对所有数据的平方求和的方法相比较，
     * 这种实现能够更好的避免四舍五入产生的误差。
     * 
     */
    class Program
    {
        // 数据比较大时—— 例如 10^9 加上随机小数组成的数列，这时 double 的小数精度将受限。
        // 和之后整数部分更大，小数部分将自动四舍五入，出现误差
        // 时再计算平均值时将会带来较大的误差。
        // 此采用另一个递推公式：
        //  为下标。
        // k = Mk-1+ (xk – Mk-1)/k
        // k = Sk-1 + (xk – Mk-1)*(xk – Mk).
        // 差 s^2 = Sk/(k – 1).
        // 种情况下并没有直接对所有输入值求和，小数精度不受到整数部分长度的影响。
        static void Main(string[] args)
        {
            int T = 100000;
            Random random = new Random();
            Accumulator a = new Accumulator();
            for (int t = 0; t < T; ++t)
            {
                a.AddDataValue(random.NextDouble() + 1000000000);
            }

            Console.WriteLine(a.Stddev());
            Console.WriteLine(a);
        }
    }
}
