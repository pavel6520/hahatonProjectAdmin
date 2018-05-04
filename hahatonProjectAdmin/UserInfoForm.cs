using System;
using System.Windows.Forms;

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
            MessageBox.Show(ChangeDeleteUserForm.SelectedValue);

            for(int i = 0; i < ChangeDeleteUserForm.countUsers; i++)
            {
                for(int j = 0; j < ChangeDeleteUserForm.MasUsers[i].MasCompany.Length; j++)
                {
                    if(ChangeDeleteUserForm.MasUsers[i].login == ChangeDeleteUserForm.SelectedValue)
                    {
                        DGV_Users.Rows.Add(ChangeDeleteUserForm.MasUsers[i].MasCompany[j].inn, ChangeDeleteUserForm.MasUsers[i].MasCompany[j].comp_name);
                    }                    
                }
            }

        }
    }
}
