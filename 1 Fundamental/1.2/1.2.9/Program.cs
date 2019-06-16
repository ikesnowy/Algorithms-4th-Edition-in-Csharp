using System;
using System.IO;

namespace _1._2._9
{
    class Program
    {
        // 参考 1.1.10 节的代码
        static void Main(string[] args)
        {
            Counter count = new Counter("BinarySearch");

            // 读取白名单
            string[] whiteListString = File.ReadAllLines("tinyW.txt");
            int[] whiteList = new int[whiteListString.Length];
            
            for (int i = 0; i < whiteListString.Length; i++)
            {
                whiteList[i] = int.Parse(whiteListString[i]);
            }
            Array.Sort(whiteList);

            // 读取查询值
            string[] inputListString = File.ReadAllLines("tinyT.txt");
            int[] inputList = new int[inputListString.Length];

            for (int i = 0; i < inputListString.Length; i++)
            {
                inputList[i] = int.Parse(inputListString[i]);
            }

            // 对每一个查询值进行二分查找
            foreach (int n in inputList)
            {
                int result = rank(n, whiteList, count);
                // 将不在白名单上的数据输出
                if (result == -1)
                {
                    Console.WriteLine(n);
                }
            }
            Console.WriteLine();

            // 输出查询数目
            Console.WriteLine(count.Tally());
        }

        static int rank(int key, int[] a, Counter count)
        {
            int lo = 0;
            int hi = a.Length - 1;
            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                count.Increment();
                if (key < a[mid])
                {
                    hi = mid - 1;
                }
                else if (key > a[mid])
                {
                    lo = mid + 1;
                }
                else
                {
                    return mid;
                }
            }
            return -1;
        }
    }
}
