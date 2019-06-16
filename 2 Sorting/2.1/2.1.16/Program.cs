using System;

namespace _2._1._16
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[5] { "a", "b", "d", "c", "e" };
            Console.WriteLine(CheckArraySort(test));
            Console.WriteLine(CheckSelectionSort(test));
        }

        /// <summary>
        /// 测试 Array.Sort() 方法。
        /// </summary>
        /// <param name="a">用于测试的数组。</param>
        /// <returns>如果数组对象没有改变，返回 true，否则返回 false。</returns>
        static bool CheckArraySort(string[] a)
        {
            string[] backup = new string[a.Length];
            a.CopyTo(backup, 0);

            Array.Sort(a);

            foreach (string n in a)
            {
                bool isFind = false;
                for (int i = 0; i < a.Length; i++)
                {
                    if (ReferenceEquals(n, backup[i]))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 测试选择排序。
        /// </summary>
        /// <param name="a">用于测试的数组。</param>
        /// <returns>如果数组对象没有改变，返回 true，否则返回 false。</returns>
        static bool CheckSelectionSort(string[] a)
        {
            string[] backup = new string[a.Length];
            a.CopyTo(backup, 0);

            SelectionSort(a);

            foreach (string n in a)
            {
                bool isFind = false;
                for (int i = 0; i < a.Length; i++)
                {
                    if (ReferenceEquals(n, backup[i]))
                    {
                        isFind = true;
                        break;
                    }
                }
                if (!isFind)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 选择排序，其中的交换部分使用新建对象并复制的方法。
        /// </summary>
        /// <param name="s">用于排序的数组。</param>
        public static void SelectionSort(string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                int min = i;
                for (int j = i + 1; j < s.Length; j++)
                {
                    if (s[j].CompareTo(s[min]) < 0)
                    {
                        min = j;
                    }
                }
                string temp = new string(s[i].ToCharArray());
                s[i] = s[min];
                s[min] = temp;
            }
        }
    }
}
