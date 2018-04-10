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
            CreateUser = new CreateUserForm(ConnectStr);
            CreateUser.Show();
            Enabled = false;
            CreateUser.FormClosing += (obj, arg) =>
            {
                Location = CreateUser.Location;
                Activate();
                Enabled = true;
            };
            CreateUser.Location = this.Location;
        }
    }
}
