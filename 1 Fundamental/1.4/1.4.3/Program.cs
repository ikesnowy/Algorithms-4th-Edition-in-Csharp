﻿using System;
using System.Windows.Forms;
using System.Drawing;
using Measurement;

namespace _1._4._3
{
    
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

        public static double[] Test()
        {
            double[] result = new double[4];
            int i = 0;
            for (int n = 1000; i < 4; n += n)
            {
                result[i] = DoubleTest.TimeTrial(n);
                i++;
            }
            return result;
        }

        public static void PaintLinear(double[] testResult)
        {
            // 新建一个绘图窗口
            Form2 linear = new Form2();
            linear.Show();
            // 新建画布
            Graphics canvas = linear.CreateGraphics();
            // 获取窗口区域
            Rectangle rect = linear.ClientRectangle;
            // 计算单位长度（十等分）
            int unitY = rect.Height / 10;
            int unitX = rect.Width / 10;
            // 获取中心区域（上下左右增加 10% 的内补）
            Rectangle center = new Rectangle(rect.X + unitX, rect.Y + unitY, unitX * 8, unitY * 8);
            // 绘制坐标系
            canvas.DrawLine(Pens.Black, center.X, center.Y, center.X, center.Y + center.Height);
            canvas.DrawLine(Pens.Black, center.X, center.Y + center.Height, center.X + center.Width, center.Y + center.Height);
            // 对 X 轴 10 等分，对 Y 轴 10 等分
            int xaxisUnit = center.Width / 10;
            int yaxisUnit = center.Height / 10;
            // 标记 X 轴坐标值
            for (int i = 1; i <= 8; i += i)
            {
                canvas.DrawString(i + "N", linear.Font, Brushes.Black, center.X + i * xaxisUnit, center.Y + center.Height);
            }
            // 反转坐标系
            canvas.TranslateTransform(0, linear.ClientRectangle.Height);
            canvas.ScaleTransform(1, -1);
            // 计算单位长度
            double Unit = center.Height / testResult[3];
            // 标记
            PointF[] result = new PointF[4];
            for (int i = 0, j = 1; i < 4 && j <= 8; i++, j += j)
            {
                result[i] = new PointF(center.X + j * xaxisUnit, (float)(center.Y + Unit * testResult[i]));
            }
            // 链接
            canvas.DrawLines(Pens.Black, result);

            canvas.Dispose();
        }

        public static void PaintLogarithm(double[] testResult)
        {
            // 新建一个绘图窗口
            Form2 log = new Form2();
            log.Show();
            // 新建画布
            Graphics canvas = log.CreateGraphics();
            // 获取窗口区域
            Rectangle rect = log.ClientRectangle;
            // 计算单位长度（十等分）
            int unitY = rect.Height / 10;
            int unitX = rect.Width / 10;
            // 获取中心区域（上下左右增加 10% 的内补）
            Rectangle center = new Rectangle(rect.X + unitX, rect.Y + unitY, unitX * 8, unitY * 8);
            // 绘制坐标系
            canvas.DrawLine(Pens.Black, center.X, center.Y, center.X, center.Y + center.Height);
            canvas.DrawLine(Pens.Black, center.X, center.Y + center.Height, center.X + center.Width, center.Y + center.Height);
            // 对 X 轴 10 等分，对 Y 轴 10 等分
            int xaxisUnit = center.Width / 10;
            int yaxisUnit = center.Height / 10;
            // 标记 X 轴坐标值
            for (int i = 1; i <= 8; i += i)
            {
                canvas.DrawString(i + "N", log.Font, Brushes.Black, center.X + i * xaxisUnit, center.Y + center.Height);
            }
            // 反转坐标系
            canvas.TranslateTransform(0, log.ClientRectangle.Height);
            canvas.ScaleTransform(1, -1);
            // 计算单位长度
            double Unit = center.Height / testResult[3];
            // 标记
            PointF[] result = new PointF[4];
            for (int i = 0, j = 1; i < 4 && j <= 8; i++, j += j)
            {
                result[i] = new PointF(center.X + j * xaxisUnit, (float)(center.Y + Unit * testResult[i]));
            }
            // 链接
            canvas.DrawLines(Pens.Black, result);
            canvas.Dispose();
        }
    }
}
