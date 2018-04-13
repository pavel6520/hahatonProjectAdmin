using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace hahatonProjectAdmin
{
    public partial class CreateUserForm : Form
    {
        private string ConnectStr;

        public CreateUserForm(string str)
        {
            InitializeComponent();
            ConnectStr = str;
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
            TableINN.Rows.Add();
        }

        private void Bgenerate_Click(object sender, EventArgs e)
        {
            const string tmp = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ" +
                "abcdefghijklmnopqrstuvwxyz" + "#$&@?%"; //"{#$<^(&*@}?%>"
            string pas = "";


            Random r = new Random();
            for(int i = 1; i < 10; i++)
            {
                pas += tmp[r.Next(0,tmp.Length - 1)];
            }

            TBpass.Text = pas;
        }

        private void AddTableLine_Click(object sender, EventArgs e)
        {
            TableINN.Rows.Add();
        }

        private void DeleteTableLine_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TableINN.SelectedRows)
            {
                TableINN.Rows.Remove(row);
            }
            if(TableINN.RowCount == 0)
            {
                TableINN.Rows.Add();
            }
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if(TBlogin.Text == "")
            {
                LerrLoginIncorrect.Show();
                return;
            }
            LerrLoginIncorrect.Hide();
            //Добавить проверку корректности логина -_

            for (int i = 0; i < TableINN.RowCount; i++)
            {
                if(TableINN.Rows[i].Cells[0].Value == null || TableINN.Rows[i].Cells[1].Value == null)
                {
                    LErrTable.Show();
                    return;
                }
            }
            LErrTable.Hide();
            try
            {
                //Program.ConnectForm.conn = new MySqlConnection(ConnectStr);
                Program.ConnectForm.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подключится к базе данных.\n" + ex, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MySqlCommand com;
            MySqlDataReader readed;
            try
            {
                //Проверка существования логина
                com = new MySqlCommand("select distinct User from mysql.user", Program.ConnectForm.conn);
                readed = com.ExecuteReader();
                while (readed.Read())
                {
                    if (TBlogin.Text == readed[0].ToString())
                    {
                        LerrLoginExist.Show();
                        readed.Close();
                        Program.ConnectForm.conn.Close();
                        return;
                    }
                }
                readed.Close();
                LerrLoginExist.Hide();

                //Проверка существования таблицы ИНН
                com = new MySqlCommand("show tables from project", Program.ConnectForm.conn);
                readed = com.ExecuteReader();
                while (readed.Read())
                {
                    for (int i = 0; i < TableINN.RowCount; i++)
                    {
                        if (TableINN.Rows[i].Cells[0].Value.ToString() == readed[0].ToString())
                        {
                            MessageBox.Show("ИНН компании " + TableINN.Rows[i].Cells[1].Value.ToString() + " уже зарегистрирован.", "ИНН занят", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            readed.Close();
                            Program.ConnectForm.conn.Close();
                            return;
                        }
                    }
                }
                readed.Close();

                //Создание пользователя и выдача права на чтение project.login_inn
                com = new MySqlCommand("create user `" + TBlogin.Text + "`@'%' identified by '" + TBpass.Text + "';" +
                    "grant select on project.login_inn to `" + TBlogin.Text + "`@`%`;"
                    , Program.ConnectForm.conn);
                com.ExecuteNonQuery();
                
                for (int i = 0; i < TableINN.RowCount; i++)
                {
                    //создание таблицы с именем ИНН для отчетов и выдача прав на чтение и дополнение
                    com = new MySqlCommand(
                        "CREATE TABLE project.`" + TableINN.Rows[i].Cells[0].Value + "` (" +
                        "Date date DEFAULT NULL, " + 
                        "FM1 int(11) DEFAULT NULL, FM2 int(11) DEFAULT NULL, FM3 decimal(10, 6) DEFAULT NULL, " +
                        "GF1 int(11) DEFAULT NULL, GF2 int(11) DEFAULT NULL, GF3 decimal(10, 6) DEFAULT NULL, " +
                        "CKR1 int(11) DEFAULT NULL, CKR2 int(11) DEFAULT NULL, CKR3 decimal(10, 6) DEFAULT NULL, " +
                        "CPP1 int(11) DEFAULT NULL, CPP2 int(11) DEFAULT NULL, CPP3 decimal(10, 6) DEFAULT NULL, " +
                        "CE1 int(11) DEFAULT NULL, CE2 int(11) DEFAULT NULL, CE3 decimal(10, 6) DEFAULT NULL) DEFAULT CHARSET=utf8;" +
                        "grant select, insert on project.`" + TableINN.Rows[i].Cells[0].Value + "` to `" + TBlogin.Text + "`@'%';" +
                        "insert into project.login_inn values('" + TBlogin.Text + "', '" + TableINN.Rows[i].Cells[0].Value + "', '" + TableINN.Rows[i].Cells[1].Value.ToString() + "')",
                        Program.ConnectForm.conn);
                    com.ExecuteNonQuery();
                }
                Program.ConnectForm.conn.Close();
            }
            catch (MySqlException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("Ошибка выполнения запроса. Обратитесь к администратору.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Успешно добавлено.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void CreateUserForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TBlogin.Focused)
            {
                if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123)
                && (e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 95)
                    e.Handled = true;
            }
            else if (TableINN.CurrentCell.ColumnIndex == 0)
            {
                if (!Program.Is_dig(e.KeyChar) && e.KeyChar != 8)
                    e.Handled = true;
            }
            else if (TableINN.CurrentCell.ColumnIndex == 1)
            {
                if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123)
                && (e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8
                && (e.KeyChar <= 1039 || e.KeyChar >= 1104) && e.KeyChar != 1025 && e.KeyChar != 1105
                && e.KeyChar != 34 && e.KeyChar != 32 && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 95)
                    e.Handled = true;
            }
        }
    }
}
