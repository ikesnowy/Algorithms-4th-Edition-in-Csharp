﻿using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._17
{
    public partial class Form3 : Form
    {
        double[] randomDoubles;
        public Form3(int N)
        {
            InitializeComponent();
            randomDoubles = new double[N];
            var random = new Random();
            for (var i = 0; i < N; i++)
            {
                randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
            drawPanel();

            timer1.Interval = 60;
            timer1.Start();

            var thread = new Thread(new ThreadStart(InsertionSort));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 插入排序。
        /// </summary>
        private void InsertionSort()
        {
            for (var i = 0; i < randomDoubles.Length; i++)
            {
                for (var j = i; j > 0 && randomDoubles[j] < randomDoubles[j - 1]; j--)
                {
                    var temp = randomDoubles[j];
                    randomDoubles[j] = randomDoubles[j - 1];
                    randomDoubles[j - 1] = temp;
                    Thread.Sleep(500);
                }
            }
        }

        /// <summary>
        /// 在屏幕上用柱形图绘制数组。
        /// </summary>
        private void drawPanel()
        {
            var graphics = CreateGraphics();
            graphics.Clear(BackColor);
            graphics.TranslateTransform(0, Height);
            graphics.ScaleTransform(1, -1);
            var clientRect = ClientRectangle;
            var drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);

            var barX = new PointF[randomDoubles.Length];
            var unitX = (float)drawRect.Width / randomDoubles.Length;
            unitX -= 4;

            barX[0] = new PointF(4, drawRect.Top);
            for (var i = 1; i < randomDoubles.Length; i++)
            {
                barX[i] = new PointF(2 + unitX + barX[i - 1].X, drawRect.Top);
            }

            var bars = new RectangleF[randomDoubles.Length];
            for (var i = 0; i < randomDoubles.Length; i++)
            {
                var size = new SizeF(unitX, (float)randomDoubles[i] * drawRect.Height);
                bars[i] = new RectangleF(barX[i], size);
            }

            graphics.FillRectangles(Brushes.Black, bars);
            graphics.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawPanel();
        }
    }
}
