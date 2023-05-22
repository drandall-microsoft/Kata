using CSharpKatas.Minesweeper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CSharpKata.Test
{
    [TestClass]
    public class MinesweeperTests
    {
        [TestMethod]
        public void ValueOnAllMines_WithZeroMineBoard_IsNotAMineAndIsZero()
        {
            Board board = new Board(4, 4);

            for (uint row = 0; row < board.Height; row++)
            {
                for (uint col = 0; col < board.Height; col++)
                {
                    var cell = board.GetCell(row, col);
                    Assert.IsFalse(cell.IsMine);
                    Assert.AreEqual(0u, cell.Value);
                }
            }
        }

        [TestMethod]
        public void IsMine_OnMine_IsTrue()
        {
            Board board = new Board(4, 4);
            board.AddMine(0, 0);

            var cell = board.GetCell(0, 0);
            Assert.IsTrue(cell.IsMine);
        }

        [TestMethod]
        public void GetValue_NextToAnyMines_IsNotZeroAndIsNotAMine()
        {
            Board board = new Board(4, 4);
            board.AddMine(0, 0);

            var cell = board.GetCell(0, 1);
            Assert.IsFalse(cell.IsMine);
            Assert.IsTrue(cell.Value > 0);
        }
    }
}
