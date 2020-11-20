using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathematics
{
    public static class MatrixCalculator
    {
        public static bool DoCheckVoid(DataGridView dataGridView)
        {
            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j++)
                {
                    if (dataGridView.Rows[i].Cells[j].Value == null || dataGridView.Rows[i].Cells[j].Value == DBNull.Value || String.IsNullOrEmpty(dataGridView.Rows[i].Cells[j].Value.ToString()))
                    {
                        MessageBox.Show("Незаполненные поля");
                        return false;
                    }
                }
            }
            return true;
        }

        public static DataGridView MatrixSub(DataGridView dataGridView1, DataGridView dataGridView2, DataGridView dataGridView3)
        {
            if (DoCheckVoid(dataGridView1) && DoCheckVoid(dataGridView2))
            {
                if (dataGridView1.RowCount == dataGridView2.RowCount && dataGridView1.ColumnCount == dataGridView2.ColumnCount)
                {
                    dataGridView3.RowCount = dataGridView1.RowCount;
                    dataGridView3.ColumnCount = dataGridView1.ColumnCount;
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView1.ColumnCount; j++)
                        {
                            dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) - int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString());
                        }
                    }
                    dataGridView3.Visible = true;
                }
                else
                {
                    MessageBox.Show("Несовпадение размерностей");
                }
            }
            return dataGridView3;
        }
        public static double[][] GridToArray(DataGridView dataGridView)
        {
            double[][] array = new double[dataGridView.RowCount][];
            for (int i =0; i < dataGridView.RowCount; i++)
            {
                array[i] = new double[dataGridView.ColumnCount];
            }
            for (int i =0; i < dataGridView.RowCount; i++)
            {
                for (int j = 0; j < dataGridView.ColumnCount; j ++)
                {
                    array[i][j] = int.Parse(dataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }
            return array;
        }
        public static DataGridView ArrayToGrid(double[][] array, DataGridView dataGridView, int n, int m)
        {
            dataGridView.RowCount = n;
            dataGridView.ColumnCount = m;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dataGridView.Rows[i].Cells[j].Value = array[i][j];
                }
            }
            return dataGridView;
        }
        public static DataGridView MatrixInversion(DataGridView dataGridView1, DataGridView dataGridView3)
        {
            if (DoCheckVoid(dataGridView3))
            {
                double[][] array = MatrixCalculator.GridToArray(dataGridView1);
                double[][] inverse = InversingHelp.MatrixInverse(array);
                dataGridView3 = ArrayToGrid(inverse, dataGridView3, dataGridView1.RowCount, dataGridView1.ColumnCount);
                dataGridView3.Visible = true;
            }
            return dataGridView3;
        }
        public static DataGridView DoNotNull(DataGridView dataGridView)
        {
            for (int i =0; i < dataGridView.RowCount; i ++)
            {
                for (int j =0; j < dataGridView.ColumnCount; j ++)
                {
                    dataGridView.Rows[i].Cells[j].Value = 0;
                }
            }
            return dataGridView;
        }
        public static DataGridView MatrixMul(DataGridView dataGridView1, DataGridView dataGridView2, DataGridView dataGridView3)
        {
            if(DoCheckVoid(dataGridView1) && DoCheckVoid(dataGridView2))
            {
                if (dataGridView1.ColumnCount == dataGridView2.RowCount)
                {
                    dataGridView3.ColumnCount = dataGridView1.ColumnCount;
                    dataGridView3.RowCount = dataGridView2.RowCount;
                    dataGridView3 = DoNotNull(dataGridView3);
                    for (int i = 0; i < dataGridView1.RowCount; i++)
                    {
                        for (int j = 0; j < dataGridView2.ColumnCount; j++)
                        {
                            for (int m = 0; m < dataGridView2.RowCount; m++)
                            {

                                dataGridView3.Rows[i].Cells[j].Value = int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()) + int.Parse(dataGridView1.Rows[i].Cells[m].Value.ToString()) * int.Parse(dataGridView2.Rows[m].Cells[j].Value.ToString());
                                //MessageBox.Show((int.Parse(dataGridView3.Rows[i].Cells[j].Value.ToString()) + int.Parse(dataGridView3.Rows[i].Cells[m].Value.ToString()) * int.Parse(dataGridView2.Rows[m].Cells[j].Value.ToString())).ToString());
                            }
                        }
                    }
                    dataGridView3.Visible = true;
                }
            }
    
            return dataGridView3;
        }
        public static DataGridView MatrixEquals(DataGridView dataGridView1, DataGridView dataGridView2, DataGridView dataGridView3)
        {

            return dataGridView3;
        }
    }
}
