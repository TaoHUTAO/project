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
    public partial class Form3 : Form
    {
        DataSet ds;
        OleDbDataAdapter adapter;
        OleDbCommandBuilder commandBuilder;
        public static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= C:/Users/user/Desktop/HX/HZChTO2.0/BD.mdb;";
        string sql = "SELECT * FROM  Инфо_по_предметам";

        public Form3()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            
                        OleDbConnection connection = new OleDbConnection(connectionString);

            connection.Open();
            adapter = new OleDbDataAdapter(sql, connection);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection dbConnection = new OleDbConnection(connectionString);
            dbConnection.Open();
            string secondName = textBox1.Text;
            label2.Text = $"Отметки учащегося {secondName}";
            string quary = $"Select id_студента FROM таблица1 WHERE Фамилия = '{secondName}'";
            OleDbCommand max = new OleDbCommand(quary, dbConnection);
            string nameTwo = max.ExecuteScalar().ToString();
            int all = Convert.ToInt32(nameTwo);
            dbConnection.Close();
            string quarySecond = $"Select id_Студента, №1, №2, №3, №4, Зачет№1, Зачет№2, Зачет№3, Зачет№4, Средний_бал FROM Инфо_по_предметам WHERE ID_Студента = {all}";

            dbConnection.Open();
            adapter = new OleDbDataAdapter(quarySecond, dbConnection);

            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            dbConnection.Close();
        }

        private void B1_Click(object sender, EventArgs e)
        {
            Form4 frm2 = new Form4();
            frm2.Show();
            this.Close();


        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            //Проверим данные в таблицы
            if (dataGridView1.Rows[index].Cells[0].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();

            //Создаем соеденение

            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = "DELETE FROM Таблица1 WHERE ID_Студента = " + id;//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные удалены!", "Внимание!");
                //Удаляем данные из таблицы в форме
                dataGridView1.Rows.RemoveAt(index);
            }

            //Закрываем соеденение с БД
            dbConnection.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите одну строку!", "Внимание!");
                return;
            }

            //Запомним выбранную строку
            int index = dataGridView1.SelectedRows[0].Index;

            if (dataGridView1.Rows[index].Cells[0].Value == null ||
                dataGridView1.Rows[index].Cells[1].Value == null ||
                dataGridView1.Rows[index].Cells[2].Value == null ||
                dataGridView1.Rows[index].Cells[3].Value == null ||
                dataGridView1.Rows[index].Cells[4].Value == null ||
                dataGridView1.Rows[index].Cells[5].Value == null ||
                dataGridView1.Rows[index].Cells[6].Value == null ||
                dataGridView1.Rows[index].Cells[7].Value == null ||
                dataGridView1.Rows[index].Cells[8].Value == null ||
                dataGridView1.Rows[index].Cells[9].Value == null)
            {
                MessageBox.Show("Не все данные введены!", "Внимание!");
                return;
            }

            //Считаем данные
            string id = dataGridView1.Rows[index].Cells[0].Value.ToString();
            string fam = dataGridView1.Rows[index].Cells[1].Value.ToString();
            string name = dataGridView1.Rows[index].Cells[2].Value.ToString();
            string group = dataGridView1.Rows[index].Cells[3].Value.ToString();
            string kurs = dataGridView1.Rows[index].Cells[4].Value.ToString();
            string avg = dataGridView1.Rows[index].Cells[5].Value.ToString();
            string spec = dataGridView1.Rows[index].Cells[6].Value.ToString();
            string alol = dataGridView1.Rows[index].Cells[7].Value.ToString();
            string opa = dataGridView1.Rows[index].Cells[8].Value.ToString();
            string opal = dataGridView1.Rows[index].Cells[8].Value.ToString();

            //Создаем соеденение

            OleDbConnection dbConnection = new OleDbConnection(connectionString);//создаем соеденение

            //Выполянем запрос к БД
            dbConnection.Open();//открываем соеденение
            string query = $"UPDATE Инфо_по_предметам SET №1={fam},№2={name}, №3={group}, №4= {kurs},ОКР={avg}, Зачет№1={spec}, Зачет№2 = {alol}, Зачет№3 = {opa} WHERE ID_Студента = " + id;//строка запроса
            OleDbCommand dbCommand = new OleDbCommand(query, dbConnection);//команда

            //Выполняем запрос
            if (dbCommand.ExecuteNonQuery() != 1)
                MessageBox.Show("Ошибка выполнения запроса!", "Ошибка!");
            else
            {
                MessageBox.Show("Данные изменены!", "Внимание!");
            }

            //Закрываем соеденение с БД
            dbConnection.Close();
        }
    }
}
