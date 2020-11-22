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
using System.IO;
namespace Mathematics.Formes
{
    public partial class Integrals : Form
    {
        public Integrals()
        {
            InitializeComponent();
        }
        private bool CheckBorders()
        {
            if (textBox1.Text != "" && textBox2.Text != "")
                return true;
            else return false;
        }
        private void ShowSinuc()
        {
            if (CheckBorders())
                label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.f, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value).ToString()));
            else MessageBox.Show("Введите границы");
        }
        private void ShowXPow()
        {
            if (CheckBorders())
            {
                if (textBox3.Text != "")
                {
                    label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.ff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value, int.Parse(textBox3.Text)).ToString()));
                }
                else MessageBox.Show("Введите коэффициенты");
            }
            else MessageBox.Show("Введите границы");
        }
        private void ShowCosinus()
        {
            if (CheckBorders())
            {
                label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.fff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value).ToString()));
            }
            else MessageBox.Show("Введите границы");
        }
        private void ShowAPow()
        {
            if (CheckBorders())
            {
                if (textBox4.Text != "")
                {
                    label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.ffff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value, int.Parse(textBox4.Text)).ToString()));
                }
                else MessageBox.Show("Введите коэффициенты");
            }
            else MessageBox.Show("Введите границы");
        }
        private void ShowThisShit()
        {
            if (CheckBorders())
            {
                if (textBox5.Text != "" && textBox6.Text != ""&& textBox7.Text != ""&& textBox8.Text != "")
                {
                    label4.Text = "Ответ: " + ((IntegralCalculations.LeftTriangle(IntegralCalculations.fffff, double.Parse(textBox1.Text), double.Parse(textBox2.Text), hScrollBar1.Value, int.Parse(textBox8.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text)).ToString()));
                }
                else MessageBox.Show("Введите коэффициенты");
            }
            else MessageBox.Show("Введите границы");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) ShowSinuc();
            else if (radioButton2.Checked) ShowXPow();
            else if (radioButton3.Checked) ShowCosinus();
            else if (radioButton4.Checked) ShowAPow();
            else if (radioButton5.Checked) ShowThisShit();
            else MessageBox.Show("Ошибка");
            
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
                label2.Text = "(x^a)dx";
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
                label2.Text = "(a^x)dx";
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
                label2.Text = "(cos(x))dx";
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
                label2.Text = "(sin(x))dx";
            }
        }

        private void radioButton5_Click(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                label7.Visible = false;
                label5.Visible = true;
                label6.Visible = false;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = true;
                textBox6.Visible = true;
                textBox7.Visible = true;
                textBox8.Visible = true;
                label2.Text = "(ax^3+bx^2+cx+d)dx";
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == '-')
            {
                e.Handled = false;
            }
            else e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                CurvesDrawer curvesDrawer = new CurvesDrawer();
                curvesDrawer.first = true;
                curvesDrawer.Show();
            }
            else if (radioButton2.Checked)
            {
                if (textBox3.Text != "")
                {
                    CurvesDrawer curvesDrawer = new CurvesDrawer();
                    curvesDrawer.second = true;
                    curvesDrawer.koef1 = int.Parse(textBox3.Text);
                    curvesDrawer.Show();
                }
                else MessageBox.Show("Введите коэффициент");
            }
            else if (radioButton3.Checked)
            {
                CurvesDrawer curvesDrawer = new CurvesDrawer();
                curvesDrawer.third = true;
                curvesDrawer.Show();
            }
            else if (radioButton4.Checked)
            {
                if (textBox4.Text != "")
                {
                    CurvesDrawer curvesDrawer = new CurvesDrawer();
                    curvesDrawer.fourth = true;
                    curvesDrawer.koef1 = int.Parse(textBox4.Text);
                    curvesDrawer.Show();
                }
                else MessageBox.Show("Введите коэффициент");
            }
            else if (radioButton5.Checked)
            {
                if (textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != "" )
                {
                    CurvesDrawer curvesDrawer = new CurvesDrawer();
                    curvesDrawer.fifth = true;
                    curvesDrawer.koef1 = int.Parse(textBox5.Text);
                    curvesDrawer.koef2 = int.Parse(textBox6.Text);
                    curvesDrawer.koef3 = int.Parse(textBox7.Text);
                    curvesDrawer.koef4 = int.Parse(textBox8.Text);
                    curvesDrawer.Show();
                }
                else MessageBox.Show("Введите коэффициент");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label4.Text != "Ваш ответ будет ждать вас здесь")
            {
                File.WriteAllText("IntegralAnswer.txt", "(" + textBox1.Text + "," + textBox2.Text +")" +label1.Text + " " + label2.Text + " = " + label4.Text);
            }
        }
    }
}
