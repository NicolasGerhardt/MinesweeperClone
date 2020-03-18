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
        public bool[,] Mines { get; private set; }

        public Minefield(int cols, int rows)
        {
            //make sure only valid values are passed
            if (cols < 1 || rows < 1) throw new ArgumentException("Must have at least 1 Row and Col");

            //initalized Rows, Cols and Minefield's mines
            Cols = cols;
            Rows = rows;
            Mines = new bool[cols, rows];
            emptyMineField();
        }

        private void emptyMineField()
        {
            //March through minefield and set all valuse to false
            for (int x = 0; x < Cols; x++)
            {
                for (int y = 0; y < Rows; y++)
                {
                    Mines[x, y] = false;
                }
            }
        }

        public void PlaceMines(int numOfMines)
        {
            //make sure only valid values are passed
            if (numOfMines > Mines.Length) throw new ArgumentException($"Can only place {Mines.Length} mines in this Minefield");

            //create randomizer object
            var rand = new Random();

            //place all mines
            while (numOfMines > 0)
            {
                //get random corrdinates
                int x = rand.Next(0, Cols);
                int y = rand.Next(0, Rows);

                // if no mine at location, then place mine
                if (!Mines[x,y])
                {
                    Mines[x, y] = true;
                    numOfMines--;
                }
            }


        }
    }
}
