namespace _1._4._6
{
    /*
     * 1.4.6
     * 
     * 给出以下代码段的运行时间的增长数量级（作为 N 的函数）。
     * a.
     * int sum = 0;
     * for (int n = N; n > 0; n /= 2)
     *     for (int i = 0; i < n; i++)
     *         sum++;
     * b.
     * int sum = 0;
     * for (int i = 1; i < N; n *= 2)
     *     for (int j = 0; j < i; j++)
     *         sum++;
     * c.
     * int sum = 0;
     * for (int i = 1; i < N; n *= 2)
     *     for (int j = 0; j < N; j++)
     *         sum++;
     *         
     */
    class Program
    {
        static void Main(string[] args)
        {
            //a. 线性增长 (N + N/2 + N/4 + ... = ~2N)
            //b. 线性增长 (1 + 2 + 4 + 8 + ... = ~2N)
            //c. 线性对数增长 (NlogN)
        }
    }
}
