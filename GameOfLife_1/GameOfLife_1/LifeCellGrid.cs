using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife_1
{
    class LifeCellGrid
    {
        private int numberOfRows = 40, numberOfColumns = 40;
        private Cell[,] OldCellGrid;
        private Cell[,] NewCellGrid;

        public LifeCellGrid()
        {
            // Set Default Grid = false
            this.OldCellGrid1 = new Cell[numberOfColumns, numberOfRows];
            this.NewCellGrid1 = new Cell[numberOfColumns, numberOfRows];


            for (int i = 0; i < OldCellGrid.GetLength(0); i++)
            {
                for (int j = 0; j < OldCellGrid.GetLength(1); j++)
                {
                    this.OldCellGrid1[i, j] = new Cell();
                    this.NewCellGrid1[i, j] = new Cell();
                }
            }
           
            
        }

        public Cell[,] NewCellGrid1 { get => NewCellGrid; set => NewCellGrid = value; }
        public Cell[,] OldCellGrid1 { get => OldCellGrid; set => OldCellGrid = value; }

        public int GetNumberOfColumns()
        {
            return this.OldCellGrid.GetLength(0);
        }

        public int GetNumberOfRows()
        {
            return this.OldCellGrid.GetLength(1);
        }
        public void ClearCellGrids()
        {
            for (int i = 0; i < OldCellGrid.GetLength(0); i++)
            {
                for (int j = 0; j < OldCellGrid.GetLength(1); j++)
                {
                    this.OldCellGrid1[i, j].CellState = false;
                    this.NewCellGrid1[i, j].CellState = false;
                }
            }
        }
        private int GetNeighboursTrue(Cell[,] cellGrid, int column, int row)
        {
            

            int maxCol = cellGrid.GetLength(0) - 1;
            int maxRow = cellGrid.GetLength(1) - 1;
            int colPlusOne = ((column + 1) > maxCol ? 0 : (column + 1));
            int colMinOne  = ((column - 1) < 0 ? maxCol : (column - 1));

            int rowPlusOne = ((row + 1) > maxRow ? 0 : (row + 1));
            int rowMinOne = ((row - 1) < 0 ? maxRow : (row - 1));

            int x = 0;

            x += cellGrid[colPlusOne,    row    ].CellState ? 1 : 0;
            x += cellGrid[colPlusOne,    rowPlusOne].CellState ? 1 : 0;
            x += cellGrid[colPlusOne,    rowMinOne].CellState ? 1 : 0;
            x += cellGrid[colMinOne,    row    ].CellState ? 1 : 0;
            x += cellGrid[colMinOne,    rowPlusOne].CellState ? 1 : 0;
            x += cellGrid[colMinOne,    rowMinOne].CellState ? 1 : 0;
            x += cellGrid[column,        rowPlusOne].CellState ? 1 : 0;
            x += cellGrid[column,        rowMinOne].CellState ? 1 : 0;
            
            return x;
        }

        public void SetCellOldGrid(int row, int col, bool state)
        {
            this.OldCellGrid[col, row].CellState = state;
        }
        public bool GetCellOldGrid(int row, int col)
        {
            return this.OldCellGrid[col, row].CellState;
        }
        public void SetCellNewGrid(int row, int col, bool state)
        {
            this.OldCellGrid[col, row].CellState = state;
        }
        public bool GetCellNewGrid(int row, int col)
        {
            return this.OldCellGrid[col, row].CellState;
        }

        private void SetNewGridAsOldGrid()
        {
            for (int i = 0; i < NewCellGrid.GetLength(0); i++)
            {
                for (int j = 0; j < NewCellGrid.GetLength(1); j++)
                {
                    this.OldCellGrid1[i, j].CellState = this.NewCellGrid[i, j].CellState;
                }
            }
        }
        public void NextGeneration()
        {
            for (int col = 0; col < NewCellGrid.GetLength(0); col++)
            {
                for (int row = 0; row < NewCellGrid.GetLength(1); row++)
                {
                    // Implementation of Rules
                    if (GetNeighboursTrue(OldCellGrid, col, row) < 2 || GetNeighboursTrue(OldCellGrid, col, row) > 3)
                    {
                        this.NewCellGrid[col, row].CellState = false;
                    }
                    
                    
                    if (GetNeighboursTrue(OldCellGrid, col, row) == 3)
                    {
                        this.NewCellGrid[col, row].CellState = true;
                    }
                    
                    if (GetNeighboursTrue(OldCellGrid, col, row) == 2)
                    {
                        this.NewCellGrid[col, row].CellState = this.OldCellGrid[col, row].CellState;
                    }
                }
            }
            SetNewGridAsOldGrid();
        }
    }
}
