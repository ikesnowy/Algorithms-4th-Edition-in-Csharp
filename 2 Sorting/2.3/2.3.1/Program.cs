namespace _2._3._1
{
    /*
     * 2.3.1
     * 
     * 按照 Partition() 方法的轨迹的格式给出该方法是如何切分数组 
     * E A S Y Q U E S T I O N 的。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            //                           a[]
            //  i   j  0  1  2  3  4  5  6  7  8  9  10  11
            //  0  16  E  A  S  Y  Q  U  E  S  T  I   O   N
            //  1   6  E  A  S  Y  Q  U  E  S  T  I   O   N
            //  1   6  E  A  E  Y  Q  U  S  S  T  I   O   N
            //  3   2  E  A  E  Y  Q  U  S  S  T  I   O   N
            //  3   2  E  A  E  Y  Q  U  S  S  T  I   O   N
            //      2  E  A  E  Y  Q  U  S  S  T  I   O   N
        }
    }
}
