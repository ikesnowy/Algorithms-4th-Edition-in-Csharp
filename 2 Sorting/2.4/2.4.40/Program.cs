using System;
using System.IO;
using PriorityQueue;

namespace _2._4._40
{
    
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("n\tOrigin\tFloyd\tRatio");

            int n = 1000;     // 当数据量到达 10^9 时会需要 2G 左右的内存
            int multiTen = 7;
            for (int i = 0; i < multiTen; i++)
            {
                short[] data = GetRandomArray(n);
                BackupArray(data, i);       // 暂存数组
                long originCount = HeapAnalysis.Sort(data);
                RestoreArray(data, i);      // 恢复数组
                long floydCount = HeapFloydAnalysis.Sort(data);
                Console.WriteLine(n + "\t" + originCount + "\t" + floydCount + "\t" + (double)floydCount / originCount);
                n *= 10;
            }
        }

        static void BackupArray(short[] data, int index)
        {
            StreamWriter sw =
                File.CreateText
                (Environment.CurrentDirectory + 
                Path.DirectorySeparatorChar + 
                "data" + index + ".txt");
            for (int i = 0; i < data.Length; i++)
            {
                sw.WriteLine(data[i]);
            }
            sw.Flush();
            sw.Close();
        }

        static void RestoreArray(short[] data, int index)
        {
            StreamReader sr = 
                File.OpenText
                (Environment.CurrentDirectory + 
                Path.DirectorySeparatorChar + 
                "data" + index + ".txt");
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = short.Parse(sr.ReadLine());
            }
            sr.Close();
        }

        static short[] GetRandomArray(int n)
        {
            short[] data = new short[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = (short)random.Next();
            }
            return data;
        }
    }
}
