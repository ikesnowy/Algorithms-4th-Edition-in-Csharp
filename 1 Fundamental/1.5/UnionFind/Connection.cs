namespace UnionFind
{
    /// <summary>
    /// 表示并查集中的一条连接。
    /// </summary>
    public class Connection
    {
        public int P { get; set; }      // 连接起点。
        public int Q { get; set; }      // 连接终点。

        /// <summary>
        /// 构造一条连接。
        /// </summary>
        /// <param name="p">连接起点。</param>
        /// <param name="q">连接终点。</param>
        public Connection(int p, int q)
        {
            this.P = p;
            this.Q = q;
        }
    }
}
