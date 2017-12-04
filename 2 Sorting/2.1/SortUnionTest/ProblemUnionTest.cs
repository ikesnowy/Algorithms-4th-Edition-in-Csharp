using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using SortData;

namespace SortUnionTest
{
    [TestClass]
    public class ProblemUnionTest
    {
        [TestMethod]
        public void ShellSort11Test()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

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
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            _2._1._12.ShellSort sort = new _2._1._12.ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void ShellSort19Test()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            _2._1._19.ShellSort sort = new _2._1._19.ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void SelectionSort16Test()
        {
            int[] unsorted = DataManager.GetUnsortedData();
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

        [TestMethod]
        public void InsertionSort24Test()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            _2._1._24.InsertionSort sort = new _2._1._24.InsertionSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void InsertionSort25Test()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            _2._1._25.InsertionSort sort = new _2._1._25.InsertionSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void InsertionSort26Test()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            _2._1._26.InsertionSort sort = new _2._1._26.InsertionSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }
    }
}
