namespace _3._1._10
{
    /*
     * 3.1.10
     * 
     * 给出用 SequentialSearchST 将键 
     * E A S Y Q U E S T I O N 插入一个空符号表的过程的轨迹。
     * 一共进行了多少次比较？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // k v  list                                    compare
            // E 0  E0                                      1
            // A 1  A1 E0                                   2
            // S 2  S2 A1 E0                                3
            // Y 3  Y3 S2 A1 E0                             4
            // Q 4  Q4 Y3 S2 A1 E0                          5
            // U 5  U5 Q4 Y3 S2 A1 E0                       6
            // E 6  U5 Q4 Y3 S2 A1 E6                       6
            // S 7  U5 Q4 Y3 S7 A1 E6                       4
            // T 8  T8 U5 Q4 Y3 S7 A1 E6                    7
            // I 9  I9 T8 U5 Q4 Y3 S7 A1 E6                 8
            // O 10 O10 I9 T8 U5 Q4 Y3 S7 A1 E6             9
            // N 11 N11 O10 I9 T8 U5 Q4 Y3 S7 A1 E6         10
            // 
            // 共比较 65 次。
        }
    }
}
