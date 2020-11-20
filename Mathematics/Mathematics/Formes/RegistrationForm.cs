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
namespace Mathematics
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }
        public OleDbConnection connection;
        public OleDbCommand command;
        public OleDbDataReader reader;
        private void button1_Click(object sender, EventArgs e)
        {
            connection = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0;Data Source=MainDB.mdb;Persist Security Info=False;");
            connection.Open();
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM Users where UserLogin='" + textBox1.Text + "'";
            reader = command.ExecuteReader();
            while (reader.Read())
            {

                    MessageBox.Show("Аккаунт с таким логином уже существует");
                    return;
                
            }
            connection.Close();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into users([UserLogin],[UserPass],[UserName],[UserStatus]) values(@Login,@Pass,@Name,@Status)";
            command.Parameters.AddWithValue("@Login", textBox1.Text);
            command.Parameters.AddWithValue("@Pass", textBox2.Text);
            command.Parameters.AddWithValue("@Name", textBox3.Text);
            if (checkBox1.Checked)
            command.Parameters.AddWithValue("@Status", "Teacher");
            else command.Parameters.AddWithValue("@Status", "User");
            command.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show("Пользователь добавлен успешно");
            this.Close();
            
        }
    }
}
