using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hahatonProjectAdmin
{
    public partial class AdminPanelForm : Form
    {
        LoadingMessegeForm loadingMessege;
        private DateTime SelectedPeriodStart = DateTime.MinValue, SelectedPeriodEnd = DateTime.MinValue;
        private DateTime SelectedPeriodStartBuf = DateTime.MinValue;
        public int PlanSettingsParam1;
        public double PlanSettingsParam2, PlanSettingsParam3, PlanSettingsParam4;

        /// <summary>
        /// Возвращает массива структур, содержащий ИНН и имена компаний
        /// </summary>
        public static Company[] GetCompany()
        {
            MySqlCommand com;
            MySqlDataReader reader;
            Company[] MasCompany = null;
            try
            {
                com = new MySqlCommand("select inn, comp_name from project.login_inn", Program.ConnectForm.conn);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref MasCompany, (MasCompany == null ? 1 : MasCompany.Length + 1));
                    MasCompany[MasCompany.Length - 1].inn = reader[0].ToString();
                    MasCompany[MasCompany.Length - 1].comp_name = reader[1].ToString();
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw new ExceptionShowMessageException(ex.Message);
            }
            return MasCompany;
        }

        /// <summary>
        /// Возвращает массив структур, в каждом элементе которого содержатся логин пользователя и массива структур, содержащий ИНН и имена компаний пользователя
        /// </summary>
        public static User[] GetUserCompanies()
        {
            MySqlCommand com;
            MySqlDataReader reader;
            User[] MasUsers = null;
            try
            {
                com = new MySqlCommand("select distinct login from project.login_inn order by login", Program.ConnectForm.conn);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref MasUsers, (MasUsers == null ? 1 : MasUsers.Length + 1));
                    MasUsers[MasUsers.Length - 1].login = reader[0].ToString();
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                throw new ExceptionShowMessageException(ex.Message);
            }
            try
            {
                for(int i = 0; i < MasUsers.Length; i++)
                {
                    com = new MySqlCommand($"select inn, comp_name from project.login_inn where login = '{MasUsers[i].login}' order by inn", Program.ConnectForm.conn);
                    reader = com.ExecuteReader();
                    while (reader.Read())
                    {
                        Array.Resize(ref MasUsers[i].MasCompany, (MasUsers[i].MasCompany == null ? 1 : MasUsers[i].MasCompany.Length + 1));
                        MasUsers[i].MasCompany[MasUsers[i].MasCompany.Length - 1].inn = reader[0].ToString();
                        MasUsers[i].MasCompany[MasUsers[i].MasCompany.Length - 1].comp_name = reader[1].ToString();
                    }
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new ExceptionShowMessageException(ex.Message);
            }
            return MasUsers;
        }

        /// <summary>
        /// Возвращает массив ключей (уникальные дата и время) самых актуальных отчетов за 2 квартала: указанный и предыдущий
        /// </summary>
        /// <param name="CompanyRef">Структура, содержащая ИНН компании, для которой необходимо загрузить ключи отчетов</param>
        /// <param name="StartSelect">Дата квартала, с которого начинать отбор отчетов</param>
        /// <param name="CountQuarter">Число кварталов, если не важна конечная дата отбора</param>
        /// <param name="EndSelect">Дата квартала, на котором заканчивается отбор отчетов</param>
        public static DateTime[] GetLastReportDateTime(ref Company CompanyRef, string StartSelect, int CountQuarter = 0, string EndSelect = "")
        {
            MySqlCommand com;
            if (CountQuarter > 0)
            {
                com = new MySqlCommand(
                    $"select distinct date from project.`{CompanyRef.inn}` where date <= '{StartSelect}' order by date desc limit {CountQuarter}",
                    Program.ConnectForm.conn);
            }
            else
            {
                com = new MySqlCommand($"select distinct date from project.`{CompanyRef.inn}` where date >= '{EndSelect}' and date <= '{StartSelect}' " +
                    $"order by date desc", Program.ConnectForm.conn);
            }
            MySqlDataReader reader;
            DateTime[] MasReportTime = null;
            try
            {
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref MasReportTime, (MasReportTime == null ? 1 : MasReportTime.Length + 1));
                    MasReportTime[MasReportTime.Length - 1] = Convert.ToDateTime(reader[0].ToString());
                }
                reader.Close();
                if (MasReportTime == null)
                {
                    return null;
                }
                for (int j = 0; j < MasReportTime.Length; j++)
                {
                    com = new MySqlCommand($"select datereport from project.`{CompanyRef.inn}` where Date = '{MasReportTime[j].ToString("yyyy.MM.dd")}' order by datereport desc limit 1", Program.ConnectForm.conn);
                    reader = com.ExecuteReader();
                    reader.Read();
                    MasReportTime[j] = Convert.ToDateTime(reader[0].ToString());
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new ExceptionShowMessageException(ex.Message);
            }
            return MasReportTime;
        }

        /// <summary>
        /// Возвращает массив отчетов, полученных по ИНН компании и ключам (уникальным датам)
        /// </summary>
        /// <param name="CompanyRef">Структура, содержащая ИНН компании, для которой необходимо загрузить отчеты</param>
        /// <param name="MasReportTimeSended">Массив ключей (уникальные дата и время) самых актуальных отчетов</param>
        public static Report[] GetReports(ref Company CompanyRef, ref DateTime[] MasReportTimeSended)
        {
            MySqlCommand com;
            MySqlDataReader reader;
            Report[] MasCompanyReports = new Report[MasReportTimeSended.Length];
            try
            {
                for (int i = 0; i < MasReportTimeSended.Length; i++)
                {
                    com = new MySqlCommand($"select * from project.`{CompanyRef.inn}` where datereport = '" +
                        $"{MasReportTimeSended[i].ToString("yyyy.MM.dd HH:mm:ss")}" +
                        $"' order by DateReport desc limit 1", Program.ConnectForm.conn);
                    reader = com.ExecuteReader();
                    reader.Read();
                    MasCompanyReports[i].DateQuarter = Convert.ToDateTime(reader[0].ToString());
                    MasCompanyReports[i].DateReportSend = Convert.ToDateTime(reader[1].ToString());
                    MasCompanyReports[i].param1 = new int[5];
                    MasCompanyReports[i].param1[0] = Convert.ToInt32(reader[2].ToString());
                    MasCompanyReports[i].param1[1] = Convert.ToInt32(reader[5].ToString());
                    MasCompanyReports[i].param1[2] = Convert.ToInt32(reader[8].ToString());
                    MasCompanyReports[i].param1[3] = Convert.ToInt32(reader[11].ToString());
                    MasCompanyReports[i].param1[4] = Convert.ToInt32(reader[14].ToString());
                    MasCompanyReports[i].param2 = new int[5];
                    MasCompanyReports[i].param2[0] = Convert.ToInt32(reader[3].ToString());
                    MasCompanyReports[i].param2[1] = Convert.ToInt32(reader[6].ToString());
                    MasCompanyReports[i].param2[2] = Convert.ToInt32(reader[9].ToString());
                    MasCompanyReports[i].param2[3] = Convert.ToInt32(reader[12].ToString());
                    MasCompanyReports[i].param2[4] = Convert.ToInt32(reader[15].ToString());
                    MasCompanyReports[i].param3 = new double[5];
                    MasCompanyReports[i].param3[0] = Convert.ToDouble(reader[4].ToString());
                    MasCompanyReports[i].param3[1] = Convert.ToDouble(reader[7].ToString());
                    MasCompanyReports[i].param3[2] = Convert.ToDouble(reader[10].ToString());
                    MasCompanyReports[i].param3[3] = Convert.ToDouble(reader[13].ToString());
                    MasCompanyReports[i].param3[4] = Convert.ToDouble(reader[16].ToString());
                    reader.Close();
                }
            }
            catch (MySqlException ex)
            {
                throw new ExceptionShowMessageException(ex.Message);
            }
            return MasCompanyReports;
        }

        private void LoadCompReports(ref object sender, ref EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(TBYearCompReport.Text) < 1000)
                {
                    MessageBox.Show("Неверный формат года", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show($"Неверный формат года", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string Quarter = "";
            string Quarter1 = "";
            switch (CBQuarterCompReport.SelectedIndex)
            {
                case 0:
                    Quarter = TBYearCompReport.Text + ".03.25";
                    break;
                case 1:
                    Quarter = TBYearCompReport.Text + ".06.25";
                    break;
                case 2:
                    Quarter = TBYearCompReport.Text + ".09.25";
                    break;
                case 3:
                    Quarter = TBYearCompReport.Text + ".12.25";
                    break;
            }
            switch (CBQuarterCompReport.SelectedIndex)
            {
                case 0:
                    Quarter1 = $"{Convert.ToInt32(TBYearCompReport.Text) - 1}.12.25";
                    break;
                case 1:
                    Quarter1 = TBYearCompReport.Text + ".03.25";
                    break;
                case 2:
                    Quarter1 = TBYearCompReport.Text + ".06.25";
                    break;
                case 3:
                    Quarter1 = TBYearCompReport.Text + ".09.25";
                    break;
            }
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Не удалось подключится к базе данных.\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DGVcompReport.Rows.Clear();
            Company[] MasCompany;
            //Загрузка ИНН, имен компаний
            try
            {
                MasCompany = GetCompany();
            }
            catch (ExceptionShowMessageException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show($"Ошибка загрузки списка компаний\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MasCompany == null)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("Компании не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool ReportSearchError = true;
            for (int i = 0; i < MasCompany.Length; i++)
            {
                DateTime[] MasReportTimeSended;
                //Загрузка даты двух последних отчетов компании
                try
                {
                    if ((MasReportTimeSended = GetLastReportDateTime(ref MasCompany[i], Quarter, EndSelect: Quarter1)) == null)
                    {
                        continue;
                    }
                }
                catch (ExceptionShowMessageException ex)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show($"Ошибка загрузки ключей отчетов\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ReportSearchError)
                {
                    ReportSearchError = false;
                }
                //Получаем отчеты по ключу-дате
                Report[] MasCompanyReports = null;
                try
                {
                    MasCompanyReports = GetReports(ref MasCompany[i], ref MasReportTimeSended);
                }
                catch (ExceptionShowMessageException ex)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show($"Ошибка загрузки отчетов\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //Добавление непустых отчетов в таблицу
                for (int j = 0; j <= 4; j++)
                {
                    if (MasCompanyReports[0].param1[j] > 0)
                    {
                        if (MasCompanyReports.Length == 1)
                        {
                            DGVcompReport.Rows.Add(MasCompany[i].comp_name, MasCompany[i].inn, MasCompanyReports[0].param1[j], MasCompanyReports[0].param2[j], MasCompanyReports[0].param3[j], 0.0, j);
                        }
                        else
                        {
                            int param1 = MasCompanyReports[0].param1[j] - MasCompanyReports[MasCompanyReports.Length - 1].param1[j];
                            double param2 = (MasCompanyReports[1].param2[j] == 0 ? MasCompanyReports[0].param2[j] : MasCompanyReports[0].param2[j] * 100.0 / MasCompanyReports[1].param2[j] - 100);
                            double param3 = MasCompanyReports[0].param3[j] - MasCompanyReports[1].param3[j];
                            double param4 = (MasCompanyReports[1].param3[j] == 0 ? MasCompanyReports[0].param2[j] : MasCompanyReports[0].param3[j] * 100.0 / MasCompanyReports[1].param3[j] - 100);
                            DGVcompReport.Rows.Add(MasCompany[i].comp_name, MasCompany[i].inn, param1, param2, param3, param4, j);
                            DGVcompReport.Rows[DGVcompReport.RowCount - 1].Cells[2].Style.BackColor = (param1 >= PlanSettingsParam1 ? Color.LightGreen : Color.PaleVioletRed);
                            DGVcompReport.Rows[DGVcompReport.RowCount - 1].Cells[3].Style.BackColor = (param2 >= PlanSettingsParam2 ? Color.LightGreen : Color.PaleVioletRed);
                            DGVcompReport.Rows[DGVcompReport.RowCount - 1].Cells[4].Style.BackColor = (param3 >= PlanSettingsParam3 ? Color.LightGreen : Color.PaleVioletRed);
                            DGVcompReport.Rows[DGVcompReport.RowCount - 1].Cells[5].Style.BackColor = (param4 >= PlanSettingsParam4 ? Color.LightGreen : Color.PaleVioletRed);
                        }
                    }
                }
            }
            if (ReportSearchError)
            {
                MessageBox.Show("Отчеты не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Program.ConnectForm.conn.Close();
            CBinstSelect_SelectedIndexChanged(sender, e);
        }

        private void LoadInstStat(ref object sender, ref EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(TBInstStatYear1.Text) < 1000 || Convert.ToInt32(TBInstStatYear2.Text) < 1000)
                {
                    MessageBox.Show("Неверный формат года", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат года", "Неверный формат", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string StartQuarter = "";
            string EndQuarter = "";
            switch (CBInstStatQuarter2.SelectedIndex)
            {
                case 0:
                    StartQuarter = $"{TBInstStatYear2.Text}.03.25";
                    break;
                case 1:
                    StartQuarter = $"{TBInstStatYear2.Text}.06.25";
                    break;
                case 2:
                    StartQuarter = $"{TBInstStatYear2.Text}.09.25";
                    break;
                case 3:
                    StartQuarter = $"{TBInstStatYear2.Text}.12.25";
                    break;
            }
            switch (CBInstStatQuarter1.SelectedIndex)
            {
                case 0:
                    EndQuarter = $"{TBInstStatYear1.Text}.03.25";
                    break;
                case 1:
                    EndQuarter = $"{TBInstStatYear1.Text}.06.25";
                    break;
                case 2:
                    EndQuarter = $"{TBInstStatYear1.Text}.09.25";
                    break;
                case 3:
                    EndQuarter = $"{TBInstStatYear1.Text}.12.25";
                    break;
            }
            if(Convert.ToDateTime(StartQuarter) < Convert.ToDateTime(EndQuarter))
            {
                MessageBox.Show("Выбранный квартал начала отбора больше выбранного квартала конца отбора", "Неверный период", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Не удалось подключится к базе данных.\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Company[] MasCompany;
            //Загрузка ИНН, имен компаний
            try
            {
                MasCompany = GetCompany();
            }
            catch (ExceptionShowMessageException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show($"Ошибка загрузки списка компаний\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MasCompany == null)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("Компании не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bool ReportSearchError = true;
            for (int j = 0; j < 5; j++)
            {
                DGVinstStat.Rows[j].Cells[1].Value = 0;
                DGVinstStat.Rows[j].Cells[2].Value = 0;
                DGVinstStat.Rows[j].Cells[3].Value = 0.0;
            }
            for (int i = 0; i < MasCompany.Length; i++)
            {
                DateTime[] MasReportTimeSended;
                //Загрузка отчетов компании за указанный период
                try
                {
                    if ((MasReportTimeSended = GetLastReportDateTime(ref MasCompany[i], StartQuarter, EndSelect: EndQuarter)) == null || MasReportTimeSended.Length <= 1)
                    {
                        continue;
                    }
                }
                catch (ExceptionShowMessageException ex)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show($"Ошибка загрузки ключей отчетов\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (ReportSearchError)
                {
                    ReportSearchError = false;
                }
                //Получаем отчеты по ключу-дате
                Report[] MasCompanyReports = null;
                try
                {
                    MasCompanyReports = GetReports(ref MasCompany[i], ref MasReportTimeSended);
                }
                catch (ExceptionShowMessageException ex)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show($"Ошибка загрузки отчетов\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                int[] param1StartValue = { 0, 0, 0, 0, 0 };
                int[] param1EndValue = { 0, 0, 0, 0, 0 };
                int[] param2Buf = { 0, 0, 0, 0, 0 };
                double[] param3Buf = { 0.0, 0.0, 0.0, 0.0, 0.0 };
                int[] CountNotNullReport = new int[] { 0, 0, 0, 0, 0 };
                for (int j = 0; j < MasCompanyReports.Length; j++)
                {
                    for (int k = 0; k <= 4; k++)
                    {
                        if (MasCompanyReports[j].param1[k] > 0)
                        {
                            CountNotNullReport[k]++;
                            if (CountNotNullReport[k] == 1)
                            {
                                param1StartValue[k] = MasCompanyReports[j].param1[k];
                            }
                            else
                            {
                                param1EndValue[k] = MasCompanyReports[j].param1[k];
                            }
                            param2Buf[k] += MasCompanyReports[j].param2[k];
                            param3Buf[k] += MasCompanyReports[j].param3[k];
                        }
                    }
                }
                for (int j = 0; j < 5; j++)
                {
                    if (CountNotNullReport[j] > 1)
                    {
                        DGVinstStat.Rows[j].Cells[1].Value = Convert.ToInt32(DGVinstStat.Rows[j].Cells[1].Value.ToString()) + param1StartValue[j] - param1EndValue[j];
                        DGVinstStat.Rows[j].Cells[2].Value = Convert.ToInt32(DGVinstStat.Rows[j].Cells[2].Value.ToString()) + param2Buf[j];
                        DGVinstStat.Rows[j].Cells[3].Value = Convert.ToDouble(DGVinstStat.Rows[j].Cells[3].Value.ToString()) + param3Buf[j];
                    }
                }
                Diagram.Series[0].Points.DataBindY(new int[] { Convert.ToInt32(DGVinstStat.Rows[0].Cells[2].Value.ToString()) });
                Diagram.Series[5].Points.DataBindY(new double[] { Convert.ToDouble(DGVinstStat.Rows[0].Cells[3].Value.ToString()) });
                Diagram.Series[1].Points.DataBindY(new int[] { Convert.ToInt32(DGVinstStat.Rows[1].Cells[2].Value.ToString()) });
                Diagram.Series[6].Points.DataBindY(new double[] { Convert.ToDouble(DGVinstStat.Rows[1].Cells[3].Value.ToString()) });
                Diagram.Series[2].Points.DataBindY(new int[] { Convert.ToInt32(DGVinstStat.Rows[2].Cells[2].Value.ToString()) });
                Diagram.Series[7].Points.DataBindY(new double[] { Convert.ToDouble(DGVinstStat.Rows[2].Cells[3].Value.ToString()) });
                Diagram.Series[3].Points.DataBindY(new int[] { Convert.ToInt32(DGVinstStat.Rows[3].Cells[2].Value.ToString()) });
                Diagram.Series[8].Points.DataBindY(new double[] { Convert.ToDouble(DGVinstStat.Rows[3].Cells[3].Value.ToString()) });
                Diagram.Series[4].Points.DataBindY(new int[] { Convert.ToInt32(DGVinstStat.Rows[4].Cells[2].Value.ToString()) });
                Diagram.Series[9].Points.DataBindY(new double[] { Convert.ToDouble(DGVinstStat.Rows[4].Cells[3].Value.ToString()) });
            }
            if (ReportSearchError)
            {
                MessageBox.Show("Отчеты не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Program.ConnectForm.conn.Close();
        }

        public AdminPanelForm()
        {
            InitializeComponent();
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            TabControl.SelectedIndex = 0;
            CBinstSelect.SelectedIndex = 0;
            CBInstStatQuarter1.SelectedIndex = 0;
            CBInstStatQuarter2.SelectedIndex = 3;
            for(int i = 0; i < 5; i++)
            {
                DGVinstStat.Rows.Add(CBinstSelect.Items[i].ToString(), 0, 0, 0.0);
            }
            int Year = DateTime.Now.Year;
            DateTime Quarter = Convert.ToDateTime($"1001.{DateTime.Now.Month}.{DateTime.Now.Day}");
            if (Quarter >= Convert.ToDateTime("1001.1.1") && Quarter < Convert.ToDateTime("1001.03.25"))
            {
                TBYearCompReport.Text = $"{Year - 1}";
                CBQuarterCompReport.SelectedIndex = 3;
            }
            else if (Quarter >= Convert.ToDateTime("1001.03.25") && Quarter < Convert.ToDateTime("1001.06.25"))
            {
                TBYearCompReport.Text = $"{Year}";
                CBQuarterCompReport.SelectedIndex = 0;
            }
            else if (Quarter >= Convert.ToDateTime("1001.06.25") && Quarter < Convert.ToDateTime("1001.09.25"))
            {
                TBYearCompReport.Text = $"{Year}";
                CBQuarterCompReport.SelectedIndex = 1;
            }
            else if (Quarter >= Convert.ToDateTime("1001.09.25") && Quarter < Convert.ToDateTime("1001.12.25"))
            {
                TBYearCompReport.Text = $"{Year}";
                CBQuarterCompReport.SelectedIndex = 2;
            }
            else
            {
                TBYearCompReport.Text = $"{Year}";
                CBQuarterCompReport.SelectedIndex = 3;
            }
            //Загрузка параметров плана
            try
            {
                if (Program.IF.KeyExists("PlanSettings", "Workplaces"))
                {
                    PlanSettingsParam1 = Convert.ToInt32(Program.IF.ReadINI("PlanSettings", "Workplaces"));
                }
                if (Program.IF.KeyExists("PlanSettings", "Number"))
                {
                    PlanSettingsParam2 = Convert.ToDouble(Program.IF.ReadINI("PlanSettings", "Number"));
                }
                if (Program.IF.KeyExists("PlanSettings", "Proceeds"))
                {
                    PlanSettingsParam3 = Convert.ToDouble(Program.IF.ReadINI("PlanSettings", "Proceeds"));
                }
                if (Program.IF.KeyExists("PlanSettings", "Proceeds1"))
                {
                    PlanSettingsParam4 = Convert.ToDouble(Program.IF.ReadINI("PlanSettings", "Proceeds1"));
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверные настройки параметров плана", "Ошибка чтения настроек", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SettingsAdminClient SACForm = new SettingsAdminClient();
                SACForm.ShowDialog();
            }

        }

        private void AdminPanelForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void TSMIbdShow_Click(object sender, EventArgs e)
        {
            loadingMessege = new LoadingMessegeForm();
            loadingMessege.Show();
            loadingMessege.Update();
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    LoadCompReports(ref sender, ref e);
                    break;
                case 1:
                    LoadInstStat(ref sender, ref e);
                    break;
                case 2:
                    LoadInstStat(ref sender, ref e);
                    break;
                case 3:
                    break;
            }
            loadingMessege.Close();
        }

        private void TSMIuserCreate_Click(object sender, EventArgs e)
        {
            CreateUserForm CreateUser = new CreateUserForm();
            CreateUser.Show();
            TSMIuserCreate.Enabled = false;
            CreateUser.FormClosing += (obj, arg) =>
            {
                CenterToScreen();
                Activate();
                TSMIuserCreate.Enabled = true;
            };
            CreateUser.Location = Location;
        }

        private void TSMIuserChangeDelete_Click(object sender, EventArgs e)
        {
            ChangeDeleteUserForm ChangeDeleteUser = new ChangeDeleteUserForm();
            TSMIuserChangeDelete.Enabled = false;
            ChangeDeleteUser.FormClosing += (obj, arg) =>
            {
                CenterToScreen();
                Activate();
                TSMIuserChangeDelete.Enabled = true;
            };
            ChangeDeleteUser.Show();
            ChangeDeleteUser.Location = Location;
        }

        private void CBinstSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DGVcompReport.RowCount > 0)
            {
                for (int i = 0; i < DGVcompReport.RowCount; i++)
                {
                    DGVcompReport.Rows[i].Visible = (Convert.ToInt32(DGVcompReport.Rows[i].Cells[6].Value) == CBinstSelect.SelectedIndex ? true : false);
                }
            }
        }

        private void TabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedPeriodStartBuf = DateTime.MinValue;
            switch (TabControl.SelectedIndex)
            {
                case 0:
                    Size = new Size(909, 531);
                    break;
                case 1:
                    Size = new Size(612, 531);
                    break;
                case 2:
                    Size = new Size(926, 531);
                    break;
                case 3:
                    Size = new Size(818, 531);
                    break;
            }
        }

        private void TSMIOptionsSettings_Click(object sender, EventArgs e)
        {
            SettingsAdminClient SACForm = new SettingsAdminClient();
            SACForm.ShowDialog();
        }
    }
    
    [Serializable]
    public class ExceptionShowMessageException : ApplicationException
    {
        public ExceptionShowMessageException() { }
        public ExceptionShowMessageException(string message) : base(message) { }
        public ExceptionShowMessageException(string message, Exception inner) : base(message, inner) { }
        protected ExceptionShowMessageException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }

    public struct Report
    {
        public DateTime DateQuarter, DateReportSend;
        public int[] param1, param2;
        public double[] param3;
    }

    public struct Company
    {
        public string inn, comp_name;
    }

    public struct User
    {
        public string login;
        public Company[] MasCompany;
    }  
}
