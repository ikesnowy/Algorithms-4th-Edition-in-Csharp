using System;
using System.Windows.Forms;
using BinarySearchTree;

namespace _3._2._45
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Test(new SequentialSearchST<string, int>());
            Test(new BinarySearchST<string, int>());
            Test(new BST<string, int>());
        }

        private void Test(IST<string, int> st)
        {
            FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, st, out var callIndex, out var timeRecord);
            var panel = new Form2
            {
                Text = st.GetType().Name
            };
            panel.Show();
            panel.Draw(callIndex, timeRecord);
        }
    }
}
