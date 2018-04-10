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

        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void BCreateUser_Click(object sender, EventArgs e)
        {
            CreateUser = new CreateUserForm();
            CreateUser.Show();
            Enabled = false;
            CreateUser.FormClosing += (obj, arg) =>
            {
                Location = CreateUser.Location;
                Enabled = true;
            };
            CreateUser.Location = this.Location;
        }
    }
}
