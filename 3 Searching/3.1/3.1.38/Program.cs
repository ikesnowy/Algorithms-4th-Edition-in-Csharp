using System;
using System.Windows.Forms;

namespace _3._1._38
{
    /*
     * 3.1.38
     * 
     * 均摊成本图。
     * 修改 FrequencyCounter 、SequentialSearchST 和 BinarySearchST，
     * 统计计算中每次 put() 操作的成本并生成类似本节所示的图。
     * 
     */
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }   
    }
}
