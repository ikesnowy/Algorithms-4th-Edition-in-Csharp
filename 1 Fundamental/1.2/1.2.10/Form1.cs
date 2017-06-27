using System;
using System.Windows.Forms;

namespace _1._2._10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int N = int.Parse(this.InputN.Text);
                int max = int.Parse(this.InputMax.Text);

                if (N < 0)
                {
                    this.ErrorLabel.Text = "操作数不可小于 0";
                    return;
                }
                Form2 drawPad = new Form2(N, max);
                drawPad.Show();
            }
            catch (ArgumentNullException)
            {
                this.ErrorLabel.Text = "不能输入空值";
            }
            catch (FormatException)
            {
                this.ErrorLabel.Text = "格式错误（是否输入了空值？）";
            }
            catch (OverflowException)
            {
                this.ErrorLabel.Text = "输入值过大";
            }
        }
    }
}
