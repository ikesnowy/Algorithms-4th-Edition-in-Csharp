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
                Name = name;
                Time = time;
            }

            public int CompareTo(Job other)
            {
                return Time.CompareTo(other.Time);
            }
        }

        static void Main(string[] args)
        {
            // 官方解答：https://algs4.cs.princeton.edu/25applications/SPT.java.html
            var n = int.Parse(Console.ReadLine());
            var jobs = new Job[n];
            for (var i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(' ');
                jobs[i] = new Job(input[0], double.Parse(input[1]));
            }
            Array.Sort(jobs);
            for (var i = 0; i < jobs.Length; i++)
            {
                Console.WriteLine(jobs[i].Name + " " + jobs[i].Time);
            }
        }
    }
}