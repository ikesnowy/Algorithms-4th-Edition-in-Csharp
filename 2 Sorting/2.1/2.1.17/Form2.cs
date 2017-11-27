using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                this.randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
            drawPanel();

            this.timer1.Interval = 60;
            this.timer1.Start();

            Thread thread = new Thread(new ThreadStart(SelectionSort));
            thread.IsBackground = true;
            thread.Start();
        }

        private void SelectionSort()
        {
            for (int i = 0; i < this.randomDoubles.Length; i++)
            {
                int min = i;
                for (int j = i; j < this.randomDoubles.Length; j++)
                {
                    if (this.randomDoubles[min] > this.randomDoubles[j])
                    {
                        min = j;
                    }
                }
                double temp = this.randomDoubles[i];
                this.randomDoubles[i] = this.randomDoubles[min];
                this.randomDoubles[min] = temp;
                Thread.Sleep(1000);
            }
        }

        private void drawPanel()
        {
            Graphics graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            graphics.TranslateTransform(0, this.Height);
            graphics.ScaleTransform(1, -1);
            Rectangle clientRect = this.ClientRectangle;
            Rectangle drawRect = new Rectangle(clientRect.X + 10, clientRect.Y + 10, clientRect.Width - 10, clientRect.Height - 10);

            PointF[] barX = new PointF[this.randomDoubles.Length];
            float unitX = (float)drawRect.Width / this.randomDoubles.Length;
            unitX -= 4;

            barX[0] = new PointF(4, drawRect.Top);
            for (int i = 1; i < this.randomDoubles.Length; i++)
            {
                barX[i] = new PointF(2 + unitX + barX[i - 1].X, drawRect.Top);
            }

            RectangleF[] bars = new RectangleF[this.randomDoubles.Length];
            for (int i = 0; i < this.randomDoubles.Length; i++)
            {
                SizeF size = new SizeF(unitX, (float)this.randomDoubles[i] * drawRect.Height);
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
