using System;

namespace _2._5._12
{
    /*
     * 2.5.12
     * 
     * 调度。编写一段程序 SPT.java，
     * 从标准输入中读取任务的名称和所需的运行时间，
     * 用 2.5.4.3 节所述的最短处理时间优先的原则打印出一份调度计划，
     * 使得任务完成的平均时间最小。
     * 
     */
    class Program
    {
        class Job : IComparable<Job>
        {
            public string Name;
            public double Time;

            public Job(string name, double time)
            {
                this.Name = name;
                this.Time = time;
            }

            public int CompareTo(Job other)
            {
                return this.Time.CompareTo(other.Time);
            }
        }

        static void Main(string[] args)
        {
            // 官方解答：https://algs4.cs.princeton.edu/25applications/SPT.java.html
            int n = int.Parse(Console.ReadLine());
            Job[] jobs = new Job[n];
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(' ');
                jobs[i] = new Job(input[0], double.Parse(input[1]));
            }
            Array.Sort(jobs);
            for (int i = 0; i < jobs.Length; i++)
            {
                Console.WriteLine(jobs[i].Name + " " + jobs[i].Time);
            }
        }
    }
}
