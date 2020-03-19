using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class Plot
    {
        public bool IsFlagged { get; private set; }
        public bool IsCovered { get; private set; }
        public bool IsMine { get; private set; }

        public Plot()
        {
            IsCovered = true;
            IsFlagged = false;
            IsMine = false;
        }

        public void PlantMine()
        {
            IsMine = true;
        }

        public void Reveal()
        {
            if (!IsFlagged)
            {
                IsCovered = false;
            }
        }

        public void ToggleFlag()
        {
            if (IsCovered)
            {
                IsFlagged = !IsFlagged;
            }
        }

        public override string ToString()
        {
            string output = string.Empty;

            if (IsFlagged)
            {
                output += 'F';
            }
            else if (IsCovered)
            {
                output += '.';
            }
            else if (IsMine)
            {
                output += 'M';
            }

            return output;
        }
    }
}
