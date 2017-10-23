using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;

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

        /// <summary>
        /// 主绘图函数。
        /// </summary>
        /// <param name="array">输入的 double 数组。</param>
        /// <param name="N">分割的段数。</param>
        /// <param name="l">直方图 x 轴范围的下界。</param>
        /// <param name="r">直方图 x 轴范围的上界。</param>
        public static void StartDrawing(double[] array, int N, double l, double r)
        {
            // 创建并显示绘图窗口
            Form2 DrawPad = new Form2();
            DrawPad.Show();

            // 新建画布
            Graphics graphics = DrawPad.CreateGraphics();
            
            // 翻转默认坐标系
            graphics.TranslateTransform(0, DrawPad.Height);
            graphics.ScaleTransform(1, -1);

            // 对原始数组排序
            Array.Sort(array);

            // 计算各区域的值
            int[] counts = new int[N];
            int index = 0;
            for (int i = 0; i < N; ++i)
            {
                for (int j = index; j < array.Length; ++j)
                {
                    if (array[j] <= (r - l) * (i + 1) / N)
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

            // 获取最大值
            double max = counts.Max();
            // 计算间距
            double unit = DrawPad.Width / (3.0 * N + 1);
            // 计算直方图的矩形
            Rectangle[] rects = new Rectangle[N];
            rects[0].X = (int)unit;
            rects[0].Y = 0;
            rects[0].Width = (int)(2 * unit);
            rects[0].Height = (int)((counts[0] / max) * DrawPad.Height);
            for (int i = 1; i < N; ++i)
            {
                rects[i].X = (int)(rects[i - 1].X + 3 * unit);
                rects[i].Y = 0;
                rects[i].Width = (int)(2 * unit);
                rects[i].Height = (int)((counts[i] / (max + 1)) * DrawPad.Height);
            }

            // 绘图
            graphics.FillRectangles(Brushes.Black, rects);

            // 释放资源
            graphics.Dispose();
        }
    }
}
