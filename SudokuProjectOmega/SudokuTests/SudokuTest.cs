using Microsoft.VisualStudio.TestTools.UnitTesting;
using SudokuProjectOmega;

namespace SudokuTests
{
    [TestClass]
    public class SudokuTest
    {
        [TestMethod]
        public void TestEmpty1x1_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("0"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestSolved1x1_ReturnsTrue()
        {
            Board sudoku = new Board(new SudokuString("1"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestInvalidCharcter1x1_ReturnsTrue()
        {
            Assert.AreEqual(Program.Solve("a", 1), "Invalid input: all characters must be a valid in range sudoku characters...", "not equal");
        }

        [TestMethod]
        public void TestEmpty4x4_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("0000000000000000"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void Test4x4No1_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("0010002000000000"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);

            Assert.AreEqual(Program.Solve("0000000000000000", 1), "1234341221434321", "not equal");
            Assert.AreEqual(Program.Solve("0010002000000000", 1), "2413132431424231", "not equal");
            Assert.AreEqual(Program.Solve("0011002000000000", 1), "Cannot solve this board due to invalid cell positioning...", "not equal");
        }

        [TestMethod]
        public void Test4x4InvalidBoard()
        {
            Assert.AreEqual(Program.Solve("0011002000000000", 1), "Cannot solve this board due to invalid cell positioning...", "not equal");
        }

        [TestMethod]
        public void Test9x9No1_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("306508400520000000087000031003010080900863005050090600130000250000000074005206300"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void Test9x9No2_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("002501700600807009080204010007602500050000090004109200070305060500908007008706900"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestEmpty9x9_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("000000000000000000000000000000000000000000000000000000000000000000000000000000000"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestEmpty16x16_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "00000000000000000000000000000000000000000000000"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestFull16x16_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("123456789:;<=>?@5678=>?@12349:;<9:;<1234=>?" +
                "@5678=>?@9:;<56781234241389:5>;<6" +
                "@?=7?;<>@4162=57839:7=@9>;2?83:164<585:6" +
                "37<=?@49;12>31826597;4@=:<>?<74=;?>1398:2@56>@9:4<=2651?378;6?5;:8@3" +
                "7<2>491=4861<35;:7>2?=@9:3=?7@89<165>;42;<>52=4:@?9378" +
                "61@927?16>48=;<5:3"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestAlmostEmpty16x16_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("00000000000000000000000000000000000000000000000000008000000000" +
                "00000000000000000000000000000000000000000000000000000000000000000000000000000000000000000" +
                "400000000000000060000000000000002000000500000050000000000000000000000000?00000000000000000000000000500000"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void Test16x16No1_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("040080@0;010060>30090?04:70=00<006002;0080003000?0000" +
                "00=00>002040008030070005000000000>0000:0@0=009250000800;000<010000@00=00030000" +
                "<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;005;3:000800<400010>0" +
                "0;9000=?04050=040600000020<090<0@0=00010060?0"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void Test16x16No2_ReturnsTrue()
        {
            // Arrange
            Board sudoku = new Board(new SudokuString("0090104576;<=0?00700280040005:0<0<" +
                "00000015:=28390000000023984167000856009:<0>0@=130000000" +
                "2407<:600<0702030=189450=0004<0875632108103000:5<0@96=>056" +
                "00003=48:<72000000090>032:@5100>=000<69170483061530000879@=<40" +
                "0070004012365>800320>07<=65009:00009000:@>41372"));

            // Act
            bool solution = SudokuSolver.Solve(sudoku);

            // Assert
            Assert.IsTrue(solution);

            // test result
            ValidateSudoku.ValidateSudokuPositioning(sudoku);
        }

        [TestMethod]
        public void TestImpossibleBoardSize16x16()
        {
            Assert.AreEqual(Program.Solve("40080@0;010060>30090?04:70=00<006002;0080003000?0000" +
                "00=00>002040008030070005000000000>0000:0@0=009250000800;000<010000@00=00030000" +
                "<?0000600=047@1=0:00300700900600000;04009002:03000@000>800;005;3:000800<400010>0" +
                "0;9000=?04050=040600000020<090<0@0=00010060?0", 1),
                "Impossible board size...", "not equal");
        }

        [TestMethod]
        public void TestUnsolvableBoard16x16()
        {
            Assert.AreEqual(Program.Solve("102300;680054<00>00;08:0<09007000<00000002700?090090070000:0>85" +
                ";0:0@1002;40600080300000900000000;942050>00=030000000008@3920040000100:?39600000000060900@" +
                "0<02;4>00000000200000102000@0>8100=<06054?10>0000600@0060@00250000000<000<00@0:0710=00400:>?00;43000501", 1),
                "Unsolvable board", "not equal");
        }

        [TestMethod]
        public void TestEmptyBoard()
        {
            Assert.AreEqual(Program.Solve("", 1),
                "Invalid Board: empty board", "not equal");
        }
    }
}