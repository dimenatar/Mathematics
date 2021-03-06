﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Formes;
namespace Mathematics
{
    public partial class MainForm : Form
    {
        public TestForm testForm = new TestForm();
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MatrixForm matrixForm = new MatrixForm();
            matrixForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NotLinearEqu notLinearEqu = new NotLinearEqu();
            notLinearEqu.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Integrals integrals = new Integrals();
            integrals.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            testForm.ShowDialog();
        }
    }
}
