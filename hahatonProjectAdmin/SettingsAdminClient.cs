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
    public partial class SettingsAdminClient : Form
    {
        public SettingsAdminClient()
        {
            InitializeComponent();
        }

        private void SettingsAdminClient_Load(object sender, EventArgs e)
        {
            if (Program.IF.KeyExists("PlanSettings", "Number"))
            {
                TBNumber.Text = Program.IF.ReadINI("PlanSettings", "Number");
            }
            if (Program.IF.KeyExists("PlanSettings", "Workplaces"))
            {
                TBWorkplaces.Text = Program.IF.ReadINI("PlanSettings", "Workplaces");
            }
            if (Program.IF.KeyExists("PlanSettings", "Proceeds"))
            {
                TBProceeds.Text = Program.IF.ReadINI("PlanSettings", "Proceeds");
            }
            if (Program.IF.KeyExists("PlanSettings", "Proceeds1"))
            {
                TBProceeds1.Text = Program.IF.ReadINI("PlanSettings", "Proceeds1");
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {



            if (Program.IF.KeyExists("PlanSettings", "Number"))
            {
                TBNumber.Text = Program.IF.ReadINI("PlanSettings", "Number");
            }
            if (Program.IF.KeyExists("PlanSettings", "Workplaces"))
            {
                TBWorkplaces.Text = Program.IF.ReadINI("PlanSettings", "Workplaces");
            }
            if (Program.IF.KeyExists("PlanSettings", "Proceeds"))
            {
                TBProceeds.Text = Program.IF.ReadINI("PlanSettings", "Proceeds");
            }
            if (Program.IF.KeyExists("PlanSettings", "Proceeds1"))
            {
                TBProceeds1.Text = Program.IF.ReadINI("PlanSettings", "Proceeds1");
            }
        }
    }
}
