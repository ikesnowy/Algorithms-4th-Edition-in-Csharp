using System;

namespace _2._1._19
{
    class Program
    {
        // 开放题，没有标准答案
        // 共参考的最差情况为 n^(3/2)
        // 本例共 793 次
        static void Main(string[] args)
        {
            int[] b;
            ShellSort sort = new ShellSort();
            b = ShellSortWorstCase.GetWorst(100);
            for (int i = 0; i < b.Length; i++)
            {
                Console.Write(b[i] + " ");
            }
            Console.WriteLine();
            sort.Sort(b);
        }
    }
}
