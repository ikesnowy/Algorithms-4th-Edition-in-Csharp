using System;
using System.Windows.Forms;
using Sort;

namespace _2._1._32
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
                if (this.selectionSortRadio.Checked)
                {
                    new Form2(new SelectionSort(), N).Show();
                }
                else if (this.insertionSortRadio.Checked)
                {
                    new Form2(new InsertionSort(), N).Show();
                }
                else if (this.shellSortRadio.Checked)
                {
                    new Form2(new ShellSort(), N).Show();
                }
                else
                {
                    this.ErrorLabel.Text = "请至少选择一项排序算法";
                }
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
