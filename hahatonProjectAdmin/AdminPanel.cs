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
    public partial class AdminPanelForm : Form
    {
        public CreateUserForm CreateUser;
        private string ConnectStr;

        public AdminPanelForm(string str)
        {
            InitializeComponent();
            ConnectStr = str;
        }

        private void BCreateUser_Click(object sender, EventArgs e)
        {
        }

        private void TSMIuserCreate_Click(object sender, EventArgs e)
        {
            CreateUser = new CreateUserForm(ConnectStr);
            CreateUser.Show();
            TSMIuserCreate.Enabled = false;
            CreateUser.FormClosing += (obj, arg) =>
            {
                CenterToScreen();
                Activate();
                TSMIuserCreate.Enabled = true;
            };
            CreateUser.Location = this.Location;
            DGVinst.Rows[0].Cells[0].Style.BackColor = Color.Green;
        }

        private void AdminPanelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
