using System;
using System.Collections.Generic;
using System.Text;
using SortApplication;

namespace _2._5._13
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

        class Processor : IComparable<Processor>
        {
            private List<Job> jobs = new List<Job>();
            private double busyTime = 0;

            public Processor() { }

            public void Add(Job job)
            {
                this.jobs.Add(job);
                this.busyTime += job.Time;
            }

            public int CompareTo(Processor other)
            {
                return this.busyTime.CompareTo(other.busyTime);
            }

            public override string ToString()
            {
                var sb = new StringBuilder();
                var nowList = this.jobs.ToArray();
                for (var i = 0; i < nowList.Length; i++)
                {
                    sb.AppendLine(nowList[i].Name + " " + nowList[i].Time);
                }
                return sb.ToString();
            }
        }

        static void Main(string[] args)
        {
            var processorNum = int.Parse(Console.ReadLine());
            var jobNum = int.Parse(Console.ReadLine());

            var jobs = new Job[jobNum];
            for (var i = 0; i < jobNum; i++)
            {
                var jobDesc = Console.ReadLine().Split(' ');
                jobs[i] = new Job(jobDesc[0], double.Parse(jobDesc[1]));
            }

            Array.Sort(jobs);

            var processors = new MinPQ<Processor>(processorNum);
            for (var i = 0; i < processorNum; i++)
            {
                processors.Insert(new Processor());
            }

            for (var i = jobs.Length - 1; i >= 0; i--)
            {
                var min = processors.DelMin();
                min.Add(jobs[i]);
                processors.Insert(min);
            }

            while (!processors.IsEmpty())
            {
                Console.WriteLine(processors.DelMin());
            }
        }
    }
}
