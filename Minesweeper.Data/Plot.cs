using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper.Data
{
    public class Plot
    {
        public bool IsCovered { get; private set; }
        public bool IsMine { get; private set; }

        public Plot()
        {
            IsCovered = true;
            IsMine = false;
        }

        public void PlantMine()
        {
            IsMine = true;
        }

        public void Reveal()
        {
            IsCovered = false;
        }
    }
}
