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
        public SettingsForm SettingsForm;
        private string ConnectStr;
        protected struct Report
        {
            public DateTime date;
            public int[] param1, param2;
            public double[] param3;
        }
        private struct Reports
        {
            public string inn, comp_name;
            //public bool ReportFound;
        }
        //private Reports[] MasReportsForPeriod;

        private Random r = new Random();
        public DateTime SelectedPeriodStart = DateTime.MinValue, SelectedPeriodEnd = DateTime.MinValue;
        public DateTime SelectedPeriodStartBuf = DateTime.MinValue;
        //public int count_d = 0;

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
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось подключится к базе данных.\n" + ex, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MySqlCommand com;
            MySqlDataReader readed;
            try
            {
                //Загрузка ИНН, имен компаний
                com = new MySqlCommand("select inn, comp_name from project.login_inn", Program.ConnectForm.conn);
                readed = com.ExecuteReader();
                Reports[] MasReports = null;
                while (readed.Read())
                {
                    Array.Resize(ref MasReports, (MasReports == null ? 1 : MasReports.Length + 1));
                    MasReports[MasReports.Length - 1].inn = readed[0].ToString();
                    MasReports[MasReports.Length - 1].comp_name = readed[1].ToString();
                }
                readed.Close();
                if (MasReports == null)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show("Компании не найдены", "Данные отсутствуют", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Загрузка 2 последних отчетов для каждой компании
                bool ReportSearch = false;
                for (int i = 0; i < MasReports.Length; i++)
                {
                    DateTime[] MasReportQuarter = null;
                    int countReports = 0;
                    
                    com = new MySqlCommand("select distinct date from project.`" + MasReports[i].inn + "` order by date desc limit 2", Program.ConnectForm.conn);
                    readed = com.ExecuteReader();
                    while (readed.Read())
                    {
                        if (!ReportSearch)
                        {
                            ReportSearch = true;
                            DGVcompReport.Rows.Clear();
                        }
                        countReports++;
                        Array.Resize(ref MasReportQuarter, countReports);
                        MasReportQuarter[countReports - 1] = Convert.ToDateTime(readed[0].ToString());
                        MessageBox.Show("1. " + MasReportQuarter[countReports - 1].ToString("yyyy.MM.dd"));
                    }
                    readed.Close();
                    
                    DateTime[] MasReportTimeSended = null;
                    for (int j = 0; j < countReports; j++)
                    {
                        Array.Resize(ref MasReportTimeSended, j + 1);
                        com = new MySqlCommand("select datereport from project.`" + MasReports[i].inn + "` where Date = '" + MasReportQuarter[j].ToString("yyyy.MM.dd") + "' order by datereport desc limit 1", Program.ConnectForm.conn);
                        readed = com.ExecuteReader();
                        readed.Read();
                        MasReportTimeSended[j] = Convert.ToDateTime(readed[0].ToString());
                        readed.Close();
                        MessageBox.Show("2. " + MasReportQuarter[j].ToString("yyyy.MM.dd") + " " + MasReportTimeSended[j].ToString("yyyy.MM.dd HH:mm:ss"));
                    }
                    
                    Report[] reports = null;
                    for (int j = 0; j < countReports; j++)//Если есть отчеты, получаем самый актуальный
                    {
                        MessageBox.Show("3. " + MasReportTimeSended[j].ToString("yyyy.MM.dd HH:mm:ss"));
                        com = new MySqlCommand("select * from project.`" + MasReports[i].inn + "` where datereport = '" + 
                            MasReportTimeSended[j].ToString("yyyy.MM.dd HH:mm:ss") + 
                            "' order by DateReport desc limit 1", Program.ConnectForm.conn);
                        readed = com.ExecuteReader();
                        readed.Read();
                        Array.Resize(ref reports, j + 1);
                        //reports[reports.Length - 1].date = Convert.ToDateTime(readed[0].ToString());
                        reports[j].param1 = new int[5];
                        reports[j].param2 = new int[5];
                        reports[j].param3 = new double[5];
                        reports[j].param1[0] = Convert.ToInt32(readed[2].ToString());
                        reports[j].param2[0] = Convert.ToInt32(readed[3].ToString());
                        reports[j].param3[0] = Convert.ToDouble(readed[4].ToString());
                        reports[j].param1[1] = Convert.ToInt32(readed[5].ToString());
                        reports[j].param2[1] = Convert.ToInt32(readed[6].ToString());
                        reports[j].param3[1] = Convert.ToDouble(readed[7].ToString());
                        reports[j].param1[2] = Convert.ToInt32(readed[8].ToString());
                        reports[j].param2[2] = Convert.ToInt32(readed[9].ToString());
                        reports[j].param3[2] = Convert.ToDouble(readed[10].ToString());
                        reports[j].param1[3] = Convert.ToInt32(readed[11].ToString());
                        reports[j].param2[3] = Convert.ToInt32(readed[12].ToString());
                        reports[j].param3[3] = Convert.ToDouble(readed[13].ToString());
                        reports[j].param1[4] = Convert.ToInt32(readed[14].ToString());
                        reports[j].param2[4] = Convert.ToInt32(readed[15].ToString());
                        reports[j].param3[4] = Convert.ToDouble(readed[16].ToString());
                        readed.Close();
                    }
                    for (int j = 0; j <= 4; j++)
                    {
                        if (reports == null)
                        {
                            DGVcompReport.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, 0, 0.0, 0.0, 0.0, 3);
                            DGVcompReport.Rows[i * 5 + j].Cells[0].Style.BackColor = Color.LightGray;
                            DGVcompReport.Rows[i * 5 + j].Cells[1].Style.BackColor = Color.LightGray;
                            DGVcompReport.Rows[i * 5 + j].Cells[2].Style.BackColor = Color.Gray;
                            DGVcompReport.Rows[i * 5 + j].Cells[3].Style.BackColor = Color.Gray;
                            DGVcompReport.Rows[i * 5 + j].Cells[4].Style.BackColor = Color.Gray;
                            DGVcompReport.Rows[i * 5 + j].Cells[5].Style.BackColor = Color.Gray;
                            DGVcompReport.Rows[i * 5 + j].Cells[6].Style.BackColor = Color.Gray;
                            DGVcompReport.Rows[i * 5 + j].Cells[6].Style.ForeColor = Color.Gray;
                        }
                        else
                        {
                            switch (reports.Length)
                            {
                                case 1:
                                    {
                                        int param1 = reports[0].param1[j];
                                        double param2 = reports[0].param2[j];
                                        double param3 = reports[0].param3[j];
                                        DGVcompReport.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, 0.0, 2);
                                        DGVcompReport.Rows[i * 5 + j].Cells[0].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[1].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[2].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[3].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[4].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[5].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[6].Style.BackColor = Color.LightGray;
                                        DGVcompReport.Rows[i * 5 + j].Cells[6].Style.ForeColor = Color.LightGray;
                                        break;
                                    }
                                case 2:
                                    {
                                        int param1 = reports[0].param1[j] - reports[1].param1[j];
                                        double param2 = (reports[1].param2[j] == 0 ? reports[0].param2[j] : reports[0].param2[j] * 100.0 / reports[1].param2[j] - 100);
                                        double param3 = reports[0].param3[j] - reports[1].param3[j];
                                        double param4 = (reports[1].param3[j] == 0 ? reports[0].param2[j] : reports[0].param3[j] * 100.0 / reports[1].param3[j] - 100);
                                        int random = r.Next(0, 2);
                                        DGVcompReport.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, param4, random);
                                        DGVcompReport.Rows[i * 5 + j].Cells[6].Style.BackColor = (random == 0 ? Color.Red : Color.Green);
                                        DGVcompReport.Rows[i * 5 + j].Cells[6].Style.ForeColor = (random == 0 ? Color.Red : Color.Green);
                                        break;
                                    }
                            }
                        }
                    }
                }
                if (!ReportSearch)
                {
                    //Program.ConnectForm.conn.Close();
                    MessageBox.Show("Отчеты не найдены", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //return;
                }
                Program.ConnectForm.conn.Close();
            }
            catch (MySqlException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("Ошибка выполнения запроса. Обратитесь к администратору.\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CBinstSelect1.SelectedIndex == 0)
            {
                CBinstSelect2_SelectedIndexChanged(sender, e);
            }
            else
            {
                CBinstSelect1.SelectedIndex = 0;
            }
        }

        private void CBinstSelect2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGVcompReport.RowCount > 0)
            {
                for (int i = 0; i < DGVcompReport.RowCount; i++)
                {
                    DGVcompReport.Rows[i].Visible = (i % 5 == CBinstSelect2.SelectedIndex ? true : false);
                }
            }
        }
        
        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
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

        private void Bselect_date1_Click(object sender, EventArgs e)
        {
            MC1.Location = new Point(406, 68);
            MC1.Show();
        }

        private void Bselect_date2_Click(object sender, EventArgs e)
        {
            MC1.Location = new Point(634, 66);
            MC1.Show();
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPeriodStartBuf = DateTime.MinValue;
            MC1.Hide();
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    this.Size = new Size(953, 531);
                    break;
                case 1:
                    this.Size = new Size(587, 531);
                    break;
                case 2:
                    this.Size = new Size(926, 531);
                    break;
                case 3:
                    this.Size = new Size(818, 531);
                    break;
            }
        }

        private void TSMsettings_Click(object sender, EventArgs e)
        {
            SettingsForm = new SettingsForm();
            Enabled = false;
            SettingsForm.Show();
        }

        private void MC1_DateSelected_1(object sender, DateRangeEventArgs e)
        {
            if (SelectedPeriodStartBuf == DateTime.MinValue)
            {
                SelectedPeriodStartBuf = MC1.SelectionStart;
                return;
            }
            else
            {
                SelectedPeriodEnd = MC1.SelectionStart;
                MC1.Hide();
                SelectedPeriodStart = SelectedPeriodStartBuf;
                SelectedPeriodStartBuf = DateTime.MinValue;
                //MessageBox.Show(date1.ToString("yyyy.MM.dd") + " - " + date2.ToString("yyyy.MM.dd"));
                //Выбранный период находится в SelectedPeriodStart и SelectedPeriodEnd
                return;
            }
        }
    }
}
