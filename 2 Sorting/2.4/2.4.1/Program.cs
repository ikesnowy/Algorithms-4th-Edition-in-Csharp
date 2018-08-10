namespace _2._4._1
{
    /*
     * 2.4.1
     * 
     * 用序列 P R I O * R * * I * T * Y * * * Q U E * * * U * E 
     * （字母表示插入元素，星号表示删除最大元素）
     * 操作一个初始为空的优先队列。
     * 给出每次删除最大元素返回的字符。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // R R P O T Y I I U Q E U
            //
            // 优先队列变化：
            // P     P
            // R     P R
            // I     P R I
            // O     P R I O
            // *     P I O
            // R     P I O R
            // *     P I O
            // *     I O
            // I     I O I
            // *     I I
            // T     I I T
            // *     I I
            // Y     I I Y
            // *     I I
            // *     I 
            // *     
            // Q     Q
            // U     Q U
            // E     Q U E
            // *     Q E
            // *     E
            // *      
            // U     U
            // *     
            // E     E
        }
    }
}
