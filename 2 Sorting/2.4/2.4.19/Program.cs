namespace _2._4._19
{
    /*
     * 2.4.19
     * 
     * 实现 MaxPQ 的一个构造函数，接受一个数组作为参数。
     * 使用正文 2.4.5.1 节中所述的自底向上的方法构造堆。
     * 
     */

    class Program
    {
        static void Main(string[] args)
        {
            // 官方实现中已经包含。
            // public MaxPQ(Key[] keys)
            // {
            //     this.n = keys.Length;
            //     this.pq = new Key[keys.Length + 1];
            //     for (int i = 0; i < keys.Length; i++)
            //         this.pq[i + 1] = keys[i];
            //     for (int k = this.n / 2; k >= 1; k--)
            //         Sink(k);
            //     Debug.Assert(IsMaxHeap());
            // }
        }
    }
}
