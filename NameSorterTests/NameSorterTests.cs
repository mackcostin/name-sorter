using Microsoft.VisualStudio.TestTools.UnitTesting;
using name_sorter;
using System;
using System.IO;

namespace NameSorter.Tests
{
    [TestClass()]
    public class NameSorterTests
    {
        private string filePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "/unsorted-names-list.txt";

        /// Tests if an unordered list has been created.
        [TestMethod()]
        public void ReadFile_IsNotNull_Test()
        {
            var list = Program.ReadFile(filePath);

            Assert.IsTrue(list.Count >= 1);
            Assert.IsNotNull(list);
        }

        // Tests if the CreateSortedList method returns any values.
        [TestMethod()]
        public void CreateSortedList_HasValue_Test()
        {
            var list = Program.ReadFile(filePath);
            var sortedList = Program.CreateSortedList(list);

            Assert.IsNotNull(sortedList);
            Assert.IsTrue(sortedList.Count >= 1);
        }

        // Tests if the CreateTextFile method has returned true. Signifying that the file has been created.
        [TestMethod()]
        public void CreateTextFile_IsCreated_Test()
        {
            var list = Program.ReadFile(filePath);
            var sortedList = Program.CreateSortedList(list);

            Assert.IsTrue(Program.CreateTextFile(sortedList, filePath));
        }

        // Tests that the SplitNameToArray method is returning an array for the provided name.
        [TestMethod()]
        public void SplitNameToArray_HasValue_Test()
        {
            Assert.IsNotNull(Program.SplitNameToArray("Beau Tristan Bentley"));
        }
    }
}