using System;
using System.Diagnostics;
using SymbolTable;

namespace _3._1._33
{
    /*
     * 3.1.33
     * 
     * 自组织查找。
     * 编写一段程序调用自组织查找的实现（请见练习 3.1.22），
     * 用 put() 构造一个大小为 N 的符号表，
     * 然后根据预先定义好的概率分布进行 10N 次命中查找。
     * 对于 N = 10^3、10^4、10^5 和 10^6，
     * 用这段程序比较你在练习 3.1.22 中的实现和 BinarySearchST 的运行时间，
     * 在预定义的概率分布中查找命中第 i 小的键的概率为 1/2^i。
     * 
     */
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            int n = 1000;
            int multiplyBy10 = 4;
            for (int i = 0; i < multiplyBy10; i++)
            {
                Console.WriteLine("n=" + n);
                // 构造表
                BinarySearchST<string, int> bst = new BinarySearchST<string, int>(n);
                MoveToFrontArrayST<string, int> mst = new MoveToFrontArrayST<string, int>(n);
                string[] keys = SearchCompare.GetRandomArrayString(n, 3, 20);
                for (int j = 0; j < n; j++)
                {
                    bst.Put(keys[j], j);
                    mst.Put(keys[j], j);
                }
                // 构造查询
                Array.Sort(keys);
                string[] querys = new string[10 * n];
                int queryIndex = 0, keyIndex = 0;
                while (queryIndex < querys.Length)
                {
                    int searchTimes = (int)Math.Ceiling((Math.Pow(0.5, keyIndex + 1) * querys.Length));
                    
                    for (int j = 0; j < searchTimes && queryIndex < querys.Length; j++)
                    {
                        querys[queryIndex++] = keys[keyIndex];
                    }
                    keyIndex++;
                }
                Shuffle(querys);

                Stopwatch sw = new Stopwatch();
                // 测试 MoveToFrontArrayST
                sw.Start();
                for (int j = 0; j < querys.Length; j++)
                {
                    mst.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("MoveToFrontArrayST: " + sw.ElapsedMilliseconds);

                // 测试 BinarySearchST
                sw.Restart();
                for (int j = 0; j < querys.Length; j++)
                {
                    bst.Get(querys[j]);
                }
                sw.Stop();
                Console.WriteLine("BinarySearchST: " + sw.ElapsedMilliseconds);

                n *= 10;
            }
        }

        static void Shuffle<T>(T[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                int r = i + random.Next(data.Length - i);
                T temp = data[r];
                data[r] = data[i];
                data[i] = temp;
            }
        }
    }
}
