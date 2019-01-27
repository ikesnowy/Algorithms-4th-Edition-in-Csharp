using System;
using System.IO;
using System.Collections.Generic;

namespace _2._5._16
{
    /*
     * 2.5.16
     * 
     * 公正的选举。
     * 为了避免对名字排在字母表靠后的候选人的偏见，
     * 加州在 2003 年的州长选举中将所有候选人按照以下字母顺序排列：
     * R W Q O J M V A H B S G Z X N T C I E K U P D Y F L。
     * 创建一个遵守这种顺序的数据类型并编写一个用例 California，
     * 在它的静态方法 main() 中将字符串按照这种方式排序。
     * 假设所有字符串都是大写的。
     * 
     */
    class Program
    {
        // 官方解答：https://algs4.cs.princeton.edu/25applications/California.java.html
        private class CandidateComparer : IComparer<string>
        {
            private static readonly string order = "RWQOJMVAHBSGZXNTCIEKUPDYFL";
            public int Compare(string x, string y)
            {
                int n = Math.Min(x.Length, y.Length);
                for (int i = 0; i < n; i++)
                {
                    int a = order.IndexOf(x[i]);
                    int b = order.IndexOf(y[i]);
                    if (a != b)
                        return a.CompareTo(b);
                }

                return x.Length.CompareTo(y.Length);
            }
        }

        static void Main(string[] args)
        {
            // 数据来源：https://introcs.cs.princeton.edu/java/data/california-gov.txt
            StreamReader sr = new StreamReader(File.OpenRead("california-gov.txt"));
            string[] names = 
                sr.ReadToEnd()
                .ToUpper()
                .Split
                (new char[] { '\n', '\r' }, 
                StringSplitOptions.RemoveEmptyEntries);
            Array.Sort(names, new CandidateComparer());
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i]);
            }
        }
    }
}
