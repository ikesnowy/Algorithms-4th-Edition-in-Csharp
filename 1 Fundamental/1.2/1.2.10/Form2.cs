using System;
using System.Drawing;
using System.Windows.Forms;

namespace _1._2._10
{
    public partial class Form2 : Form
    {
        VisualCounter counter;
        Graphics graphics;
        public Form2(int N, int max)
        {
            InitializeComponent();
            counter = new VisualCounter("count", max, N);
            graphics = this.PaintArea.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!counter.Increment())
            {
                this.ErrorLabel.Text = "操作数不足";
            }
            else
            {
                this.ErrorLabel.Text = "";
                counter.Draw(graphics,this.PaintArea.Width, this.PaintArea.Height, this.Font);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!counter.Decreasement())
            {
                this.ErrorLabel.Text = "操作数不足";
            }
            else
            {
                this.ErrorLabel.Text = "";
                counter.Draw(graphics, this.PaintArea.Width, this.PaintArea.Height, this.Font);
            }
        }
    }
}
