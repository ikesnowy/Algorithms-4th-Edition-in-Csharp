using SymbolTable;

namespace _3._1._26
{
    /*
     * 3.1.26
     * 
     * 基于字典的频率统计。
     * 修改 FrequencyCounter，接受一个字典文件作为参数，
     * 统计标准输入中出现在字典中的单词的频率，并将单词和频率打印为两张表格，
     * 一张按照频率高低排序，一张按照字典顺序排序。
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            FrequencyCounter.LookUpDictionary("tale.txt", "web2.txt", 13);
        }
    }
}
