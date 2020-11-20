using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Mathematics.Formes;
namespace Mathematics.Classes
{
    public class EquLoader
    {
        private Label[] LabelMas = new Label[5];
        private TextBox[] TextMas = new TextBox [5];
        private int amountLabel = 0;
        private int amountText = 0;
        public void LoadCos(Form form)
        {
            LabelMas[0] = new Label();
            LabelMas[0].Text = "Cos(";
            LabelMas[0].Location = new System.Drawing.Point(50, 50);
            form.Controls.Add(LabelMas[0]);

            TextMas[0] = new TextBox();
            TextMas[0].Width = 45;
            TextMas[0].Location = new System.Drawing.Point(150, 50);
            form.Controls.Add(TextMas[0]);

            LabelMas[1] = new Label();
            LabelMas[1].Text = "-";
            LabelMas[1].Width = 45;
            LabelMas[1].Location = new System.Drawing.Point(230, 50);
            form.Controls.Add(LabelMas[1]);

            TextMas[1] = new TextBox();
            TextMas[1].Width = 45;
            TextMas[1].Location = new System.Drawing.Point(280, 50);
            form.Controls.Add(TextMas[1]);

            amountLabel = 2;
            amountText = 2;
        }
    }
}
