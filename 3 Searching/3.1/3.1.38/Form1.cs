using System.Windows.Forms;
using SymbolTable;

namespace _3._1._38
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Test();
        }

        static void Test()
        {
            BinarySearchSTAnalysis<string, int> bst = new BinarySearchSTAnalysis<string, int>();
            int[] dataBinary = FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, bst);
            Form2 resultBinary = new Form2();
            resultBinary.Text = "BinarySearch";
            resultBinary.Show();
            resultBinary.Draw(dataBinary);

            SequentialSearchSTAnalysis<string, int> sst = new SequentialSearchSTAnalysis<string, int>();
            int[] dataSequential = FrequencyCounter.MostFrequentlyWordAnalysis("tale.txt", 8, sst);
            Form2 resultSequential = new Form2();
            resultSequential.Text = "Sequential";
            resultSequential.Show();
            resultSequential.Draw(dataSequential);
        }
    }
}
