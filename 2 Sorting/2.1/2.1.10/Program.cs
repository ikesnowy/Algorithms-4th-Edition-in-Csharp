namespace _2._1._10
{
    /*
     * 2.1.10
     * 
     * 在希尔排序中为什么在实现 h 有序时不使用选择排序？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 因为对于部分有序的数组，插入排序比选择排序快。
            // 这个结论可以在中文版 P158， 英文版 P252 找到。
        }
    }
}
