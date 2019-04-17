using System;
using System.IO;
using PriorityQueue;

namespace _2._4._25
{
    
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1000000;

            MinPQ<CubeSum> pq = new MinPQ<CubeSum>();
            Console.WriteLine("正在初始化");
            for (int i = 0; i <= n; i++)
            {
                pq.Insert(new CubeSum(i, i));
            }

            FileStream ostream = new FileStream("./result.txt", FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(ostream);
            Console.WriteLine("正在写入文件……");
            CubeSum prev = new CubeSum(-1, -1);
            long pairCount = 0;
            while (!pq.IsEmpty())
            {
                CubeSum s = pq.DelMin();
                if (s.sum == prev.sum)
                {
                    sw.WriteLine(s + " = " + prev.i + "^3 + " + prev.j + "^3");
                    pairCount++;
                }         
                if (s.j < n)
                    pq.Insert(new CubeSum(s.i, s.j + 1));
                prev = s;
            }
            sw.WriteLine("共找到" + pairCount + "对数据");
            Console.WriteLine("共找到" + pairCount + "对数据");
            sw.Close();
            Console.WriteLine("结果已经保存到程序所在目录下的 result.txt 文件中");
        }
    }
}
