using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuProjectOmega;

namespace SudokuTests
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void Test1x1()
        {
            Assert.AreEqual(Program.Solve("0", 1), "1", "not equal");
            Assert.AreEqual(Program.Solve("1", 1), "1", "not equal");
            Assert.AreEqual(Program.Solve("a", 1), "Invalid input: all characters must be a valid in range sudoku characters...", "not equal");
        }

        [TestMethod]
        public void Test4x4()
        {
            Assert.AreEqual(Program.Solve("0000000000000000", 1), "1234341221434321", "not equal");
            Assert.AreEqual(Program.Solve("0010002000000000", 1), "2413132431424231", "not equal");
            Assert.AreEqual(Program.Solve("0011002000000000", 1), "Cannot solve this board due to invalid cell positioning...", "not equal");
        }
    }
}