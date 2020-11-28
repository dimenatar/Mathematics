using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Classes;
namespace Mathematics.Formes
{
    public partial class TestForm : Form
    {
        public TestForm()
        {
            InitializeComponent();
        }
        private bool CheckIdentityMatrix(DataGridView dataGridView1, DataGridView dataGridView2)
        {
            if (dataGridView1.RowCount == dataGridView2.RowCount && dataGridView1.ColumnCount == dataGridView2.ColumnCount)
            {
                for (int i =0; i < dataGridView1.RowCount; i ++)
                {
                    for (int j =0; j < dataGridView1.ColumnCount; j ++)
                    {
                        if (dataGridView1.Rows[i].Cells[j].Value != dataGridView2.Rows[i].Cells[j].Value)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }
        private void CheckCorrectness()
        {
            switch(NowRandomComponent.ToString())
            {
                case "Matrix":
                    {
                        switch(NowRandomMatrixFunction.ToString())
                        {
                            case "Sub":
                                {
                                    DataGridView CheckDataGrid = new DataGridView();
                                    CheckDataGrid.RowCount = dataGridViews[0].RowCount;
                                    CheckDataGrid.ColumnCount = dataGridViews[0].ColumnCount;
                                    CheckDataGrid = MatrixCalculator.MatrixSub(dataGridViews[0], dataGridViews[1], CheckDataGrid);
                                    if (CheckIdentityMatrix(CheckDataGrid, dataGridViews[2])) CorrectCount++;
                                    break;
                                }
                            case "Mul":
                                {
                                    DataGridView CheckDataGrid = new DataGridView();
                                    CheckDataGrid.RowCount = dataGridViews[0].RowCount;
                                    CheckDataGrid.ColumnCount = dataGridViews[0].ColumnCount;
                                    CheckDataGrid = MatrixCalculator.MatrixMul(dataGridViews[0], dataGridViews[1], CheckDataGrid);
                                    if (CheckIdentityMatrix(CheckDataGrid, dataGridViews[2])) CorrectCount++;
                                    break;
                                }
                        }
                        break;
                    }
            }
        }
        public enum Component
        {
            Matrix,
            Equalations,
            Integrals
        }
        public enum MatrixFunctions
        {
            Sub,
            Inverse,
            Mul,
            Gauss
        }
        private Random random = new Random();
        private Component PrevRandomComponent;
        private Component NowRandomComponent;
        private int QuestionCounter = 0;
        private int CorrectCount = 0;
        private MatrixFunctions NowRandomMatrixFunction;
        private DataGridView[] dataGridViews;
        private void BuildNextRandom()
        {
            NowRandomComponent = (Component)random.Next(0, 0);
            switch (NowRandomComponent)
            {
                case 0:
                    {
                        NowRandomMatrixFunction = (MatrixFunctions)random.Next(0, 1);
                        switch (NowRandomMatrixFunction.ToString())
                        {
                            case "Sub":
                                {
                                    dataGridViews = new DataGridView[3];
                                    dataGridViews = MatrixBuilder.BuildDefaultThreeMatrix(random.Next(1, 6), random.Next(1, 6), dataGridViews);
                                    break;
                                }
                            case "Mul":
                                {
                                    dataGridViews = new DataGridView[3];
                                    dataGridViews = MatrixBuilder.BuildDefaultThreeMatrix(random.Next(1, 6), random.Next(1, 6), dataGridViews);
                                    break;
                                }
                        }

                        InitialyzeComponents(dataGridViews);

                        QuestionCounter++;
                        PrevRandomComponent = 0;
                        break;
                    }
                    
            }
        }
        private void DestroyMatrix()
        {
            for (int i =0; i < dataGridViews.Length; i ++)
            {
                Controls.Remove(dataGridViews[i]);
            }
            
        }
        private void InitialyzeComponents(params dynamic[] T)
        {
            for (int i =0; i < T.Length; i ++)
            {
                this.Controls.Add(T[i]);
            }

        }
        private void DestroyPrevRandom()
        {
            if (QuestionCounter!=0)
            {
                switch (PrevRandomComponent)
                {
                    case 0:
                        {
                            DestroyMatrix();
                            break;
                        }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            DestroyPrevRandom();
            BuildNextRandom();
        }
    }
}
