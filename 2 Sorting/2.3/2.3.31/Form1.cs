using System;
using System.Windows.Forms;

namespace _2._3._31
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
                var N = int.Parse(this.InputN.Text);
                var T = int.Parse(this.InputT.Text);
                var panel = new Form2(N, T);
                panel.ShowDialog();
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
    }
}
