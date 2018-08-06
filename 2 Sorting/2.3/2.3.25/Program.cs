using System;
using System.Windows.Forms;

namespace _2._3._25
{
    /*
     * 2.3.25
     * 
     * 切换到插入排序。
     * 实现一个快速排序，在子数组元素少于 M 时切换到插入排序。
     * 用快速排序处理大小 N 分别为 10^3、10^4、10^5 和 10^6 的随机数组，
     * 根据经验给出使其在你的环境中运行速度最快的 M 值。
     * 将 M 从 0 变化到 30 的每个值所得到的平均运行时间绘成曲线。
     * 注意：
     * 你需要为算法 2.2 添加一个需要三个参数的 sort() 方法
     * 以使 Insertion.sort(a, lo, hi) 将子数组 a[lo...hi] 排序。
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
