using System;

namespace _2._5._15
{
    /*
     * 2.5.15
     * 
     * 垃圾邮件大战。
     * 在非法垃圾邮件之战的伊始，
     * 你有一大串来自各个域名（也就是电子邮件地址中@符号后面的部分）的电子邮件地址。
     * 为了更好的伪造回信地址，你应该总是从相同的域中向目标用户发送邮件。
     * 例如，从 wayne@cs.princeton.edu 向 rs@cs.princeton.edu 发送垃圾邮件就很不错。
     * 你会如何处理这份电子邮件列表来高效的完成这个任务呢？
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
            // 利用上一题的逆域名排序，将相同的域名放在一起。
            Domain[] emails = new Domain[5];
            emails[0] = new Domain("wayne@cs.princeton.edu");
            emails[1] = new Domain("windy@apple.com");
            emails[2] = new Domain("rs@cs.princeton.edu");
            emails[3] = new Domain("ike@ee.princeton.edu");
            emails[4] = new Domain("admin@princeton.edu");
            Array.Sort(emails);
            for (int i = 0; i < emails.Length; i++)
            {
                Console.WriteLine(emails[i]);
            }
        }
    }
}
