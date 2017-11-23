using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace SortUnionTest
{
    [TestClass]
    public class SortTest
    {
        [TestMethod]
        public void SelectionSortTest()
        {
            int[] unsorted = GetUnsortedData();
            int[] sorted = GetSortedData();

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
            int[] unsorted = GetUnsortedData();
            int[] sorted = GetSortedData();

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
            int[] unsorted = GetUnsortedData();
            int[] sorted = GetSortedData();

            ShellSort sort = new ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
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
