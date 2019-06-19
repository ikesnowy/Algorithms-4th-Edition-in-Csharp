using System;

namespace _1._1._5
{

    class Program
    {
        static void Main(string[] args)
        {
            // 修改这两个值进行测试
            var x = 0.05;
            var y = 0.01;

            if (x > 0 && x < 1 && y > 0 && y < 1)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}