using System;

namespace _1._1._18
{
    /*
     * 1.1.18
     * 
     * 请看以下递归函数
     * public static int mystery(int a, int b)
     * {
     *    if (b == 0)    return 0;
     *    if (b % 2 == 0)    return mystery(a + a, b / 2);
     *    return mystery(a + a, b / 2) + a;
     * }
     * 
     * mystery(2, 25) 和 mystery(3, 11) 的返回值是多少？
     * 50, 33
     * 给定正整数 a 和 b，mystery(a, b) 计算的结果是什么？
     * mystery(a, b) = a * b
     * 将代码中的 + 替换为 * 并将 return 0 改为 return 1，然后回答相同的问题。
     * mysteryChanged(a, b) = a ^ b
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"mystery(2, 25): {mystery(2, 25)}");
            Console.WriteLine($"mystery(3, 11): {mystery(3, 11)}");

            Console.WriteLine($"mysteryChanged(2, 8): {mysteryChanged(2, 8)}");
            Console.WriteLine($"mysteryChanged(3, 2): {mysteryChanged(3, 2)}");
        }

        // ystery(a, b) = a * b
        // 用等式：a * b = 2a * b/2 = (2a * (b-1) / 2) + a
        // 例：
        // ystery(2, 25) =
        // ystery(2 + 2, 12) + 2 =
        // ystery(4 + 4, 6) + 2 =
        // ystery(8 + 8, 3) =
        // ystery(16 + 16, 1) + 16 + 2 =
        // ystery(32 + 32, 0) + 32 + 16 + 2 =
        //  + 32 + 16 + 2 =
        // 0
        public static int mystery(int a, int b)
        {
            if (b == 0) return 0;
            if (b % 2 == 0) return mystery(a + a, b / 2);
            return mystery(a + a, b / 2) + a;
        }

        // ysteryChanged(a, b) = a ^ b
        // 理（乘方与乘法，乘法与加法之间具有类似的性质）
        //  ^ b = (a ^ 2) ^ (b / 2) = (a ^ 2) ^ ((b - 1) / 2) * a
        public static int mysteryChanged(int a, int b)
        {
            if (b == 0) return 1;
            if (b % 2 == 0) return mysteryChanged(a * a, b / 2);
            return mysteryChanged(a * a, b / 2) * a;
        }
    }
}