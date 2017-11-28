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

namespace _2._1._18
{
    public partial class Form2 : Form
    {
        double[] randomDoubles;
        int sortI;
        int sortJ;
        int sortMin;
        public Form2(int N)
        {
            InitializeComponent();
            this.randomDoubles = new double[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                this.randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
        }

        private void SelectionSort()
        {
            for (this.sortI = 0; this.sortI < this.randomDoubles.Length; this.sortI++)
            {
                this.sortMin = this.sortI;
                for (this.sortJ = this.sortI; this.sortJ < this.randomDoubles.Length; this.sortJ++)
                {
                    if (this.randomDoubles[this.sortMin] > this.randomDoubles[this.sortJ])
                    {
                        this.sortMin = this.sortJ;
                    }
                }
                drawPanel();
                double temp = this.randomDoubles[this.sortI];
                this.randomDoubles[this.sortI] = this.randomDoubles[this.sortMin];
                this.randomDoubles[this.sortMin] = temp;
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

            for (int i = 0; i < bars.Length; i++)
            {
                if (i == this.sortMin)
                {
                    graphics.FillRectangle(Brushes.Red, bars[i]);
                }
                else if (i < this.sortI)
                {
                    graphics.FillRectangle(Brushes.Gray, bars[i]);
                }
                else
                {
                    graphics.FillRectangle(Brushes.Black, bars[i]);
                }
            }
            graphics.Dispose();
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            SelectionSort();
        }
    }
}
