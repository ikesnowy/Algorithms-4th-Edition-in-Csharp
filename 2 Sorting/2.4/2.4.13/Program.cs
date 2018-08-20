namespace _2._4._13
{
    /*
     * 2.4.13
     * 
     * 想办法在 sink() 中避免检查 j<N。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 在官方实现的基础上直接删去 j<n 的语句即可。
            // 在 DelMax 方法中，
            // 最大元素先被放到了最后，然后 n 减小 1
            // 这一步保证了 pq[n] <= pq[n+1]
            // 然后执行 Sink 方法，
            // 此时若 j = n，则有 pq[j] <= pq[j+1]。
            // 因此不需要进行边界检查。
        }
    }
}
