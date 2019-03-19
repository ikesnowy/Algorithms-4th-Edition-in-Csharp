using System;
using System.Windows.Forms;

namespace _3._1._39
{
    /*
     * 3.1.39
     * 
     * 实际耗时。
     * 修改 FrequencyCounter，
     * 用 Stopwatch 和 StdDraw 绘图，
     * 其中 x 轴为 get() 和 put() 的调用次数之和，y 轴为总运行时间，
     * 每次调用时就根据已运行的时间画一个点。
     * 分别用 SequentialSearchST 和 BinarySearchST 处理《双城记》并讨论运行的结果。
     * 注意：曲线中突然的跳跃可能是缓存导致的，这已经超出了这个问题的讨论范围。
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
