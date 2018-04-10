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
    public partial class SettingsForm : Form
    {
        /*private bool TBipB;
        private bool TBportB;
        private bool TBdatabaseB;*/

        public SettingsForm()
        {
            InitializeComponent();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            // if (TBip.Text.Length == 0 && TBdatabase.Text.Length == 0 && TBport.Text.Length == 0)
            if (TBip.Text.Length == 0)
            {
                LipErr.Show();
            }
            else
            {
                LipErr.Hide();
            }
            if (TBdatabase.Text.Length == 0)
            {
                LdbErr.Show();
            }
                else
            {
                LdbErr.Hide();
            }
            if (TBport.Text.Length == 0)
            {
                LportErr.Show();
            }
            else
            {
                LportErr.Hide();
            }

                if (TBip.Text.Length != 0 && TBdatabase.Text.Length != 0 && TBport.Text.Length != 0)
            {
                Program.IF.WriteINI("ConnSett", "Adress", TBip.Text);
                Program.IF.WriteINI("ConnSett", "DBname", TBdatabase.Text);
                Program.IF.WriteINI("ConnSett", "Port", TBport.Text);
                this.Close();
            }
            /*else
            {
                MessageBox.Show("Несколько полей пусты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            if(Program.IF.KeyExists("ConnSett", "Adress"))
            {
                TBip.Text = Program.IF.ReadINI("ConnSett", "Adress");
            }
            if (Program.IF.KeyExists("ConnSett", "DBname"))
            {
                TBdatabase.Text = Program.IF.ReadINI("ConnSett", "DBname");
            }
            if (Program.IF.KeyExists("ConnSett", "Port"))
            {
                TBport.Text = Program.IF.ReadINI("ConnSett", "Port");
            }
            /*TBipB = TBip.Text.Length != 0;
            TBportB = TBport.Text.Length != 0;
            TBdatabaseB = TBdatabase.Text.Length != 0;
            //BSave.Enabled = TBipB && TBportB && TBdatabaseB;*/
        }

        private void TBip_TextChanged(object sender, EventArgs e)
        {
            //TBipB = TBip.Text.Length != 0;
            //BSave.Enabled = TBipB && TBportB && TBdatabaseB;
        }

        private void TBport_TextChanged(object sender, EventArgs e)
        {
            //TBportB = TBport.Text.Length != 0;
            //BSave.Enabled = TBipB && TBportB && TBdatabaseB;
        }

        private void TBdatabase_TextChanged(object sender, EventArgs e)
        {
            //TBdatabaseB = TBdatabase.Text.Length != 0;
            //BSave.Enabled = TBipB && TBportB && TBdatabaseB;
        }
    }
}
