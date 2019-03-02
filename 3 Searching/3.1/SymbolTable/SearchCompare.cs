using System;
using System.Diagnostics;

namespace SymbolTable
{
    /// <summary>
    /// 静态类，提供一系列用于测试符号表的方法。
    /// </summary>
    public static class SearchCompare
    {
        /// <summary>
        /// 用指定的数据测试符号表，返回 <see cref="FrequencyCounter"/> 用去的时间。
        /// </summary>
        /// <param name="st">用于测试的空符号表。</param>
        /// <param name="filename">读入字符串的存放文件路径。</param>
        /// <returns>计算一次最常出现单词的时间。（毫秒）</returns>
        public static long Time<TKey>(IST<TKey, int> st, TKey[] keys)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            FrequencyCounter.MostFrequentlyKey(st, keys);
            sw.Stop();
            return sw.ElapsedMilliseconds;
        }

        /// <summary>
        /// 生成非负 <see cref="double"/> 数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>大小为 <paramref name="n"/> 的非负 <see cref="double"/> 数组。</returns>
        public static double[] GetRandomArrayDouble(int n)
        {
            Random random = new Random();
            double[] data = new double[n];
            for (int i = 0; i < n; i++)
            {
                data[i] = double.MaxValue * random.NextDouble();
            }
            return data;
        }
    }
}
