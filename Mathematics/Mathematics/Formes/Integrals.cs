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
    public partial class Integrals : Form
    {
        public Integrals()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label4.Text="Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.f, double.Parse(textBox1.Text), double.Parse(textBox2.Text),hScrollBar1.Value).ToString()));
            }
            else if (radioButton2.Checked)
            {
                label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.ff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value, int.Parse(textBox3.Text)).ToString()));
            }
            else if (radioButton3.Checked) label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.fff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value).ToString()));
            else if (radioButton4.Checked) label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.ffff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value).ToString()));
            else if (radioButton5.Checked) label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.fffff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value).ToString()));
            else
            {

            }
        }

        private void hScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            label3.Text = "Точность: " + hScrollBar1.Value.ToString();
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked) 
            { 
                label7.Visible = true; 
                label5.Visible = false; 
                label6.Visible = false; 
                label8.Visible = false; 
                label9.Visible = false; 
                label10.Visible = false; 
                textBox3.Visible = true;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }

        }

        private void radioButton4_Click(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                label7.Visible = false;
                label5.Visible = false;
                label6.Visible = true;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = true;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
        }

        private void radioButton3_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                label7.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label7.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                label7.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                textBox7.Visible = false;
                textBox8.Visible = false;
            }
        }

        private void Integrals_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
        }
    }
}
