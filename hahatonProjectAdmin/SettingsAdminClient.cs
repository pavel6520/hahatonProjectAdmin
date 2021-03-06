﻿using System;
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
            bool Error = false;
            if (TBNumber.Text.Length == 0)
            {
                Error = true;
                LabelNumberErr.Show();
            }
            else
            {
                LabelNumberErr.Hide();
            }
            if (TBProceeds.Text.Length == 0)
            {
                Error = true;
                LabelProceedsErr.Show();
            }
            else
            {
                LabelProceedsErr.Hide();
            }
            if (TBProceeds1.Text.Length == 0)
            {
                Error = true;
                LabelProceeds1Err.Show();
            }
            else
            {
                LabelProceeds1Err.Hide();
            }
            if (TBWorkplaces.Text.Length == 0)
            {
                Error = true;
                LabelWorkplacesErr.Show();
            }
            else
            {
                LabelWorkplacesErr.Hide();
            }
            if (Error)
            {
                return;
            }
            try
            {
                Program.ConnectForm.AdminPanel.PlanSettingsParam1 = Convert.ToInt32(TBWorkplaces.Text);
                Program.ConnectForm.AdminPanel.PlanSettingsParam2 = Convert.ToDouble(TBNumber.Text);
                Program.ConnectForm.AdminPanel.PlanSettingsParam3 = Convert.ToDouble(TBProceeds.Text);
                Program.ConnectForm.AdminPanel.PlanSettingsParam4 = Convert.ToDouble(TBProceeds1.Text);
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Неверный формат\n" + ex);
                return;
            }
            Program.IF.WriteINI("PlanSettings", "Workplaces", TBWorkplaces.Text);
            Program.IF.WriteINI("PlanSettings", "Number", TBNumber.Text);
            Program.IF.WriteINI("PlanSettings", "Proceeds", TBProceeds.Text);
            Program.IF.WriteINI("PlanSettings", "Proceeds1", TBProceeds1.Text);
            Close();
        }
    }
}
