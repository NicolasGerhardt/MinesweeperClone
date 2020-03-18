﻿using System;
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

        public Minefield(int cols, int rows, int numOfMines)
        {
            //make sure only valid values are passed
            if (cols < 1 || rows < 1) throw new ArgumentException("Must have at least 1 Row and Col");

            //initalized Rows, Cols and Minefield's mines
            Cols = cols;
            Rows = rows;
            Plots = GeneratePlots(numOfMines);
        }


        private Plot[,] GeneratePlots(int numOfMines)
        {
            //make sure only valid values are passed
            if (numOfMines >= Cols * Rows || numOfMines < 1) throw new ArgumentException($"Must have betwen 1 and {Cols * Rows - 1} mines in this Minefield");

            //start with empty field
            var generateedPlots = new Plot[Cols, Rows];

            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    generateedPlots[x, y] = new Plot();
                }
            }
            

            //create randomizer object
            var rand = new Random();

            //place all mines
            while (numOfMines > 0)
            {
                //get random corrdinates
                int x = rand.Next(0, Cols);
                int y = rand.Next(0, Rows);

                // if no mine at location, then place mine
                if (!generateedPlots[x, y].IsMine)
                {
                    generateedPlots[x, y].PlantMine();
                    numOfMines--;
                }
            }

            return generateedPlots;
        }

        public void TogglePlotFlag(int col, int row)
        {
            //validate input
            validColRow(col, row);

            Plots[col, row].ToggleFlag();

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
            validColRow(col, row);

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

        private void validColRow(int col, int row)
        {
            if (col < 0) throw new ArgumentException($"Column must be a positive number");
            if (row < 0) throw new ArgumentException($"Row must be a positive number");
            if (col >= Cols) throw new ArgumentException($"Column must be smaller than {Cols}");
            if (row >= Rows) throw new ArgumentException($"Row must be smaller than {Rows}");
        }


        /// <summary>
        /// Will mark the plot as reveiled. Returns True if Mine and Returns false if not mine.
        /// If spot has no mines next to it, then it will reveil all neighbors
        /// </summary>
        /// <param name="col"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public bool RevealPlot(int col, int row)
        {
            //validate inputs
            validColRow(col, row);

            //if already uncovered, no further action is needed
            if (!Plots[col, row].IsCovered || Plots[col, row].IsFlagged)
            {
                return false;
            }

            // uncover plot
            Plots[col, row].Reveal();

            // if plot is mine return false
            if (Plots[col, row].IsMine)
            {
                return true;
            }

            // if return false for neighboring mines. 
            if (CountNeighboringMines(col, row) > 0)
            {
                return false;
            }

            for (int x = col - 1; x <= col + 1; x++)
            {
                for (int y = row - 1; y <= row + 1; y++)
                {
                    if (x >= 0 && x < Cols && y >= 0 && y < Rows)
                    {
                        RevealPlot(x, y);
                    }
                }
            }

            return false;
        }
    }
}
