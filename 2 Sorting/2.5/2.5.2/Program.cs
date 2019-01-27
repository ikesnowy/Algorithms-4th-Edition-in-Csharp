using System;
using System.Collections.Generic;

namespace _2._5._2
{
    /*
     * 2.5.2
     * 
     * 编写一段程序，从标准输入读入一列单词并打印出其中所有由两个单词组成的组合词。
     * 例如，如果输入的单词为 after、thought 和 afterthought，
     * 那么 afterthought 就是一个组合词。
     * 
     */
    class Program
    {
        /// <summary>
        /// 根据字符串长度进行比较。
        /// </summary>
        class StringLengthComparer : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return x.Length.CompareTo(y.Length);
            }
        }

        /// <summary>
        /// 二分查找，返回符合条件的最小下标。
        /// </summary>
        /// <param name="keys">搜索范围。</param>
        /// <param name="length">搜索目标。</param>
        /// <param name="lo">起始下标。</param>
        /// <param name="hi">终止下标。</param>
        /// <returns></returns>
        static int BinarySearch(string[] keys, int length, int lo, int hi)
        {
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (keys[mid].Length == length)
                {
                    while (mid >= lo && keys[mid].Length == length)
                        mid--;
                    return mid + 1;
                }
                else if (length > keys[mid].Length)
                    lo = mid + 1;
                else
                    hi = mid - 1;
            }
            return -1;
        }

        static void Main(string[] args)
        {
            string[] keywords = Console.ReadLine().Split(' ');
            Array.Sort(keywords, new StringLengthComparer());
            int minLength = keywords[0].Length * 2;
            // 找到第一个大于 minLength 的字符串
            int canCombine = 0;
            while (keywords[canCombine].Length < minLength &&
                canCombine < keywords.Length)
                canCombine++;

            // 依次测试是否可能
            while (canCombine < keywords.Length)
            {
                int sum = keywords[canCombine].Length;
                for (int i = 0; i < canCombine; i++)
                {
                    int start = BinarySearch(keywords, sum - keywords[i].Length, i, canCombine);
                    if (start != -1)
                    {
                        while (keywords[start].Length + keywords[i].Length == sum)
                        {
                            if (keywords[start] + keywords[i] == keywords[canCombine])
                                Console.WriteLine(keywords[canCombine] + " = " + keywords[start] + " + " + keywords[i]);
                            else if (keywords[i] + keywords[start] == keywords[canCombine])
                                Console.WriteLine(keywords[canCombine] + " = " + keywords[i] + " + " + keywords[start]);
                            start++;
                        }                   
                    }
                }
                canCombine++;
            }
        }
    }
}
