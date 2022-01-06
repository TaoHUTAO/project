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
    public partial class Form1 : Form
    {
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:/Users/user/Desktop/HX/HZChTO2.0/BD.mdb;";

        private OleDbConnection myConnection;

        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbDataAdapter dataReader = new OleDbDataAdapter("Select Count(*) From Users where Логин ='" + textBox2.Text + "' and Пароль ='" + textBox1.Text + "'", myConnection);
            DataTable dt = new DataTable();
            dataReader.Fill(dt);

            if (dt.Rows[0][0].ToString() == "1")
            {
                Form4 frm2 = new Form4();
                frm2.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Неправильно введённые имя или пароль");
            }
        }
    }
}
