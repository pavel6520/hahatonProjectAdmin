using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hahatonProjectAdmin
{
    public partial class AdminPanelForm : Form
    {
        public CreateUserForm CreateUser;
        private string ConnectStr;
        private struct Reports
        {
            public string inn, comp_name;
            public DateTime[]date;
            public int[]TBFM1;
            public int[]TBFM2;
            public double[]TBFM3;
            public int[]TBGF1;
            public int[]TBGF2;
            public double[]TBGF3;
            public int[]TBCKR1;
            public int[]TBCKR2;
            public double[]TBCKR3;
            public int[]TBCPP1;
            public int[]TBCPP2;
            public double[]TBCPP3;
            public int[]TBCE1;
            public int[]TBCE2;
            public double[]TBCE3;
        }
        private Reports []MasReports;
        public const bool plan = true;

        public AdminPanelForm(string str)
        {
            InitializeComponent();
            ConnectStr = str;
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

        private void TSMIbdShow_Click(object sender, EventArgs e)
        {
            /*DGVinst.Rows.Add("1", "1", "1", "1", "1", "1", "1", " "); DGVinst.Rows[0].Cells[7].Style.BackColor = Color.Green;
            DGVinst.Rows.Add("1", "2", "3", "4", "5", "6", "7", " "); DGVinst.Rows[1].Cells[7].Style.BackColor = Color.Green;
            DGVinst.Rows.Add("7", "6", "5", "4", "3", "2", "1", ""); DGVinst.Rows[2].Cells[7].Style.BackColor = Color.Red;
            DGVinst.Rows.Add("2", "2", "2", "2", "2", "2", "2", ""); DGVinst.Rows[3].Cells[7].Style.BackColor = Color.Red;*/
            try
            {
                //Program.ConnectForm.conn = new MySqlConnection(ConnectStr);
                Program.ConnectForm.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подключится к базе данных.\n" + ex, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int count = 1;
            MasReports = new Reports[1];
            MySqlCommand com;
            MySqlDataReader readed;
            try
            {
                //Загрузка ИНН, имен компаний
                com = new MySqlCommand("select inn, comp_name from project.login_inn", Program.ConnectForm.conn);
                readed = com.ExecuteReader();
                while (readed.Read())
                {
                    Array.Resize(ref MasReports, count);
                    MasReports[count - 1].inn = readed[0].ToString();
                    MasReports[count - 1].comp_name = readed[1].ToString();
                    MasReports[count - 1].date = new DateTime[2];
                    MasReports[count - 1].TBCE1 = new int[2];
                    MasReports[count - 1].TBCE2 = new int[2];
                    MasReports[count - 1].TBCE3 = new double[2];
                    MasReports[count - 1].TBCKR1 = new int[2];
                    MasReports[count - 1].TBCKR2 = new int[2];
                    MasReports[count - 1].TBCKR3 = new double[2];
                    MasReports[count - 1].TBCPP1 = new int[2];
                    MasReports[count - 1].TBCPP2 = new int[2];
                    MasReports[count - 1].TBCPP3 = new double[2];
                    MasReports[count - 1].TBFM1 = new int[2];
                    MasReports[count - 1].TBFM2 = new int[2];
                    MasReports[count - 1].TBFM3 = new double[2];
                    MasReports[count - 1].TBGF1 = new int[2];
                    MasReports[count - 1].TBGF2 = new int[2];
                    MasReports[count - 1].TBGF3 = new double[2];
                    count++;
                }
                readed.Close();

                //Загрузка 2 последних отчетов для каждой компании
                for(int i = 0; i < count; i++)
                {
                    com = new MySqlCommand("select * from project.`" + MasReports[i].inn + "`", Program.ConnectForm.conn);
                    readed = com.ExecuteReader();
                    int countRep = 0;
                    while (readed.Read())
                    {
                        MasReports[count - 1].date[countRep] = Convert.ToDateTime(readed[0].ToString());
                        MasReports[count - 1].TBCE1[countRep] = Convert.ToInt32(readed[1].ToString());
                        MasReports[count - 1].TBCE2[countRep] = Convert.ToInt32(readed[2].ToString());
                        MasReports[count - 1].TBCE3[countRep] = Convert.ToDouble(readed[3].ToString());
                        MasReports[count - 1].TBCKR1[countRep] = Convert.ToInt32(readed[4].ToString());
                        MasReports[count - 1].TBCKR2[countRep] = Convert.ToInt32(readed[5].ToString());
                        MasReports[count - 1].TBCKR3[countRep] = Convert.ToDouble(readed[6].ToString());
                        MasReports[count - 1].TBCPP1[countRep] = Convert.ToInt32(readed[7].ToString());
                        MasReports[count - 1].TBCPP2[countRep] = Convert.ToInt32(readed[8].ToString());
                        MasReports[count - 1].TBCPP3[countRep] = Convert.ToDouble(readed[9].ToString());
                        MasReports[count - 1].TBFM1[countRep] = Convert.ToInt32(readed[10].ToString());
                        MasReports[count - 1].TBFM2[countRep] = Convert.ToInt32(readed[11].ToString());
                        MasReports[count - 1].TBFM3[countRep] = Convert.ToDouble(readed[12].ToString());
                        MasReports[count - 1].TBGF1[countRep] = Convert.ToInt32(readed[13].ToString());
                        MasReports[count - 1].TBGF2[countRep] = Convert.ToInt32(readed[14].ToString());
                        MasReports[count - 1].TBGF3[countRep] = Convert.ToDouble(readed[15].ToString());
                        countRep++;
                    }
                    readed.Close();
                }

                /*com = new MySqlCommand(""
                    , Program.ConnectForm.conn);
                com.ExecuteNonQuery();*/
            }
            catch (MySqlException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("У вас недостаточно прав. Обратитесь к администратору.\n\n\n" + (ConnectStr.Contains("pavel6520") ? ex + "" : ""), "Ошибка доступа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Program.ConnectForm.conn.Close();
        }
    }
}
