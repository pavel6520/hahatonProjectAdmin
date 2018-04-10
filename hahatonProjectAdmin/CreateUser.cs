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
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void CreateUserForm_Load(object sender, EventArgs e)
        {
            TableIINN.Rows.Add();
        }

        private void Bgenerate_Click(object sender, EventArgs e)
        {
            TBpass.Text = "1234";
        }

        private void AddTableLine_Click(object sender, EventArgs e)
        {
            TableIINN.Rows.Add();
        }

        private void DeleteTableLine_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in TableIINN.SelectedRows)
            {
                TableIINN.Rows.Remove(row);
            }
            if(TableIINN.RowCount == 0)
            {
                TableIINN.Rows.Add();
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
            //Добавить проверку корректности логина

            for (int i = 0; i < TableIINN.RowCount; i++)
            {
                if(TableIINN.Rows[i].Cells[0].Value == null || TableIINN.Rows[i].Cells[1].Value == null)
                {
                    LErrTable.Show();
                    return;
                }
            }
            LErrTable.Hide();
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось подключится к базе данных.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MySqlCommand com;
            MySqlDataReader readed;
            try
            {
                com = new MySqlCommand("select distinct User from mysql.user", Program.ConnectForm.conn);
                readed = com.ExecuteReader();

                while (readed.Read())
                {
                    if (TBlogin.Text == readed[0].ToString())
                    {
                        LerrLoginExist.Show();
                        Program.ConnectForm.conn.Close();
                        return;
                    }
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ошибка доступа.");
                return;
            }
            LerrLoginExist.Hide();

            try
            {
                for (int i = 0; i < TableIINN.RowCount; i++)
                {
                    com = new MySqlCommand(
                        "CREATE TABLE project.`" + TableIINN.Rows[i].Cells[0].Value + "` (" +
                        "Date date DEFAULT NULL, " +
                        "FM1 int(11) DEFAULT NULL, " +
                        "FM2 int(11) DEFAULT NULL, " +
                        "FM3 decimal(10, 0) DEFAULT NULL, " +
                        "GF1 int(11) DEFAULT NULL, " +
                        "GF2 int(11) DEFAULT NULL, " +
                        "GF3 decimal(10, 0) DEFAULT NULL, " +
                        "CKR1 int(11) DEFAULT NULL, " +
                        "CKR2 int(11) DEFAULT NULL, " +
                        "CKR3 decimal(10, 0) DEFAULT NULL, " +
                        "CPP1 int(11) DEFAULT NULL, " +
                        "CPP2 int(11) DEFAULT NULL, " +
                        "CPP3 decimal(10, 0) DEFAULT NULL, " +
                        "CE1 int(11) DEFAULT NULL, " +
                        "CE2 int(11) DEFAULT NULL, " +
                        "CE3 decimal(10, 0) DEFAULT NULL);",
                        Program.ConnectForm.conn);
                    //Отправить команду
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show("Ошибка доступа.");
                return;
            }


            Program.ConnectForm.conn.Close();
        }
    }
}
