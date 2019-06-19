using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._17
{
    public partial class Form2 : Form
    {
        double[] randomDoubles;
        public Form2(int N)
        {
            InitializeComponent();
            this.randomDoubles = new double[N];
            var random = new Random();
            for (var i = 0; i < N; i++)
            {
                this.randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
            drawPanel();

            this.timer1.Interval = 60;
            this.timer1.Start();

            var thread = new Thread(new ThreadStart(this.SelectionSort));
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 选择排序。
        /// </summary>
        private void SelectionSort()
        {
            for (var i = 0; i < this.randomDoubles.Length; i++)
            {
                var min = i;
                for (var j = i; j < this.randomDoubles.Length; j++)
                {
                    if (this.randomDoubles[min] > this.randomDoubles[j])
                    {
                        min = j;
                    }
                }
                var temp = this.randomDoubles[i];
                this.randomDoubles[i] = this.randomDoubles[min];
                this.randomDoubles[min] = temp;
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// 在屏幕上用柱形图绘制数组。
        /// </summary>
        private void drawPanel()
        {
            var graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            graphics.TranslateTransform(0, this.Height);
            graphics.ScaleTransform(1, -1);
            var clientRect = this.ClientRectangle;
            var drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);

            var barX = new PointF[this.randomDoubles.Length];
            var unitX = (float)drawRect.Width / this.randomDoubles.Length;
            unitX -= 4;

            barX[0] = new PointF(4, drawRect.Top);
            for (var i = 1; i < this.randomDoubles.Length; i++)
            {
                barX[i] = new PointF(2 + unitX + barX[i - 1].X, drawRect.Top);
            }

            var bars = new RectangleF[this.randomDoubles.Length];
            for (var i = 0; i < this.randomDoubles.Length; i++)
            {
                var size = new SizeF(unitX, (float)this.randomDoubles[i] * drawRect.Height);
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
