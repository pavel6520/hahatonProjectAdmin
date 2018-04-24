using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hahatonProjectAdmin
{
    public partial class DeleteUserForm : Form
    {
        public DeleteUserForm()
        {
            InitializeComponent();
        }

        private void DeleteUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (MySqlQueryException ex)
            {
                MessageBox.Show($"Не удалось подключится к базе данных.\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            MySqlCommand com;
            MySqlDataReader reader;
            User_1[] Mas_Users = null;
            try
            {
                com = new MySqlCommand("select * from project.login_inn order by login", Program.ConnectForm.conn);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref Mas_Users, (Mas_Users == null ? 1 : Mas_Users.Length + 1));
                    Mas_Users[Mas_Users.Length - 1].login = reader[0].ToString();
                    Mas_Users[Mas_Users.Length - 1].inn = reader[1].ToString();
                    Mas_Users[Mas_Users.Length - 1].comp_name = reader[2].ToString();
                }
                reader.Close();
            }
            catch(MySqlException ex)
            {                
                throw new MySqlQueryException(ex.Message);
            }

            for(int i = 0; i < Mas_Users.Length - 1; i++)
            {
                DGV_archive.Rows.Add(Mas_Users[i].login, Mas_Users[i].inn, Mas_Users[i].comp_name);
            }

            Program.ConnectForm.conn.Close();
        }

        private void BTSearch_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < DGV_archive.RowCount - 1; i++)
            {
                DGV_archive.Rows[i].Visible = (DGV_archive.Rows[i].Cells[0].Value.ToString() == TB_query.Text) 
                    || (DGV_archive.Rows[i].Cells[1].Value.ToString() == TB_query.Text)
                    || (DGV_archive.Rows[i].Cells[2].Value.ToString() == TB_query.Text);

                if (TB_query.Text == "")
                    DGV_archive.Rows[i].Visible = true;
            }
        }

        private void DGV_archive_DoubleClick(object sender, EventArgs e)
        {

        }
    }

    public struct User_1
    {
        public string login, inn, comp_name;
    }
}
