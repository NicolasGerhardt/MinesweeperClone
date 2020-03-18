using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class Minefield
    {
        public int Cols { get; private set; }
        public int Rows { get; private set; }
        public Plot[,] Plots { get; private set; }

        public Minefield(int cols, int rows)
        {
            //make sure only valid values are passed
            if (cols < 1 || rows < 1) throw new ArgumentException("Must have at least 1 Row and Col");

            //initalized Rows, Cols and Minefield's mines
            Cols = cols;
            Rows = rows;
            Plots = GenerateEmptyPlots();
        }

        private Plot[,] GenerateEmptyPlots()
        {
            var emptyPlots = new Plot[Cols, Rows];
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    emptyPlots[x, y] = new Plot();
                }
            }
            return emptyPlots;
        }

        public void PlaceMines(int numOfMines)
        {
            //make sure only valid values are passed
            if (numOfMines > Plots.Length || numOfMines < 1) throw new ArgumentException($"Must place betwen 1 and {Plots.Length} mines in this Minefield");

            //clear all old mines
            Plots = GenerateEmptyPlots();

            //create randomizer object
            var rand = new Random();

            //place all mines
            while (numOfMines > 0)
            {
                //get random corrdinates
                int x = rand.Next(0, Cols);
                int y = rand.Next(0, Rows);

                // if no mine at location, then place mine
                if (!Plots[x,y].IsMine)
                {
                    Plots[x, y].PlantMine();
                    numOfMines--;
                }
            }
        }

        /// <summary>
        /// Checks to see if the plot is a mine and returns -1 if it is.
        /// Will count all of the neighbor cells to see if they contain any mines and return that count.
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public int CountNeighboringMines(int col, int row)
        {
            //validate input
            if (col >= Cols || col < 0) throw new ArgumentException($"Column must be between 0 and {Cols}");
            if (row >= Rows || row < 0) throw new ArgumentException($"Row must be between 0 and {Cols}");

            // if spot is a mine return -1
            if (Plots[col, row].IsMine) return -1;

            int count = 0;
            //check above, below and digonally for mines.
            for (int x = col - 1; x <= col + 1; x++)
            {
                for (int y = row - 1; y <= row + 1; y++)
                {
                    // make sure you are on the grid
                    if (x >= 0 && x < Cols && y >= 0 && y < Rows)
                    {
                        //if neighbor is a mine, add it to the count
                        if (Plots[x, y].IsMine)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        public bool RevealPlot(int col, int row)
        {
            return false;
        }
    }
}
