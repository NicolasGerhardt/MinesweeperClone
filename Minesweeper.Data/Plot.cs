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

        internal void PlantMine()
        {
            IsMine = true;
        }

        internal void Reveal()
        {
            if (!IsFlagged)
            {
                IsCovered = false;
            }
        }

        internal void ToggleFlag()
        {
            if (IsCovered)
            {
                IsFlagged = !IsFlagged;
            }
        }
    }
}
