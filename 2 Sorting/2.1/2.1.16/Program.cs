using System;

namespace _2._1._16
{
    /*
     * 2.1.16
     * 
     * 验证。
     * 编写一个 check() 方法，
     * 调用 sort() 对任意数组排序。
     * 如果排序成功而且数组中的所有对象均没有被修改则返回 true，
     * 否则返回 false。
     * 不要假设 sort() 只能通过 exch() 来移动数据，
     * 可以信任并使用 Array.sort()。
     * 
     */
    public class Program
    {
        static void Main(string[] args)
        {
            string[] test = new string[5] { "a", "b", "d", "c", "e" };
            Console.WriteLine(CheckArraySort(test));
            Console.WriteLine(CheckSelectionSort(test));
        }

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
