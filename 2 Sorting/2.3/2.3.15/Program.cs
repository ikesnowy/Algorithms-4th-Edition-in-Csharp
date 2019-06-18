using System;

namespace _2._3._15
{
    class Program
    {
        static void Main(string[] args)
        {
            // 思路：先随机拿起一个螺丝（枢轴），与所有的螺母比较，找到合适的那一个
            // 再用找到的螺母与其他螺丝比较，将他们分为较大和较小两部分。
            Bolt<int>[] bolts = new Bolt<int>[10];
            Nut<int>[] nuts = new Nut<int>[10];
            for (int i = 0; i < 10; i++)
            {
                bolts[i] = new Bolt<int>(i);
                nuts[i] = new Nut<int>(i);
            }
            BoltsAndNuts sort = new BoltsAndNuts();
            sort.Sort(bolts, nuts);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(bolts[i].Value + " ");
            }
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.Write(nuts[i].Value + " ");
            }
            Console.WriteLine();
        }
    }
}
