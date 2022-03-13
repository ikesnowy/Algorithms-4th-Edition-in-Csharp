using System;

namespace Measurement;

/// <summary>
/// 用暴力方法查找数组中和为零的二元组。
/// </summary>
public static class TwoSum
{
    /// <summary>
    /// 打印出数组中所有和为零的整数对。
    /// </summary>
    /// <param name="a">查找范围。</param>
    public static void PrintAll(int[] a)
    {
        var n = a.Length;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (a[i] + a[j] == 0)
                {
                    Console.WriteLine(a[i] + " " + a[j]);
                }
            }
        }
    }

    /// <summary>
    /// 计算数组中和为零的整数对数量。
    /// </summary>
    /// <param name="a">查找范围。</param>
    /// <returns>数组中和为零的整数对数量。</returns>
    public static int Count(int[] a)
    {
        var n = a.Length;
        var count = 0;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + 1; j < n; j++)
            {
                if (a[i] + a[j] == 0)
                {
                    count++;
                }
            }
        }
        return count;
    }
}