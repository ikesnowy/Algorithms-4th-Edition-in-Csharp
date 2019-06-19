using System;

namespace _3._2._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(OptCompares(8));
        }

        private static int OptCompares(int n)
        {
            // 完全二叉树 = 满二叉树 + 多余结点
            // 满二叉树的层数。
            var l = (int)Math.Log(n + 1, 2);
            // 多余结点的个数。
            var extraNodes = n + 1 - (int)Math.Pow(2, l);

            var depthSum =
                extraNodes * l + (l - 2) * (int)Math.Pow(2, l) + 2;
            return depthSum / n + 1;
        }
    }
}