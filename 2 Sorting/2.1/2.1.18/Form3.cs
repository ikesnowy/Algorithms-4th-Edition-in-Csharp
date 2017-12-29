using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;

namespace _2._1._18
{
    public partial class Form3 : Form
    {
        double[] randomDoubles;
        int sortI;
        int sortJ;
        int n = 0;
        public Form3(int N)
        {
            InitializeComponent();
            this.randomDoubles = new double[N];
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                this.randomDoubles[i] = random.NextDouble() * 0.8 + 0.2;
            }
        }

        private void InsertionSort()
        {
            for (this.sortI = 0; this.sortI < this.randomDoubles.Length; this.sortI++)
            {
                for (this.sortJ = this.sortI; this.sortJ > 0 && this.randomDoubles[this.sortJ] < this.randomDoubles[this.sortJ - 1]; this.sortJ--)
                {
                    double temp = this.randomDoubles[this.sortJ];
                    this.randomDoubles[this.sortJ] = this.randomDoubles[this.sortJ - 1];
                    this.randomDoubles[this.sortJ - 1] = temp;
                }
                drawPanel();
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
                if (i == this.sortJ)
                {
                    graphics.FillRectangle(Brushes.Red, bars[i]);
                }
                else if (i <= this.sortI && i > this.sortJ)
                {
                    graphics.FillRectangle(Brushes.Black, bars[i]);
                }
                else
                {
                    graphics.FillRectangle(Brushes.Gray, bars[i]);
                }
            }
            Bitmap bitmap = Image.FromHbitmap(graphics.GetHdc());
            bitmap.Save(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "screenshot" + this.n + ".bmp", ImageFormat.Bmp);
            this.n++;
            graphics.Dispose();
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            InsertionSort();
        }
    }
}
