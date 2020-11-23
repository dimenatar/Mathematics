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
    public partial class NotLinearEqu : Form
    {
        public NotLinearEqu()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                //
            }
        }
        private bool CheckEmptyText(TextBox textBox)
        {
            if (textBox.Text == "") return false;
            else return true;
        }
        private void ShowCos()
        {
            if (CheckEmptyText(textBox2)&& CheckEmptyText (textBox3))
            {
                label1.Text = NewtonCalculations.GetRoot(NewtonCalculations.f, NewtonCalculations.fdX, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox3.Text)).ToString();
            }
        }
        private void ShowPow()
        {
            if (CheckEmptyText(textBox2) && CheckEmptyText(textBox4))
            {
                label1.Text = NewtonCalculations.GetRoot(NewtonCalculations.ff, NewtonCalculations.ffdX, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox4.Text)).ToString();
            }
        }
        private void ShowHer()
        {
            if (CheckEmptyText(textBox1) && CheckEmptyText(textBox2) && CheckEmptyText(textBox5) && CheckEmptyText(textBox6) && CheckEmptyText(textBox7) && CheckEmptyText(textBox8))
            {
                label1.Text = NewtonCalculations.GetRoot(NewtonCalculations.fff, NewtonCalculations.fffdX, int.Parse(textBox1.Text), int.Parse(textBox2.Text), int.Parse(textBox5.Text), int.Parse(textBox6.Text), int.Parse(textBox7.Text), int.Parse(textBox8.Text)).ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                ShowCos();
            }
            else if (radioButton2.Checked)
            {
                ShowPow();
            }
            else if (radioButton3.Checked)
            {
                ShowHer();
            }
            else MessageBox.Show("Выберите функцию");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (CheckEmptyText(textBox3))
                {
                    CurvesDrawer curvesDrawer = new CurvesDrawer();
                    curvesDrawer.sixth = true;
                    curvesDrawer.koef1 = int.Parse(textBox3.Text);
                    curvesDrawer.Show();
                }
            }
            else if (radioButton2.Checked)
            {
                if (CheckEmptyText(textBox4))
                {
                    CurvesDrawer curvesDrawer = new CurvesDrawer();
                    curvesDrawer.fourth = true;
                    curvesDrawer.koef1 = int.Parse(textBox4.Text);
                    curvesDrawer.Show();
                }
            }
            else if (radioButton3.Checked)
            {
                if (CheckEmptyText(textBox5) && CheckEmptyText(textBox6) && CheckEmptyText(textBox7) && CheckEmptyText(textBox8))
                {
                    CurvesDrawer curvesDrawer = new CurvesDrawer();
                    curvesDrawer.fifth = true;
                    curvesDrawer.koef1 = int.Parse(textBox5.Text); 
                    curvesDrawer.koef2 = int.Parse(textBox6.Text); 
                    curvesDrawer.koef3 = int.Parse(textBox7.Text); 
                    curvesDrawer.koef4 = int.Parse(textBox8.Text);
                    curvesDrawer.Show();
                }
            }
        }
    }
}
