using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;
using SortData;

namespace SortUnionTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void SelectionSortTest()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            SelectionSort sort = new SelectionSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void InsertionSortTest()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            InsertionSort sort = new InsertionSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }

        [TestMethod]
        public void ShellSortTest()
        {
            int[] unsorted = DataManager.GetUnsortedData();
            int[] sorted = DataManager.GetSortedData();

            ShellSort sort = new ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }
    }
}
