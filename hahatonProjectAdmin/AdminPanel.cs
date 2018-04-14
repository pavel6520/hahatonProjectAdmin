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
            //public DateTime date;
            public int CountReports;
            public int FM1, FM2, GF1, GF2, CKR1, CKR2, CPP1, CPP2, CE1, CE2;
            public double FM3, GF3, CKR3, CPP3, CE3;

            public int FM11, FM21, GF11, GF21, CKR11, CKR21, CPP11, CPP21, CE11, CE21;
            public double FM31, GF31, CKR31, CPP31, CE31;
        }
        private Reports[] MasReports;
        public const bool plan = true;
        private Random r = new Random();
        public DateTime date1, date2;
        public int count_d = 0;

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
                Program.ConnectForm.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подключится к базе данных.\n" + ex, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            int count = 0;
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
                for (int i = 0; i < count; i++)
                {
                    com = new MySqlCommand("select * from project.`" + MasReports[i].inn + "`  order by date desc limit 2", Program.ConnectForm.conn);
                    readed = com.ExecuteReader();

                    MasReports[i].CountReports = 0;

                    if (readed.Read())//Если есть отчеты, получаем самый актуальный
                    {
                        ReportSearch = true;
                        //MasReports[i].date = Convert.ToDateTime(readed[0].ToString());
                        MasReports[i].CountReports = 1;
                        MasReports[i].FM1 = Convert.ToInt32(readed[1].ToString());
                        MasReports[i].FM2 = Convert.ToInt32(readed[2].ToString());
                        MasReports[i].FM3 = Convert.ToDouble(readed[3].ToString());

                        MasReports[i].GF1 = Convert.ToInt32(readed[4].ToString());
                        MasReports[i].GF2 = Convert.ToInt32(readed[5].ToString());
                        MasReports[i].GF3 = Convert.ToDouble(readed[6].ToString());

                        MasReports[i].CKR1 = Convert.ToInt32(readed[7].ToString());
                        MasReports[i].CKR2 = Convert.ToInt32(readed[8].ToString());
                        MasReports[i].CKR3 = Convert.ToDouble(readed[9].ToString());

                        MasReports[i].CPP1 = Convert.ToInt32(readed[10].ToString());
                        MasReports[i].CPP2 = Convert.ToInt32(readed[11].ToString());
                        MasReports[i].CPP3 = Convert.ToDouble(readed[12].ToString());

                        MasReports[i].CE1 = Convert.ToInt32(readed[13].ToString());
                        MasReports[i].CE2 = Convert.ToInt32(readed[14].ToString());
                        MasReports[i].CE3 = Convert.ToDouble(readed[15].ToString());
                        if (readed.Read())//Если есть предпоследний отчет записываем его (здесь применить формулы)
                        {
                            MasReports[i].CountReports = 2;
                            //DateTime date = Convert.ToDateTime(readed[0].ToString());
                            MasReports[i].FM11 = Convert.ToInt32(readed[1].ToString());
                            MasReports[i].FM21 = Convert.ToInt32(readed[2].ToString());
                            MasReports[i].FM31 = Convert.ToDouble(readed[3].ToString());

                            MasReports[i].GF11 = Convert.ToInt32(readed[4].ToString());
                            MasReports[i].GF21 = Convert.ToInt32(readed[5].ToString());
                            MasReports[i].GF31 = Convert.ToDouble(readed[6].ToString());

                            MasReports[i].CKR11 = Convert.ToInt32(readed[7].ToString());
                            MasReports[i].CKR21 = Convert.ToInt32(readed[8].ToString());
                            MasReports[i].CKR31 = Convert.ToDouble(readed[9].ToString());

                            MasReports[i].CPP11 = Convert.ToInt32(readed[10].ToString());
                            MasReports[i].CPP21 = Convert.ToInt32(readed[11].ToString());
                            MasReports[i].CPP31 = Convert.ToDouble(readed[12].ToString());

                            MasReports[i].CE11 = Convert.ToInt32(readed[13].ToString());
                            MasReports[i].CE21 = Convert.ToInt32(readed[14].ToString());
                            MasReports[i].CE31 = Convert.ToDouble(readed[15].ToString());
                            //У нас есть последний отчет в структуре и предпоследний отчет здесь, применить формулы
                        }
                        else
                        {
                            MasReports[i].CE11 = 0;
                            MasReports[i].CE21 = 0;
                            MasReports[i].CE31 = 0.0;
                            MasReports[i].CKR11 = 0;
                            MasReports[i].CKR21 = 0;
                            MasReports[i].CKR31 = 0.0;
                            MasReports[i].CPP11 = 0;
                            MasReports[i].CPP21 = 0;
                            MasReports[i].CPP31 = 0.0;
                            MasReports[i].FM11 = 0;
                            MasReports[i].FM21 = 0;
                            MasReports[i].FM31 = 0.0;
                            MasReports[i].GF11 = 0;
                            MasReports[i].GF21 = 0;
                            MasReports[i].GF31 = 0.0;
                        }
                    }
                    else
                    {
                        MasReports[i].CE1 = 0;
                        MasReports[i].CE2 = 0;
                        MasReports[i].CE3 = 0.0;
                        MasReports[i].CKR1 = 0;
                        MasReports[i].CKR2 = 0;
                        MasReports[i].CKR3 = 0.0;
                        MasReports[i].CPP1 = 0;
                        MasReports[i].CPP2 = 0;
                        MasReports[i].CPP3 = 0.0;
                        MasReports[i].FM1 = 0;
                        MasReports[i].FM2 = 0;
                        MasReports[i].FM3 = 0.0;
                        MasReports[i].GF1 = 0;
                        MasReports[i].GF2 = 0;
                        MasReports[i].GF3 = 0.0;
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
            CBinstSelect2.SelectedIndex = 1;
            CBinstSelect2.SelectedIndex = 0;
        }

        private void CBinstSelect1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGVinst.Rows.Clear();
            
            for (int i = 0; i < MasReports.Length; i++)
            {
                switch (MasReports[i].CountReports)
                {
                    case 0:
                        {
                            DGVinst.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, 0, 0.0, 0.0, 0.0, 3);
                            DGVinst.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
                            DGVinst.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                            for (int j = 2; j <= 6; j++)
                            {
                                DGVinst.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                            }
                            DGVinst.Rows[i].Cells[6].Style.ForeColor = Color.Gray;
                            break;
                        }
                    case 1:
                        {
                            int param1 = 0;
                            double param2 = 0, param3 = 0, param4 = 0;
                            switch (CBinstSelect2.SelectedIndex)
                            {
                                case 0:
                                    {
                                        param1 = MasReports[i].FM1;
                                        param2 = MasReports[i].FM2;
                                        param3 = MasReports[i].FM3;
                                        param4 = MasReports[i].FM3;
                                        break;
                                    }
                                case 1:
                                    {
                                        param1 = MasReports[i].GF1;
                                        param2 = MasReports[i].GF2;
                                        param3 = MasReports[i].GF3;
                                        param4 = MasReports[i].GF3;
                                        break;
                                    }
                                case 2:
                                    {
                                        param1 = MasReports[i].CKR1;
                                        param2 = MasReports[i].CKR2;
                                        param3 = MasReports[i].CKR3;
                                        param4 = MasReports[i].CKR3;
                                        break;
                                    }
                                case 3:
                                    {
                                        param1 = MasReports[i].CPP1;
                                        param2 = MasReports[i].CPP2;
                                        param3 = MasReports[i].CPP3;
                                        param4 = MasReports[i].CPP3;
                                        break;
                                    }
                                case 4:
                                    {
                                        param1 = MasReports[i].CE1;
                                        param2 = MasReports[i].CE2;
                                        param3 = MasReports[i].CE3;
                                        param4 = MasReports[i].CE3;
                                        break;
                                    }
                            }
                            
                            DGVinst.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, param4, 2);
                            
                            for(int j = 0; j <= 6; j++)
                            {
                                DGVinst.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                            }
                            DGVinst.Rows[i].Cells[6].Style.ForeColor = Color.LightGray;
                            break;
                        }
                    case 2:
                        {
                            int param1 = 0;
                            double param2 = 0, param3 = 0, param4 = 0;
                            switch (CBinstSelect2.SelectedIndex)
                            {
                                case 0:
                                    {
                                        param1 = MasReports[i].FM1 - MasReports[i].FM11;
                                        param2 = MasReports[i].FM2 * 100.0 / (MasReports[i].FM21 == 0 ? 1 : MasReports[i].FM21);
                                        param3 = MasReports[i].FM3 - MasReports[i].FM31;
                                        param4 = MasReports[i].FM3 * 100.0 / (MasReports[i].FM31 == 0 ? 1 : MasReports[i].FM31);
                                        break;
                                    }
                                case 1:
                                    {
                                        param1 = MasReports[i].GF1 - MasReports[i].GF11;
                                        param2 = MasReports[i].GF2 * 100.0 / (MasReports[i].GF21 == 0 ? 1 : MasReports[i].GF21);
                                        param3 = MasReports[i].GF3 - MasReports[i].GF31;
                                        param4 = MasReports[i].GF3 * 100.0 / (MasReports[i].GF31 == 0 ? 1 : MasReports[i].GF31);
                                        break;
                                    }
                                case 2:
                                    {
                                        param1 = MasReports[i].CKR1 - MasReports[i].CKR11;
                                        param2 = MasReports[i].CKR2 * 100.0 / (MasReports[i].CE21 == 0 ? 1 : MasReports[i].CE21);
                                        param3 = MasReports[i].CKR3 - MasReports[i].CKR31;
                                        param4 = MasReports[i].CKR3 * 100.0 / (MasReports[i].CE31 == 0 ? 1 : MasReports[i].CE31);
                                        break;
                                    }
                                case 3:
                                    {
                                        param1 = MasReports[i].CPP1 - MasReports[i].CPP11;
                                        param2 = MasReports[i].CPP2 * 100.0 / (MasReports[i].CPP21 == 0 ? 1 : MasReports[i].CPP21);
                                        param3 = MasReports[i].CPP3 - MasReports[i].CPP31;
                                        param4 = MasReports[i].CPP3 * 100.0 / (MasReports[i].CPP31 == 0 ? 1 : MasReports[i].CPP31);
                                        break;
                                    }
                                case 4:
                                    {
                                        param1 = MasReports[i].CE1 - MasReports[i].CE11;
                                        param2 = MasReports[i].CE2 * 100.0 / (MasReports[i].CE21 == 0 ? 1 : MasReports[i].CE21);
                                        param3 = MasReports[i].CE3 - MasReports[i].CE31;
                                        param4 = MasReports[i].CE3 * 100.0 / (MasReports[i].CE31 == 0 ? 1 : MasReports[i].CE21);
                                        break;
                                    }
                            }
                            int random = r.Next(0, 2);
                            DGVinst.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, param4, random);
                            if (random == 0)
                            {
                                DGVinst.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                DGVinst.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                            }
                            else
                            {
                                DGVinst.Rows[i].Cells[6].Style.BackColor = Color.Green;
                                DGVinst.Rows[i].Cells[6].Style.ForeColor = Color.Green;
                            }
                            break;
                        }
                }

                
            }
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(587, 531);

            MasReports = new Reports[1];

            TabControl.SelectedIndex = 0;
            CBinstSelect1.SelectedIndex = 0;
            CBinstSelect2.SelectedIndex = 0;
            CBinstSelect3.SelectedIndex = 0;

            Dia1.Series[0].Points.DataBindY(
                new int[] { 15, 20 });
            Dia1.Series[1].Points.DataBindY(
                new int[] { 25, 35 });
            Dia1.Series[2].Points.DataBindY(
                new int[] { 35, 45 });
            Dia1.Series[3].Points.DataBindY(
                new int[] { 45, 55 });
            Dia1.Series[4].Points.DataBindY(
                new int[] { 55, 65 });
        }

        private void Bselect_date_Click(object sender, EventArgs e)
        {
            
        }

        private void Bset_Click(object sender, EventArgs e)
        {
            Dia1.Series[0].Points.DataBindY(
                new int[] {15, 20} );
            Dia1.Series[1].Points.DataBindY(
                new int[] {25, 35});
            Dia1.Series[2].Points.DataBindY(
                new int[] {35, 45});
            Dia1.Series[3].Points.DataBindY(
                new int[] {45, 55});
            Dia1.Series[4].Points.DataBindY(
                new int[] {55, 65});
        }

        private void Bselect_date1_Click(object sender, EventArgs e)
        {
            MC1.Show();
        }

        private void Bselect_date2_Click(object sender, EventArgs e)
        {
            MC2.Show();
        }

        private void MC2_DateSelected(object sender, DateRangeEventArgs e)
        {
            count_d++;

            switch (count_d)
            {
                case 1:
                    date1 = MC2.SelectionStart;
                    break;
                case 2:
                    date2 = MC2.SelectionStart;
                    MC2.Hide();
                    //MessageBox.Show(date1.ToString("yyyy.MM.dd") + " - " + date2.ToString("yyyy.MM.dd"));
                    //Выбранный период находится в date1 и date2
                    count_d = 0;
                    return;
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    this.Size = new Size(587, 531);
                    break;
                case 1:
                    this.Size = new Size(952, 531);
                    break;
                case 2:
                    this.Size = new Size(818, 531);
                    break;
                case 3:
                    this.Size = new Size(926, 531);
                    break;
            }
        }

        private void MC1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            count_d++;

            switch (count_d)
            {
                case 1:
                    date1 = MC1.SelectionStart;
                    break;
                case 2:
                    date2 = MC1.SelectionStart;
                    MC1.Hide();
                    //MessageBox.Show(date1.ToString("yyyy.MM.dd") + " - " + date2.ToString("yyyy.MM.dd"));
                    //Выбранный период находится в date1 и date2
                    count_d = 0;
                    return;
            }
        }
        
    }
}
