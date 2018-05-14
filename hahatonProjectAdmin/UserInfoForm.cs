using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hahatonProjectAdmin
{
    public partial class UserInfoForm : Form
    {

        public UserInfoForm()
        {
            InitializeComponent();
        }        

        private void UserInfoForm_Load(object sender, EventArgs e)
        {
            this.Text = "Пользователь " + ChangeDeleteUserForm.SelectedValue;
            DGV_Users.ContextMenuStrip = contextMenuStrip1;

            MessageBox.Show(ChangeDeleteUserForm.SelectedValue);
            MessageBox.Show(ChangeDeleteUserForm.countUsers.ToString());
            
            for(int i = 0; i < ChangeDeleteUserForm.countUsers; i++)
            {
                MessageBox.Show(ChangeDeleteUserForm.SelectedValue);
                for (int j = 0; j < ChangeDeleteUserForm.MasUsers[i].MasCompany.Length; j++)
                {                    
                    if (ChangeDeleteUserForm.MasUsers[i].login == ChangeDeleteUserForm.SelectedValue)
                    {
                        DGV_Users.Rows.Add(ChangeDeleteUserForm.MasUsers[i].MasCompany[j].inn, ChangeDeleteUserForm.MasUsers[i].MasCompany[j].comp_name);
                    }                    
                }
            }
        }

        private void TSMI_CompDel_Click(object sender, EventArgs e)
        {            
            if(Program.Query("delete from project.login_inn where comp_name = '" + DGV_Users.Rows[DGV_Users.SelectedCells[0].RowIndex].Cells[1].Value.ToString() + "' "))
            {
                MessageBox.Show("Компания " + DGV_Users.Rows[DGV_Users.SelectedCells[0].RowIndex].Cells[1].Value.ToString() + " удалена");
            }

            /*DialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную компанию?", "Удаление компании", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DialogResult == DialogResult.OK)
            {
                MessageBox.Show("Yes");
            }
            else
            {
                return;
            }*/
        }

        private void TSMI_UserDel_Click(object sender, EventArgs e)
        {
            if(Program.Query("drop user" + " '" + ChangeDeleteUserForm.SelectedValue + "'@"))
            {
                MessageBox.Show("Пользователь " + ChangeDeleteUserForm.SelectedValue + " удален");
            }

            /*if(MessageBox.Show("Вы уверены, что хотите удалить выбранного пользователя?", "Удаление пользователя", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
            {
                MessageBox.Show("Yes");
                if (MessageBox.Show("Сохранить отчеты пользователя?", "Сохранение отчетов", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {

                }
                else
                {
                    return;
                }
            }
            else
            {
                return;
            }*/
        }
    }
}
