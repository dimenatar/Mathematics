using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Formes;
using System.Drawing;
namespace Mathematics.Classes
{
    static class MatrixBuilder
    {
        private static DataGridView CreateDataPattern(DataGridView DataPattern)
        {
            DataPattern = new DataGridView();
            DataPattern.Size = new Size(403, 259);
            DataPattern.BackgroundColor = Color.DarkSeaGreen;
            DataPattern.ColumnHeadersVisible = false;
            DataPattern.RowHeadersVisible = false;
            DataPattern.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
            DataPattern.DefaultCellStyle.SelectionBackColor = Color.Blue;
            DataPattern.AllowUserToAddRows = false;
            DataPattern.AllowUserToDeleteRows = false;
            
            
            return DataPattern;
        }
        private static Random random = new Random();
        private static DataGridView RandomizeCells(DataGridView dataGridview)
        {
            for (int i =0; i < dataGridview.RowCount; i ++)
            {
                for (int j =0; j < dataGridview.ColumnCount; j ++)
                {
                    dataGridview.Rows[i].Cells[j].Value = random.Next(-25, 25);
                }
            }
            return dataGridview;
        }
        public static DataGridView[] BuildDefaultThreeMatrix(int RowCount, int ColCount, params DataGridView[] dataGridViews)
        {
            for (int i =0; i<dataGridViews.Length-1; i ++)
            {
                dataGridViews[i] = CreateDataPattern(dataGridViews[i]);
                dataGridViews[i].Location = new Point(i * 600 + 100, 250);
                dataGridViews[i].RowCount = RowCount;
                dataGridViews[i].ColumnCount = ColCount;
                dataGridViews[i] = RandomizeCells(dataGridViews[i]);
                dataGridViews[i].Name = i.ToString();
            }

            dataGridViews[dataGridViews.Length - 1] = CreateDataPattern(dataGridViews[dataGridViews.Length - 1]);
            dataGridViews[dataGridViews.Length - 1].Location = new Point(400, 600);
            dataGridViews[dataGridViews.Length - 1].RowCount = RowCount;
            dataGridViews[dataGridViews.Length - 1].ColumnCount = ColCount;
            dataGridViews[dataGridViews.Length - 1].Name = "3";

            return dataGridViews;
        }
    }
}
