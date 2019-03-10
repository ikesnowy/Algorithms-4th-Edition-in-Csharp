using System;
using System.Collections.Generic;
using System.IO;

namespace SymbolTable
{
    /// <summary>
    /// 计算文本文档中出现次数最高的字符串，
    /// 用于测试符号表的 Get 和 Put 方法。
    /// </summary>
    public class FrequencyCounter
    {
        /// <summary>
        /// 这个类不能被初始化。
        /// </summary>
        private FrequencyCounter() { }

        /// <summary>
        /// 计算数组中不重复元素的数量。
        /// </summary>
        /// <typeparam name="TKey">数组元素的类型。</typeparam>
        /// <param name="keys">包含重复元素的数组。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns><paramref name="keys"/> 中的不重复元素数量。</returns>
        public static int CountDistinct<TKey>(TKey[] keys, IST<TKey, int> st)
        {
            int distinct = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                if (!st.Contains(keys[i]))
                    st.Put(keys[i], distinct++);
            }
            return distinct;
        }

        /// <summary>
        /// 找到同时存在于字典和输入文件的单词并统计频率，
        /// 分别按照频率降序和字典升序输出。
        /// </summary>
        /// <param name="filename">输入文件。</param>
        /// <param name="dictionaryFile">字典文件。</param>
        public static void LookUpDictionary(string filename, string dictionaryFile, int minLength)
        {
            // 初始化字典
            StreamReader sr = new StreamReader(File.OpenRead(dictionaryFile));
            string[] words = sr.ReadToEnd().Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            BinarySearchST<string, int> dictionary = new BinarySearchST<string, int>();
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length > minLength)
                    dictionary.Put(words[i], i);
            }
            sr.Close();

            // 读入单词
            StreamReader srFile = new StreamReader(File.OpenRead(filename));
            string[] inputs = srFile.ReadToEnd().Split(new char[] { ' ', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            srFile.Close();

            BinarySearchST<int, string> stDictionary = new BinarySearchST<int, string>();
            BinarySearchST<string, int> stFrequency = new BinarySearchST<string, int>();
            foreach (string s in inputs)
            {
                if (stFrequency.Contains(s))
                    stFrequency.Put(s, stFrequency.Get(s) + 1);
                else if (dictionary.Contains(s))
                {
                    stFrequency.Put(s, 1);
                    stDictionary.Put(dictionary.Get(s), s);
                }
            }

            // 输出字典序
            Console.WriteLine("Alphabet");
            foreach (int i in stDictionary.Keys())
            {
                string s = stDictionary.Get(i);
                Console.WriteLine(s + "\t" + stFrequency.Get(s));
            }

            // 频率序
            Console.WriteLine("Frequency");
            int n = stFrequency.Size();
            for (int i = 0; i < n; i++)
            {
                string max = "";
                stFrequency.Put(max, 0);
                foreach (string s in stFrequency.Keys())
                    if (stFrequency.Get(s) > stFrequency.Get(max))
                        max = s;
                Console.WriteLine(max + "\t" + stFrequency.Get(max));
                stFrequency.Delete(max);
            }
        }

        /// <summary>
        /// 获得指定键中出现频率最高的键。
        /// </summary>
        /// <typeparam name="TKey">键类型。</typeparam>
        /// <param name="st">用于计算的符号表。</param>
        /// <param name="keys">所有的键。</param>
        /// <returns><paramref name="keys"/> 中出现频率最高的键。</returns>
        public static TKey MostFrequentlyKey<TKey>(IST<TKey, int> st, TKey[] keys)
        {
            foreach (TKey s in keys)
            {
                if (st.Contains(s))
                    st.Put(s, st.Get(s) + 1);
                else
                    st.Put(s, 1);
            }

            TKey max = keys[0];
            foreach (TKey s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串。</returns>
        public static string MostFrequentlyWord(string filename, int minLength, IST<string, int> st)
        {
            int distinct = 0, words = 0;
            StreamReader sr = new StreamReader(File.OpenRead(filename));

            string[] inputs = 
                sr
                .ReadToEnd()
                .Split(new char[] { ' ', '\r', '\n' }, 
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in inputs)
            {
                if (s.Length < minLength)
                    continue;
                words++;
                if (st.Contains(s))
                {
                    st.Put(s, st.Get(s) + 1);
                }
                else
                {
                    st.Put(s, 1);
                    distinct++;
                }
            }

            string max = "";
            st.Put(max, 0);
            foreach (string s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="counts">从文件读入的单词数目。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串。</returns>
        public static string MostFrequentlyWord(string filename, int counts, int minLength, IST<string, int> st)
        {
            int distinct = 0, words = 0;
            StreamReader sr = new StreamReader(File.OpenRead(filename));

            string[] inputs =
                sr
                .ReadToEnd()
                .Split(new char[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < counts && i < inputs.Length; i++)
            {
                if (inputs[i].Length < minLength)
                {
                    counts++;
                    continue;
                }
                words++;
                if (st.Contains(inputs[i]))
                {
                    st.Put(inputs[i], st.Get(inputs[i]) + 1);
                }
                else
                {
                    st.Put(inputs[i], 1);
                    distinct++;
                }
            }

            string max = "";
            st.Put(max, 0);
            foreach (string s in st.Keys())
                if (st.Get(s) > st.Get(max))
                    max = s;

            return max;
        }

        /// <summary>
        /// 获得指定文本文档中出现频率最高的所有字符串。
        /// </summary>
        /// <param name="filename">文件名。</param>
        /// <param name="minLength">字符串最小长度。</param>
        /// <param name="st">用于计算的符号表。</param>
        /// <returns>文本文档出现频率最高的字符串数组。</returns>
        public static string[] MostFrequentlyWords(string filename, int minLength, IST<string, int> st)
        {
            int distinct = 0, words = 0;
            StreamReader sr = new StreamReader(File.OpenRead(filename));

            string[] inputs =
                sr
                .ReadToEnd()
                .Split(new char[] { ' ', '\r', '\n' },
                StringSplitOptions.RemoveEmptyEntries);

            foreach (string s in inputs)
            {
                if (s.Length < minLength)
                    continue;
                words++;
                if (st.Contains(s))
                {
                    st.Put(s, st.Get(s) + 1);
                }
                else
                {
                    st.Put(s, 1);
                    distinct++;
                }
            }

            string max = "";
            Queue<string> queue = new Queue<string>();
            st.Put(max, 0);
            foreach (string s in st.Keys())
            {
                if (st.Get(s) > st.Get(max))
                {
                    max = s;
                    queue.Clear();
                    queue.Enqueue(s);
                }
                else if (st.Get(s) == st.Get(max))
                {
                    queue.Enqueue(s);
                }
            }

            return queue.ToArray();
        }
    }
}
