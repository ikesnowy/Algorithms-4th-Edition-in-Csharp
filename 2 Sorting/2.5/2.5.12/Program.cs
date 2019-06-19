using System;

namespace _2._5._12
{
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