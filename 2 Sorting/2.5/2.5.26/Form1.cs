using System;
using System.Windows.Forms;
using SortApplication;

namespace _2._5._26
{
    public partial class Form1 : Form
    {
        Form2 panel;
        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            this.panel = new Form2();
            this.panel.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var X = int.Parse(this.InputX.Text);
                var Y = int.Parse(this.InputY.Text);
                this.panel.Add(new Point2D(X, Y));
            }
            catch (ArgumentNullException)
            {
                this.ErrorLabel.Text = "输入值不能为空。";
            }
            catch (FormatException)
            {
                this.ErrorLabel.Text = "格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                this.ErrorLabel.Text = "数据过大";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.panel.Add(new Point2D(
                this.random.NextDouble() * this.panel.ClientRectangle.Width + 1,
                this.random.NextDouble() * this.panel.ClientRectangle.Height + 1));
        }
    }
}
