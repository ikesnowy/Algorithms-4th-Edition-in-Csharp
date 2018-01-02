namespace _2._1._19
{
    class ShellSortWorstCase
    {
        /// <summary>
        /// 获得最坏情况的数组。
        /// </summary>
        /// <param name="n">数组大小。</param>
        /// <returns>希尔排序最坏情况的数组。</returns>
        public static int[] GetWorst(int n)
        {
            int l = 0;
            int?[] a = new int?[n + 1];

            for (int i = 0; i < a.Length; i++)
            {
                a[i] = null;
            }
            int P = 40;
            int PAddition = P;
            for (int i = 0; l < 100; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (a[j] == null && IsVisible(j, P))
                    {
                        l++;
                        a[j] = l;
                    }
                }
                P += PAddition;
            }

            int[] b = new int[n];
            for (int i = 0; i < n; i++)
            {
                b[i] = (int)a[i + 1];
            }

            return b;
        }

        /// <summary>
        /// 确认 j - i 是不是在排序样板（Sorting Template）上。
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public static bool IsVisible(int i, int j)
        {
            int k = 0;
            while (k <= 100)
            {
                if (j - i >= k * 40 && j - i <= k * 41)
                    return true;
                k++;
            }
            return false;
        }
    }
}
