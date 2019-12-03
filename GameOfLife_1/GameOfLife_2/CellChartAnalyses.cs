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
    public partial class CellChartAnalyses : Form
    {
        List<int> chartValues = new List<int>();
        public CellChartAnalyses(List<int> chartValues)
        {
            InitializeComponent();
            foreach (int val in chartValues)
            {
                this.chartValues.Add(val);
            }
        }

        private void CellChartAnalyses_Load(object sender, EventArgs e)
        {
            chart1.DataBindTable(chartValues);
        }
    }
}
