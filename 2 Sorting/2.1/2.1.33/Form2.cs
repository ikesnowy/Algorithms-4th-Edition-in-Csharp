using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sort;

namespace _2._1._33
{
    public partial class Form2 : Form
    {
        List<double> resultList;
        List<float> resultYList;
        Rectangle clientRect;
        Rectangle drawRect;

        BaseSort sort;
        int n;

        public Form2(BaseSort sort, int n)
        {
            InitializeComponent();
            this.resultList = new List<double>();
            this.resultYList = new List<float>();
            this.clientRect = this.ClientRectangle;
            this.drawRect = new Rectangle(this.clientRect.X + 10, this.clientRect.Y + 10, this.clientRect.Width - 10, this.clientRect.Height - 10);
            this.sort = sort;
            this.n = n;
            this.timer1.Interval = 500;
            this.timer1.Start();
        }

        public void Test()
        {
            Random random = new Random();
            double[] array = SortCompare.GetRandomArrayDouble(this.n);
            double time = SortCompare.Time(this.sort, array);
            this.resultList.Add(time);
            this.resultYList.Add((float)(random.NextDouble() * this.drawRect.Height));
            DrawPanel(this.resultList.ToArray(), this.resultYList.ToArray());
        }

        public void DrawPanel(double[] result, float[] resultY)
        {
            Graphics graphics = this.CreateGraphics();
            graphics.Clear(this.BackColor);
            graphics.TranslateTransform(0, this.ClientRectangle.Height);
            graphics.ScaleTransform(1, -1);

            PointF[] dataPoints = new PointF[result.Length];
            float unitX = (float)(this.drawRect.Width / (result.Max() - result.Min()));
            double min = result.Min();
            SizeF pointSize = new SizeF(8, 8);
            for (int i = 0; i < result.Length; i++)
            {
                dataPoints[i] = new PointF((float)(unitX * (result[i] - min)), resultY[i]);
                graphics.FillEllipse(Brushes.Black, new RectangleF(dataPoints[i], pointSize));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Test();
        }
    }
}
