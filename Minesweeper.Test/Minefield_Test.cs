using Minesweeper.Data;
using System;
using Xunit;

namespace Minesweeper.Test
{
    public class Minefield_Test
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 10)]
        [InlineData(7, 10)]
        [InlineData(100, 12)]
        public void MinefieldConstructor_PositiveValues_noErrors(int cols, int rows)
        {
            Minefield minefield = new Minefield(cols, rows);

            Assert.Equal(cols, minefield.Cols);
            Assert.Equal(rows, minefield.Rows);
            Assert.Equal(cols * rows, minefield.Mines.Length);

            foreach (var mine in minefield.Mines)
            {
                Assert.False(mine);
            }

        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(-10, -10)]
        public void MinefieldConstructor_InvalidRowsAndCols_ThrowsException(int cols, int rows)
        {
            Assert.Throws<ArgumentException>(() => new Minefield(cols, rows));
        }

        [Theory]
        [InlineData(1, 1, 0)]
        [InlineData(10, 10, 100)]
        [InlineData(7, 10, 25)]
        [InlineData(100, 12, 120)]
        public void PlaceMines_ValidNumberOfMines_noErrors(int cols, int rows, int numOfMines)
        {
            Minefield minefield = new Minefield(cols, rows);

            minefield.PlaceMines(numOfMines);

            int countOfMines = 0;

            foreach (var mine in minefield.Mines)
            {
                if (mine)
                {
                    countOfMines++;
                }
            }

            Assert.Equal(numOfMines, countOfMines);
        }
    }
}
