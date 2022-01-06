using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HZChTO2._0
{
    public partial class Form2 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:/Users/user/Desktop/HX/HZChTO2.0/BD.mdb;";

        private OleDbConnection myConnection;
        public string query;
        public string queryMax;

        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm2 = new Form1();
            frm2.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox3.Text && textBox2.Text != "")
            {
                queryMax = "Select MAX(id_пользователя) FROM Users";
                OleDbCommand max = new OleDbCommand(queryMax, myConnection);
                int maxIndex = Convert.ToInt32(max.ExecuteScalar().ToString());

                maxIndex++;
                query = "INSERT INTO Users (id_пользователя, Логин, Пароль) " + "VALUES (" + maxIndex + ", '" + textBox2.Text + "', " + "'" + textBox1.Text+ "')";

                OleDbCommand cmd = new OleDbCommand(query, myConnection);
                cmd.ExecuteNonQuery();

                MessageBox.Show($"Успешная регистрацияя, {textBox1.Text}");

                Form1 frm2 = new Form1();
                this.Hide();
                frm2.Show();
            }

            else MessageBox.Show("Пароли не совпадают");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
    
}
