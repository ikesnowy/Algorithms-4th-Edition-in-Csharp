using System;
using System.Windows.Forms;

namespace _1._1._31
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "";
            int N;
            double p;
            try
            {
                N = int.Parse(InputN.Text);
                p = double.Parse(InputP.Text);
                if (p > 1)
                {
                    ErrorLabel.Text = "p 的值不能大于 1";
                    return;
                }
                if (p < 0 || N < 0)
                {
                    ErrorLabel.Text = "不能输入负值";
                    return;
                }
                Program.StartDrawing(N, p);
            }
            catch (ArgumentNullException aex)
            {
                ErrorLabel.Text = "参数不足，是否漏填了某个参数？";
            }
            catch (FormatException fex)
            {
                ErrorLabel.Text = "你似乎填入了非数字的内容（是否漏填了参数？）。";
            }
            catch (OverflowException oex)
            {
                ErrorLabel.Text = "你填入的数字太大了。";
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.Message;
            }
        }
    }
}
