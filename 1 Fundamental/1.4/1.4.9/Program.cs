namespace _1._4._9
{
    /*
     * 1.4.9
     * 
     * 已知由倍率实验可得某个程序的时间倍率为 2^b 且问题规模为 N0 时程序运行时间为 T，
     * 给出一个公式预测该程序在处理规模为 N 的问题时所需的运行时间。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // T(2N0) = (2^b) * T
            // T(4N0) = (2^b) * (2^b) * T = (2^2b) * T
            // T((2^r) * N0) = (2^rb) * T
            // T(N) = (2^(lg(N/N0)*b)) * T
        }
    }
}
