using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortUnionTest
{
    [TestClass]
    public class ProblemClassTest
    {
        [TestMethod]
        public void ShellSort11Test()
        {
            int[] unsorted = GetUnsortedData();
            int[] sorted = GetSortedData();

            _2._1._11.ShellSort sort = new _2._1._11.ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void ShellSort12Test()
        {
            int[] unsorted = GetUnsortedData();
            int[] sorted = GetSortedData();

            _2._1._12.ShellSort sort = new _2._1._12.ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void SelectionSort16Test()
        {
            int[] unsorted = GetUnsortedData();
            int testSize = 1000;
            string[] unsortedString = new string[testSize];
            string[] sortedString = new string[testSize];

            for (int i = 0; i < testSize; i++)
            {
                unsortedString[i] = unsorted[i].ToString();
                sortedString[i] = unsorted[i].ToString();
            }

            Array.Sort(sortedString);
            _2._1._16.Program.SelectionSort(unsortedString);

            for (int i = 0; i < testSize; i++)
            {
                Assert.AreEqual(unsortedString[i], sortedString[i]);
            }
        }

        public int[] GetUnsortedData()
        {
            char[] split = new char[2] { '\n', '\r' };
            string[] unsortedString = Properties.Resources._32Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int[] unsorted = new int[unsortedString.Length];
            for (int i = 0; i < unsortedString.Length; i++)
            {
                unsorted[i] = int.Parse(unsortedString[i]);
            }
            return unsorted;
        }

        public int[] GetSortedData()
        {
            char[] split = new char[2] { '\n', '\r' };
            string[] sortedString = Properties.Resources._32Kints_Sorted.Split(split, StringSplitOptions.RemoveEmptyEntries);
            int[] sorted = new int[sortedString.Length];
            for (int i = 0; i < sortedString.Length; i++)
            {
                sorted[i] = int.Parse(sortedString[i]);
            }
            return sorted;
        }
    }
}
