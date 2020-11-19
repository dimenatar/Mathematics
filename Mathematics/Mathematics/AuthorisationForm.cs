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
    public partial class AuthorisationForm : Form
    {
        public AuthorisationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            mainForm.ShowDialog();
        }
    }
}
