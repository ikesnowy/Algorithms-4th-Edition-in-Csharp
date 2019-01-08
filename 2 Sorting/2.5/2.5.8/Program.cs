using System;
using System.IO;

namespace _2._5._8
{
    /*
     * 2.5.8
     * 
     * 编写一段程序 Frequency，
     * 从标准输入读取一列字符串，
     * 并按照字符串出现频率由高到低的顺序打印出每个字符串及其出现次数。
     * 
     */
    class Program
    {
        class Record : IComparable<Record>
        {
            public string Key { get; set; }
            public int Value { get; set; }

            public Record(string key, int value)
            {
                this.Key = key;
                this.Value = value;
            }

            public int CompareTo(Record other)
            {
                return this.Value.CompareTo(other.Value);
            }
        }

        static void Main(string[] args)
        {
            // 官方解答见：https://algs4.cs.princeton.edu/25applications/Frequency.java.html
            string filename = "tale.txt";
            StreamReader sr = new StreamReader(File.OpenRead(filename));
            string[] a = sr.ReadToEnd().Split(new char[] { ' ', '\n', '\r' });
            Array.Sort(a);

            Record[] records = new Record[a.Length];
            string word = a[0];
            int freq = 1;
            int m = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (!a[i].Equals(word))
                {
                    records[m++] = new Record(word, freq);
                    word = a[i];
                    freq = 0;
                }
                freq++;
            }
            records[m++] = new Record(word, freq);

            Array.Sort(records, 0, m);
            // 只显示频率为前 1% 的单词
            for (int i = m - 1; i >= m * 0.99; i--)
                Console.WriteLine(records[i].Value + " " + records[i].Key);
        }
    }
}
