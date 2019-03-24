using System.Windows.Forms;
using SymbolTable;

namespace _3._1._39
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        void Test()
        {
            BinarySearchSTAnalysis<string, int> bst = new BinarySearchSTAnalysis<string, int>();
            FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, bst, out int[] callIndexBinary, out long[] timeRecordBinary);
            Form2 resultBinary = new Form2();
            resultBinary.Text = "BinarySearch";
            resultBinary.Show();
            resultBinary.Draw(callIndexBinary, timeRecordBinary);

            SequentialSearchSTAnalysis<string, int> sst = new SequentialSearchSTAnalysis<string, int>();
            FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, sst, out int[] callIndexSequential, out long[] timeRecordSequential);
            Form2 resultSequential = new Form2();
            resultSequential.Text = "Sequential";
            resultSequential.Show();
            resultSequential.Draw(callIndexSequential, timeRecordSequential);
        }
    }
}
