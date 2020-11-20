using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mathematics
{
    
    public partial class MatrixForm : Form
    {



        private int FirstB = 0;
        private int SecondB = 2;
        private Random random;
        MatrixAnswerForm matrixAnswerForm = new MatrixAnswerForm();
        public MatrixForm()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.TextLength != 0 && textBox2.TextLength != 0)
            {
                dataGridView1.RowCount = int.Parse(textBox1.Text);
                dataGridView1.ColumnCount = int.Parse(textBox2.Text);
                dataGridView1.Visible = true;
               // dataGridView1.EditMode;
            }
        }
        private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >=49 && e.KeyChar <=53 && textBox1.TextLength == 0)|| e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 49 && e.KeyChar <= 53 && textBox2.TextLength == 0) || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 49 && e.KeyChar <= 53 && textBox3.TextLength == 0) || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 49 && e.KeyChar <= 53 && textBox4.TextLength == 0) || e.KeyChar == (char)Keys.Back)
            {

            }
            else
            {
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.TextLength != 0 && textBox4.TextLength != 0)
            {
                dataGridView2.RowCount = int.Parse(textBox3.Text);
                dataGridView2.ColumnCount = int.Parse(textBox4.Text);
                dataGridView2.Visible = true;
            }
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            DataGridViewTextBoxEditingControl tb = (DataGridViewTextBoxEditingControl)e.Control;
            tb.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
            e.Control.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '-' || char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else e.Handled = true;
            
        }


        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '-' && textBox7.TextLength == 0))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || (e.KeyChar == '-' && textBox8.TextLength == 0))
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FirstB = int.Parse(textBox7.Text);
            }
            catch (Exception) { }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            try
            {
                SecondB = int.Parse(textBox8.Text);
            }
            catch (Exception) { }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            random = new Random();
            for (int i =0; i < dataGridView1.RowCount; i ++)
            {
                for (int j =0; j < dataGridView1.ColumnCount; j ++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = random.Next(FirstB, SecondB);
                }
            }
            for (int i = 0; i < dataGridView2.RowCount; i++)
            {
                for (int j = 0; j < dataGridView2.ColumnCount; j++)
                {
                    dataGridView2.Rows[i].Cells[j].Value = random.Next(FirstB, SecondB);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dataGridView3 = MatrixCalculator.MatrixSub(dataGridView1, dataGridView2, dataGridView3);
            }
            else if (radioButton2.Checked)
            {
                dataGridView3= MatrixCalculator.MatrixInversion(dataGridView1, dataGridView3);
            }
            else if (radioButton3.Checked)
            {
                dataGridView3 = MatrixCalculator.MatrixMul(dataGridView1, dataGridView2, dataGridView3);
            }
            else if (radioButton4.Checked)
            {
                dataGridView3 = MatrixCalculator.MatrixEquals(dataGridView1, dataGridView2, dataGridView3);
            }
        }
    }
}
