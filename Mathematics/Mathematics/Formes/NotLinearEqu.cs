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
        private EquLoader equLoader = new EquLoader();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                equLoader.LoadCos(this);
            }
        }
    }
}
