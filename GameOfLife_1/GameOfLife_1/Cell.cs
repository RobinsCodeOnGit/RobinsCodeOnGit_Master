using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife_1
{
    class Cell
    {
            private bool cellState;

            public Cell()
            {
                this.CellState = false;
            }
            public bool CellState { get => cellState; set => cellState = value; }
    }
}
