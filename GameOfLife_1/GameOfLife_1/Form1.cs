using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife_1
{
    public partial class Form1 : Form
    {
        LifeCellGrid cellGrid;
        public Form1()
        {
            InitializeComponent();
            cellGrid = new LifeCellGrid();
                       
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            //Die 35 Spalten wurden bereits im Designer hinzugefügt. 
            //Eine Zeile kann nur hinzugefügt werden, wenn die Spalten bereits vorhanden sind.
                                   
            for (int i = 0; i < 40; i++)
            {
                dataGridView1.Rows.Add();
                
                dataGridView1.RowCount = 40;
                
                for (int j = 0; j < 40; j++)
                {                    

                    dataGridView1.Rows[j].Cells[i].Value = "";
                    dataGridView1.Rows[j].Height = 15;
                    
                    
                    
                }

               
            }
   
       }

        

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // On Click change from "" to "x" and vice versa
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "")
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "x";
                cellGrid.SetCellOldGrid(e.RowIndex, e.ColumnIndex, true);
                
            }
            else
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                cellGrid.SetCellOldGrid(e.RowIndex, e.ColumnIndex, false);
            }
        }

        private void NextGeneration_Click(object sender, EventArgs e)
        {
            cellGrid.NextGeneration();
            PrintCellGrid();
            // Count Generations ++
            generationCount.Text = (Convert.ToInt32((generationCount.Text == "") ? "0" : generationCount.Text) + 1).ToString();
        }

        private void PrintCellGrid()
        {
            for (int i = 0; i < cellGrid.GetNumberOfColumns(); i++)
            {
                for (int j = 0; j < cellGrid.GetNumberOfRows(); j++)
                {
                    string input = "";
                    if (cellGrid.GetCellOldGrid(j, i))
                    {
                        input = "x";
                    }
                    dataGridView1.Rows[j].Cells[i].Value = input;
                }
            }
        }
        private void close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cellGrid.ClearCellGrids();
            for (int i = 0; i < cellGrid.GetNumberOfColumns(); i++)
            {
                for (int j = 0; j < cellGrid.GetNumberOfRows(); j++)
                {
                    string input = "";
                    if (cellGrid.GetCellOldGrid(j, i))
                    {
                        input = "x";
                    }
                    dataGridView1.Rows[j].Cells[i].Value = input;
                }
            }
        }
    }
}



