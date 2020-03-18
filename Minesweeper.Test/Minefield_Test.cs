using Minesweeper.Data;
using System;
using Xunit;

namespace Minesweeper.Test
{
    public class Minefield_Test
    {
        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(2, 1, 1)]
        [InlineData(10, 10, 1)]
        [InlineData(7, 10, 1)]
        [InlineData(100, 12, 1)]
        public void MinefieldConstructor_PositiveValues_noErrors(int cols, int rows, int numOfMines)
        {
            Minefield minefield = new Minefield(cols, rows, numOfMines);

            Assert.Equal(cols, minefield.Cols);
            Assert.Equal(rows, minefield.Rows);
            Assert.Equal(cols * rows, minefield.Plots.Length);
        }

        [Theory]
        [InlineData(0, 1, 1)]
        [InlineData(1, 0, 1)]
        [InlineData(0, 0, 1)]
        [InlineData(-10, -10, 1)]
        [InlineData(7, 10, -5)]
        [InlineData(100, 12, 0)]
        [InlineData(1, 1, 10)]
        public void MinefieldConstructor_InvalidRowsAndCols_ThrowsException(int cols, int rows, int numOfMines)
        {
            Assert.Throws<ArgumentException>(() => new Minefield(cols, rows, numOfMines));
        }


    }

}
