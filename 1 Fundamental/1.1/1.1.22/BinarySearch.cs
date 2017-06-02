using System;

namespace _1._1._22
{
    /*
     * 1.1.22
     * 
     * 使用 1.1.6.4 节中的 rank() 递归方法重新实现 BinarySearch 并跟踪该方法的调用。
     * 每当该方法被调用时，打印出它的参数 lo 和 hi 并按照递归的深度缩进。
     * 提示：为递归方法添加一个参数来保存递归的深度。
     * 
     * 
     */
    class BinarySearch
    {
        static void Main(string[] args)
        {
            int[] array = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            rank(9, array);
        }

        //重载方法，用于启动二分查找
        public static int rank(int key, int[] a)
        {
            return rank(key, a, 0, a.Length - 1, 1);
        }

        //二分查找
        public  static int rank(int key, int[] a, int lo, int hi, int number)
        {

            for (int i = 0; i < number; ++i)
            {
                Console.Write(" ");
            }
            Console.WriteLine($"{number}: {lo} {hi}");

            if (lo > hi)
            {
                return -1;
            }

            int mid = lo + (hi - lo) / 2;

            if (key < a[mid])
            {
                return rank(key, a, lo, mid - 1, number + 1);
            }
            else if (key > a[mid])
            {
                return rank(key, a, mid + 1, hi, number + 1);
            }
            else
            {
                return mid;
            }
        }
    }
}