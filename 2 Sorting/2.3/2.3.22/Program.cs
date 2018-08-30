using System;
using Quick;

namespace _2._3._22
{
    /*
     * 2.3.22
     * 
     * 快速三向切分。（J.Bently，D.McIlroy）
     * 用将重复元素放置于子数组两端的方式实现一个信息量最优的排序算法。
     * 使用两个索引 p 和 q，使得 a[lo...p-1] 和 a[q+1..hi] 的元素都和 a[lo] 相等。
     * 使用另外两个索引 i 和 j，
     * 使得 a[p...i-1] 小于 a[lo]，a[j+i..q] 大于 a[lo]。
     * 在内循环中加入代码，在 a[i] 和 v 相当时将其与 a[p] 交换（并将 p 加 1），
     * 在 a[j] 和 v 相等且 a[i] 和 a[j] 尚未和 v 进行比较之前将其与 a[q] 交换。
     * 添加在切分循环结束后将和 v 相等的元素交换到正确位置的代码，如图 2.3.6 所示。
     * 请注意：
     * 这里实现的代码和正文中给出的代码时等价的，
     * 因为这里额外的交换用于和切分元素相等的元素，
     * 而正文中的代码将额外的交换用于和切分元素不等的元素。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort quickNormal = new QuickSort();
            QuickBentleyMcIlroy quickBentleyMcIlroy = new QuickBentleyMcIlroy();
            int arraySize = 800000;                         // 初始数组大小。
            const int trialTimes = 1;                       // 每次实验的重复次数。
            const int trialLevel = 8;                       // 双倍递增的次数。

            Console.WriteLine("n\t\t3way\tnormal\tratio");
            for (int i = 0; i < trialLevel; i++)
            {
                double timeBentleyMcIlroy = 0;
                double timeNormal = 0;
                for (int j = 0; j < trialTimes; j++)
                {
                    int[] a = SortCompare.GetRandomArrayInt(arraySize);
                    int[] b = new int[a.Length];
                    a.CopyTo(b, 0);
                    timeNormal += SortCompare.Time(quickNormal, b);
                    timeBentleyMcIlroy += SortCompare.Time(quickBentleyMcIlroy, a);

                }
                timeBentleyMcIlroy /= trialTimes;
                timeNormal /= trialTimes;
                if (arraySize < 10000000)
                    Console.WriteLine(arraySize + "\t\t" + timeBentleyMcIlroy + "\t" + timeNormal + "\t" + timeBentleyMcIlroy / timeNormal);
                else
                    Console.WriteLine(arraySize + "\t" + timeBentleyMcIlroy + "\t" + timeNormal + "\t" + timeBentleyMcIlroy / timeNormal);
                arraySize *= 2;
            }
        }
    }
}
