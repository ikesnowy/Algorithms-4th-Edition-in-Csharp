namespace _2._1._26
{
    /// <summary>
    /// 插入排序类。
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        /// 默认构造函数。
        /// </summary>
        public InsertionSort() { }

        /// <summary>
        /// 利用插入排序将数组按升序排序。
        /// </summary>
        /// <param name="a">需要排序的数组。</param>
        public void Sort(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = i; j > 0 && a[j] < a[j - 1]; --j)
                {
                    int t = a[j];
                    a[j] = a[j - 1];
                    a[j - 1] = t;
                }
            }
        }
    }
}
