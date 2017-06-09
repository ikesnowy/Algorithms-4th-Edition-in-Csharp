using System;
using System.Windows.Forms;
using System.Drawing;

namespace _1._1._32
{
    /*
     * 1.1.32
     * 
     * 直方图。
     * 假设标准输入流中含有一系列 double 值。
     * 编写一段程序，从命令行接受一个整数 N 和两个 double 值 l 和 r。
     * 将 (l, r) 分为 N 段并使用 StdDraw 画出输入流中的值落入每段的数量的直方图。
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

        public static void StartDrawing(double[] array, int N, double l, double r)
        {
            //创建并显示绘图窗口
            Form2 DrawPad = new Form2();
            DrawPad.ShowDialog();

            //新建画布
            Graphics graphics = DrawPad.CreateGraphics();

            //翻转默认坐标系
            graphics.ScaleTransform(1, -1);

            //对原始数组排序（以使用二分查找）
            Array.Sort(array);

            //计算各区域的值
            int[] counts = new int[N];
            int index = 0;
            for (int i = 0; i < N; ++i)
            {
                for (int j = index; j < array.Length; ++j)
                {
                    if (array[j] <= (r - l) / N * (i + 1))
                    {
                        counts[i]++;
                        index++;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            //计算直方图的矩形
            Rectangle[] rects = new Rectangle[N];
            for (int i = 0; i < N; ++i)
            {

            }
        }
    }
}
