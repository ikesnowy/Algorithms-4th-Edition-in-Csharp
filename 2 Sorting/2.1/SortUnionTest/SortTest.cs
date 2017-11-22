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
            IComparable[] unsorted = GetUnsortedData();
            IComparable[] sorted = GetSortedData();

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
            IComparable[] unsorted = GetUnsortedData();
            IComparable[] sorted = GetSortedData();

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
            IComparable[] unsorted = GetUnsortedData();
            IComparable[] sorted = GetSortedData();

            ShellSort sort = new ShellSort();
            sort.Sort(unsorted);
            for (int i = 0; i < unsorted.Length; i++)
            {
                Assert.AreEqual(unsorted[i], sorted[i]);
            }
        }


        public IComparable[] GetUnsortedData()
        {
            char[] split = new char[2] { '\n', '\r' };
            string[] unsortedString = Properties.Resources._32Kints.Split(split, StringSplitOptions.RemoveEmptyEntries);
            IComparable[] unsorted = new IComparable[unsortedString.Length];
            for (int i = 0; i < unsortedString.Length; i++)
            {
                unsorted[i] = int.Parse(unsortedString[i]);
            }
            return unsorted;
        }

        public IComparable[] GetSortedData()
        {
            char[] split = new char[2] { '\n', '\r' };
            string[] sortedString = Properties.Resources._32Kints_Sorted.Split(split, StringSplitOptions.RemoveEmptyEntries);
            IComparable[] sorted = new IComparable[sortedString.Length];
            for (int i = 0; i < sortedString.Length; i++)
            {
                sorted[i] = int.Parse(sortedString[i]);
            }
            return sorted;
        }
    }
}
