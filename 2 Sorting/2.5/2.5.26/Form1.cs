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
            panel = new Form2();
            panel.Init();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var X = int.Parse(InputX.Text);
                var Y = int.Parse(InputY.Text);
                panel.Add(new Point2D(X, Y));
            }
            catch (ArgumentNullException)
            {
                ErrorLabel.Text = "输入值不能为空。";
            }
            catch (FormatException)
            {
                ErrorLabel.Text = "格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                ErrorLabel.Text = "数据过大";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel.Add(new Point2D(
                random.NextDouble() * panel.ClientRectangle.Width + 1,
                random.NextDouble() * panel.ClientRectangle.Height + 1));
        }
    }
}
