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
                        if (int.Parse(dataGridView1.Rows[i].Cells[j].Value.ToString()) != int.Parse(dataGridView2.Rows[i].Cells[j].Value.ToString()))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            return false;
        }

        private Label CreateQuestionLabel(string function)
        {
            Label QuestionLabel = new Label();
            QuestionLabel.Location = new Point(50,50);
            QuestionLabel.Font = new Font ("Microsoft Sans Serif", 20);
            QuestionLabel.Text = "Вопрос номер " + QuestionCounter.ToString() + " : " + NowRandomComponent.ToString() + ", " + function;
            QuestionLabel.Size = new Size(1100, 150);
            QuestionLabel.ForeColor = Color.Blue;
            return QuestionLabel;
        }
        private void CheckCorrectness()
        {
            switch(NowRandomComponent.ToString())
            {
                case "Матрицы":
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
                case "Уравнения":
                    {
                        if (EquChecker != 4)
                        {
                            if (AnswerText.Text == NewtonCalculations.GetRoot(NewtonCalculations.f, NewtonCalculations.fdX, FirstB, SecondB, koef1).ToString()) CorrectCount++;
                        }
                        else
                        {

                        }
                        break;
                    }

            }
        }
        public enum Component
        {
            Матрицы,
            Уравнения,
            Интегралы
        }
        public enum MatrixFunctions
        {
            Sub,
            Mul,
            Inverse,
            Gauss
        }
        private Random random = new Random();
        private Component PrevRandomComponent;
        private Component NowRandomComponent;
        private int QuestionCounter = 0;
        private int CorrectCount = 0;
        private MatrixFunctions NowRandomMatrixFunction;
        private DataGridView[] dataGridViews;
        private double FirstB = 1;
        private double SecondB = 1;
        private double koef1 = 0;
        private double koef2 = 0;
        private double koef3 = 0;
        private double koef4 = 0;
        private double EquChecker = 0;
        private int NowEquFunction;
        private TextBox AnswerText;
        Label QuestionLabel;
        private void BuildNextRandom()
        {
            NowRandomComponent = (Component)random.Next(0, 2);
            
            switch (NowRandomComponent.ToString())
            {
                
                case "Матрицы":
                    {
                        NowRandomMatrixFunction = (MatrixFunctions)random.Next(0, 2);
                        switch (NowRandomMatrixFunction.ToString())
                        {
                            case "Sub":
                                {
                                    dataGridViews = new DataGridView[3];
                                    dataGridViews = MatrixBuilder.BuildDefaultThreeMatrix(random.Next(1, 6), random.Next(1, 6), dataGridViews);
                                    QuestionLabel = CreateQuestionLabel("Вычитение");
                                    Controls.Add(QuestionLabel);
                                    PrevRandomComponent = 0;
                                    InitialyzeComponents(dataGridViews);
                                    break;
                                }
                            case "Mul":
                                {
                                    dataGridViews = new DataGridView[3];
                                    int Count = random.Next(1, 6);
                                    dataGridViews = MatrixBuilder.BuildDefaultThreeMatrix(Count, Count, dataGridViews);
                                    QuestionLabel = CreateQuestionLabel("Умножение");
                                    Controls.Add(QuestionLabel);
                                    PrevRandomComponent = 0;
                                    InitialyzeComponents(dataGridViews);
                                    break;
                                }
                                
                        }
                        break;
                    }
                case "Уравнения":
                    {
                        NowEquFunction = random.Next(0, 0);
                        FirstB = random.Next(-10, 0);
                        SecondB = random.Next(0, 11);
                        switch (NowEquFunction)
                        {
                            case 0:
                                {
                                    koef1 = random.Next(-1, 10);
                                    AnswerText = CreateTextBox();
                                    Controls.Add(AnswerText);
                                    QuestionLabel = CreateQuestionLabel("Cos(x-" +koef1 + "). Границы: " + FirstB + ", " + SecondB );
                                    Controls.Add(QuestionLabel);
                                    PrevRandomComponent = (Component)1;
                                    break;
                                }
                            //case 2:
                            //    {

                            //    }
                            //case 3:
                            //    {

                            //    }
                            //case 4:
                            //    {

                            //    }
                        }
                        break;
                    }

            }
            


            QuestionCounter++;
            
        }
        private TextBox CreateTextBox()
        {
            MessageBox.Show("текст бокс");
            TextBox textBox = new TextBox();
            textBox.Location = new Point(200, 200);
            textBox.Font = new Font("Microsoft Sans Serif", 20);
            textBox.Text = "";
            return textBox;
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
                switch (PrevRandomComponent.ToString())
                {
                    case "Матрицы":
                        {
                            DestroyMatrix();
                            Controls.Remove(QuestionLabel);
                            break;
                        }
                    case "Уравнения":
                        {
                            Controls.Remove(QuestionLabel);
                            Controls.Remove(AnswerText);
                            break;
                        }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (QuestionCounter != 0)
            {
                CheckCorrectness();
                DestroyPrevRandom();
            }
            MessageBox.Show(CorrectCount.ToString());
            BuildNextRandom();
        }
    }
}
