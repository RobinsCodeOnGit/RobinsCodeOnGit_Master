using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameOfLife_2
{
    public partial class Form1 : Form
    {
        LifeCellGrid cellGrid;
        public Form1()
        {
            InitializeComponent();
            cellGrid = new LifeCellGrid();
            timer1.Enabled = false;
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
            NextGeneration();
        }
        private void NextGeneration()
        {
            cellGrid.NextGeneration();
            PrintCellGrid();
            // Count Generations ++
            generationCount.Text = (Convert.ToInt32((generationCount.Text == "") ? "0" : generationCount.Text) + 1).ToString();
            tb_count_cells_alive.Text = cellGrid.GetCountOfLivingCells().ToString();
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            NextGeneration();
        }

        private void simulation_timer_btn_Click(object sender, EventArgs e)
        {
            timer1.Enabled = (timer1.Enabled == true) ? false : true;
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer1.Interval = trackBar1.Value * 100;
            trackEvolutionSpeed.Text = "Geschwindigkeit: " + (trackBar1.Value*100).ToString() + " ms";
        }

        private void btn_show_chart_Click(object sender, EventArgs e)
        {
            CellChartAnalyses cellChartAnalyses = new CellChartAnalyses(cellGrid.GetStatisticAnalysesList());
            cellChartAnalyses.Show();


        }
    }
}



