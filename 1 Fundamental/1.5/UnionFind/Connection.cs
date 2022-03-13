namespace UnionFind;

/// <summary>
/// 表示并查集中的一条连接。
/// </summary>
public class Connection
{
    /// <summary>
    /// 链接起点。
    /// </summary>
    /// <value>链接起点。</value>
    public int P { get; set; }
    /// <summary>
    /// 链接终点。
    /// </summary>
    /// <value>链接终点。</value>
    public int Q { get; set; }

    /// <summary>
    /// 构造一条连接。
    /// </summary>
    /// <param name="p">连接起点。</param>
    /// <param name="q">连接终点。</param>
    public Connection(int p, int q)
    {
        P = p;
        Q = q;
    }
}