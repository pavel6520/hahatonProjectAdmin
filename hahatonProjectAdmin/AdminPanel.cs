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
            public DateTime date;
            public int TBFM1, TBFM2, TBGF1, TBGF2, TBCKR1, TBCKR2, TBCPP1, TBCPP2, TBCE1, TBCE2;
            public double TBFM3, TBGF3, TBCKR3, TBCPP3, TBCE3;
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
            int count = 0;
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
                    count++;
                    Array.Resize(ref MasReports, count);
                    MasReports[count - 1].inn = readed[0].ToString();
                    MasReports[count - 1].comp_name = readed[1].ToString();
                }
                readed.Close();
                if (count == 0)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show("Компании не найдены", "Данные отсутствуют", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                bool ReportSearch = false;
                //Загрузка 2 последних отчетов для каждой компании
                for(int i = 0; i < count; i++)
                {
                    com = new MySqlCommand("select * from project.`" + MasReports[i].inn + "`  order by date desc limit 2", Program.ConnectForm.conn);
                    readed = com.ExecuteReader();

                    if (readed.Read())//Если есть отчеты, получаем самый актуальный
                    {
                        ReportSearch = true;
                        MasReports[i].date = Convert.ToDateTime(readed[0].ToString());
                        MasReports[i].TBCE1 = Convert.ToInt32(readed[1].ToString());
                        MasReports[i].TBCE2 = Convert.ToInt32(readed[2].ToString());
                        MasReports[i].TBCE3 = Convert.ToDouble(readed[3].ToString());
                        MasReports[i].TBCKR1 = Convert.ToInt32(readed[4].ToString());
                        MasReports[i].TBCKR2 = Convert.ToInt32(readed[5].ToString());
                        MasReports[i].TBCKR3 = Convert.ToDouble(readed[6].ToString());
                        MasReports[i].TBCPP1 = Convert.ToInt32(readed[7].ToString());
                        MasReports[i].TBCPP2 = Convert.ToInt32(readed[8].ToString());
                        MasReports[i].TBCPP3 = Convert.ToDouble(readed[9].ToString());
                        MasReports[i].TBFM1 = Convert.ToInt32(readed[10].ToString());
                        MasReports[i].TBFM2 = Convert.ToInt32(readed[11].ToString());
                        MasReports[i].TBFM3 = Convert.ToDouble(readed[12].ToString());
                        MasReports[i].TBGF1 = Convert.ToInt32(readed[13].ToString());
                        MasReports[i].TBGF2 = Convert.ToInt32(readed[14].ToString());
                        MasReports[i].TBGF3 = Convert.ToDouble(readed[15].ToString());

                        if (readed.Read())//Если есть предпоследний отчет записываем его (здесь применить формулы)
                        {
                            DateTime date = Convert.ToDateTime(readed[0].ToString());
                            int TBCE1 = Convert.ToInt32(readed[1].ToString());
                            int TBCE2 = Convert.ToInt32(readed[2].ToString());
                            double TBCE3 = Convert.ToDouble(readed[3].ToString());
                            int TBCKR1 = Convert.ToInt32(readed[4].ToString());
                            int TBCKR2 = Convert.ToInt32(readed[5].ToString());
                            double TBCKR3 = Convert.ToDouble(readed[6].ToString());
                            int TBCPP1 = Convert.ToInt32(readed[7].ToString());
                            int TBCPP2 = Convert.ToInt32(readed[8].ToString());
                            double TBCPP3 = Convert.ToDouble(readed[9].ToString());
                            int TBFM1 = Convert.ToInt32(readed[10].ToString());
                            int TBFM2 = Convert.ToInt32(readed[11].ToString());
                            double TBFM3 = Convert.ToDouble(readed[12].ToString());
                            int TBGF1 = Convert.ToInt32(readed[13].ToString());
                            int TBGF2 = Convert.ToInt32(readed[14].ToString());
                            double TBGF3 = Convert.ToDouble(readed[15].ToString());

                            //У нас есть последний отчет в структуре и предпоследний отчет здесь, применить формулы
                        }
                    }
                    else
                    {
                        MasReports[i].date = DateTime.MinValue;
                        MasReports[i].TBCE1 = 0;
                        MasReports[i].TBCE2 = 0;
                        MasReports[i].TBCE3 = 0.0;
                        MasReports[i].TBCKR1 = 0;
                        MasReports[i].TBCKR2 = 0;
                        MasReports[i].TBCKR3 = 0.0;
                        MasReports[i].TBCPP1 = 0;
                        MasReports[i].TBCPP2 = 0;
                        MasReports[i].TBCPP3 = 0.0;
                        MasReports[i].TBFM1 = 0;
                        MasReports[i].TBFM2 = 0;
                        MasReports[i].TBFM3 = 0.0;
                        MasReports[i].TBGF1 = 0;
                        MasReports[i].TBGF2 = 0;
                        MasReports[i].TBGF3 = 0.0;
                    }
                    readed.Close();
                }
                if (!ReportSearch)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show("Отчеты не найдены", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Program.ConnectForm.conn.Close();
            }
            catch (MySqlException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("Ошибка выполнения запроса. Обратитесь к администратору.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            CBinstSelect1.SelectedIndex = 1;
            CBinstSelect1.SelectedIndex = 0;
        }

        private void CBinstSelect1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGVinst.Rows.Clear();
            for (int i = 0; i < MasReports.Length; i++)
            {
                int param1 = 0, param2 = 0;
                double param3 = 0;
                switch (CBinstSelect1.SelectedIndex)
                {
                    case 0:
                        {
                            param1 = MasReports[i].TBCE1;
                            param2 = MasReports[i].TBCE2;
                            param3 = MasReports[i].TBCE3;
                            break;
                        }
                    case 1:
                        {
                            param1 = MasReports[i].TBCKR1;
                            param2 = MasReports[i].TBCKR2;
                            param3 = MasReports[i].TBCKR3;
                            break;
                        }
                    case 2:
                        {
                            param1 = MasReports[i].TBCPP1;
                            param2 = MasReports[i].TBCPP2;
                            param3 = MasReports[i].TBCPP3;
                            break;
                        }
                    case 3:
                        {
                            param1 = MasReports[i].TBFM1;
                            param2 = MasReports[i].TBFM2;
                            param3 = MasReports[i].TBFM3;
                            break;
                        }
                    case 4:
                        {
                            param1 = MasReports[i].TBGF1;
                            param2 = MasReports[i].TBGF2;
                            param3 = MasReports[i].TBGF3;
                            break;
                        }
                }
                DGVinst.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, i + "test", i + "test");
            }
        }
    }
}
