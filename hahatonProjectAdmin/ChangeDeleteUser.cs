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
    public partial class ChangeDeleteUserForm : Form
    {
        private void DGVupdate()
        {
            for (int i = 0; i < DGV_archive.RowCount; i++)
            {
                DGV_archive.Rows[i].Visible = DGV_archive.Rows[i].Cells[0].Value.ToString().IndexOf(TB_query.Text) != -1
                    || DGV_archive.Rows[i].Cells[1].Value.ToString().IndexOf(TB_query.Text) != -1
                    || DGV_archive.Rows[i].Cells[2].Value.ToString().IndexOf(TB_query.Text) != -1
                    || TB_query.Text.Length == 0;
            }
        }

        public ChangeDeleteUserForm()
        {
            InitializeComponent();
        }

        private void DeleteUserForm_Load(object sender, EventArgs e)
        {
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (ExceptionShowMessageException ex)
            {
                MessageBox.Show($"Не удалось подключится к базе данных.\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            User[] MasUsers = null;
            try
            {
                MasUsers = AdminPanelForm.GetUserCompanies();
            }
            catch(ExceptionShowMessageException ex)
            {
                MessageBox.Show($"Ошибка загрузки списка пользователей\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
            
            for(int i = 0; i < MasUsers.Length; i++)
            {
                for(int j = 0; j < MasUsers[i].MasCompany.Length; j++)
                {
                    DGV_archive.Rows.Add(MasUsers[i].login, MasUsers[i].MasCompany[j].inn, MasUsers[i].MasCompany[j].comp_name);
                }
            }
            Program.ConnectForm.conn.Close();
        }

        private void BTSearch_Click(object sender, EventArgs e)
        {
            DGVupdate();
        }

        private void TB_query_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                e.Handled = true;
                DGVupdate();
            }
        }

        private void DGV_archive_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show(DGV_archive.SelectedCells[0].Value.ToString()); //Содержимое ячейки
            int ColoumnIndex = DGV_archive.SelectedCells[0].ColumnIndex; //Номер столбца
        }
    }
}
