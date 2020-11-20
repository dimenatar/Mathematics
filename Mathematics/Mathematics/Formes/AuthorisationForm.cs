using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace Mathematics
{

    public partial class AuthorisationForm : Form
    {
        public OleDbConnection connection;
        public OleDbCommand command;
        public OleDbDataReader reader;
        public AuthorisationForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool isFound = false;
            connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=MainDB.mdb;Persist Security Info=False;");
            connection.Open();
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Users where UserLogin='"+ textBox1.Text+"'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader[2].ToString() == textBox2.Text)
                {
                    isFound = true;
                    User.status = reader[4].ToString();
                }
            }
            connection.Close();
            if (!isFound)
            {
                MessageBox.Show("Неправильный пароль");
            }
            else
            { 
                MainForm mainForm = new MainForm();
                mainForm.ShowDialog();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.ShowDialog();
        }
    }
}
