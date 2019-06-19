using System.Windows.Forms;

namespace _1._5._19
{
    public partial class Log : Form
    {
        public Log(int n)
        {
            InitializeComponent();
            Program.Draw(n, textBox1, this);
        }
    }
}
