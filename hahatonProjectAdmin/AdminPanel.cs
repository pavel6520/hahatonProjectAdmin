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
        public struct Report
        {
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
        private Random r = new Random();
        private DateTime SelectedPeriodStart = DateTime.MinValue, SelectedPeriodEnd = DateTime.MinValue;
        private DateTime SelectedPeriodStartBuf = DateTime.MinValue;
        public int PlanSettingsParam1;
        public double PlanSettingsParam2, PlanSettingsParam3, PlanSettingsParam4;

        /// <summary>
        /// Возвращает массива структур, содержащий ИНН и имена компаний
        /// </summary>
        public Company[] GetCompany()
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
                throw new MySqlQueryException(ex.Message);
                //MessageBox.Show("Ошибка получения данных компаний\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return MasCompany;
        }

        /// <summary>
        /// Возвращает массив структур, в каждом элементе которого содержатся логин пользователя и массива структур, содержащий ИНН и имена компаний пользователя
        /// </summary>
        public User[] GetUserCompanies()
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
                throw new MySqlQueryException(ex.Message);
                //MessageBox.Show("Ошибка получения списка пользователей\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                for(int i = 0; i < MasUsers.Length; i++)
                {
                    com = new MySqlCommand("select inn, comp_name from project.login_inn where login = '" + MasUsers[i].login + "' order by inn", Program.ConnectForm.conn);
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
                throw new MySqlQueryException(ex.Message);
                //MessageBox.Show("Ошибка получения списка пользователей\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return MasUsers;
        }

        /// <summary>
        /// Возвращает массив ключей (уникальные дата и время) самых актуальных отчетов за указанный период
        /// </summary>
        /// <param name="CompanyRef">Структура, содержащая ИНН компании, для которой необходимо загрузить ключи отчетов</param>
        public DateTime[] GetLastReportDateTime(ref Company CompanyRef)
        {
            MySqlCommand com;
            MySqlDataReader reader;
            DateTime[] MasReportTime = null;
            try
            {
                com = new MySqlCommand("select distinct date from project.`" + CompanyRef.inn + "` order by date desc limit 2", Program.ConnectForm.conn);
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    Array.Resize(ref MasReportTime, (MasReportTime == null ? 1 : MasReportTime.Length + 1));
                    MasReportTime[MasReportTime.Length - 1] = Convert.ToDateTime(reader[0].ToString());
                    //MessageBox.Show("1. " + MasReportQuarter[countReports - 1].ToString("yyyy.MM.dd"));
                }
                reader.Close();
                if (MasReportTime == null)
                {
                    return null;
                }
                for (int j = 0; j < MasReportTime.Length; j++)
                {
                    com = new MySqlCommand("select datereport from project.`" + CompanyRef.inn + "` where Date = '" + MasReportTime[j].ToString("yyyy.MM.dd") + "' order by datereport desc limit 1", Program.ConnectForm.conn);
                    reader = com.ExecuteReader();
                    reader.Read();
                    MasReportTime[j] = Convert.ToDateTime(reader[0].ToString());
                    reader.Close();
                    //MessageBox.Show("2. " + MasReportQuarter[j].ToString("yyyy.MM.dd") + " " + MasReportTimeSended[j].ToString("yyyy.MM.dd HH:mm:ss"));
                }
            }
            catch (MySqlException ex)
            {
                throw new MySqlQueryException(ex.Message);
                //MessageBox.Show("Ошибка получения кварталов отчетов\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return MasReportTime;
        }

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
            DGVcompReport.Rows.Clear();
            try
            {
                Program.ConnectForm.conn.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Не удалось подключится к базе данных.\n" + ex.Message, "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                Company[] MasCompany;
                //Загрузка ИНН, имен компаний
                try
                {
                    MasCompany = GetCompany();
                }
                catch (MySqlQueryException ex)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show("Ошибка получения списка компаний\n" + ex.Message);
                    return;
                }
                if (MasCompany == null)
                {
                    Program.ConnectForm.conn.Close();
                    MessageBox.Show("Компании не найдены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MySqlCommand com;
                MySqlDataReader readed;
                bool ReportSearchError = true;
                for (int i = 0; i < MasCompany.Length; i++)
                {
                    DateTime[] MasReportTimeSended;
                    //Загрузка даты двух последних отчетов компании
                    try
                    {
                        MasReportTimeSended = GetLastReportDateTime(ref MasCompany[i]);
                    }
                    catch (MySqlQueryException ex)
                    {
                        Program.ConnectForm.conn.Close();
                        MessageBox.Show("Ошибка получения кварталов отчетов\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    ReportSearchError = (MasReportTimeSended == null ? true : false);
                    Report[] MasCompanyReports = null;
                    
                    //Получаем отчеты по ключу-дате
                    for (int j = 0; j < MasReportTimeSended.Length; j++)
                    {
                        //MessageBox.Show("3. " + MasReportTimeSended[j].ToString("yyyy.MM.dd HH:mm:ss"));
                        com = new MySqlCommand("select FM1, FM2, FM3, GF1, GF2, GF3, CKR1, CKR2, CKR3, CPP1, CPP2, CPP3, CE1, CE2, CE3 from project.`" + MasCompany[i].inn + "` where datereport = '" + 
                            MasReportTimeSended[j].ToString("yyyy.MM.dd HH:mm:ss") + 
                            "' order by DateReport desc limit 1", Program.ConnectForm.conn);
                        readed = com.ExecuteReader();
                        readed.Read();
                        Array.Resize(ref MasCompanyReports, j + 1);
                        MasCompanyReports[j].param1 = new int[5];
                        MasCompanyReports[j].param1[0] = Convert.ToInt32(readed[0].ToString());
                        MasCompanyReports[j].param1[1] = Convert.ToInt32(readed[3].ToString());
                        MasCompanyReports[j].param1[2] = Convert.ToInt32(readed[6].ToString());
                        MasCompanyReports[j].param1[3] = Convert.ToInt32(readed[9].ToString());
                        MasCompanyReports[j].param1[4] = Convert.ToInt32(readed[12].ToString());
                        MasCompanyReports[j].param2 = new int[5];
                        MasCompanyReports[j].param2[0] = Convert.ToInt32(readed[1].ToString());
                        MasCompanyReports[j].param2[1] = Convert.ToInt32(readed[4].ToString());
                        MasCompanyReports[j].param2[2] = Convert.ToInt32(readed[7].ToString());
                        MasCompanyReports[j].param2[3] = Convert.ToInt32(readed[10].ToString());
                        MasCompanyReports[j].param2[4] = Convert.ToInt32(readed[13].ToString());
                        MasCompanyReports[j].param3 = new double[5];
                        MasCompanyReports[j].param3[0] = Convert.ToDouble(readed[2].ToString());
                        MasCompanyReports[j].param3[1] = Convert.ToDouble(readed[5].ToString());
                        MasCompanyReports[j].param3[2] = Convert.ToDouble(readed[8].ToString());
                        MasCompanyReports[j].param3[3] = Convert.ToDouble(readed[11].ToString());
                        MasCompanyReports[j].param3[4] = Convert.ToDouble(readed[14].ToString());
                        readed.Close();
                    }
                    for (int j = 0; j <= 4; j++)
                    {
                        if (MasCompanyReports == null)
                        {
                            DGVcompReport.Rows.Add(MasCompany[i].comp_name, MasCompany[i].inn, 0, 0.0, 0.0, 0.0, 3);
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
                            switch (MasCompanyReports.Length)
                            {
                                case 1:
                                    {
                                        int param1 = MasCompanyReports[0].param1[j];
                                        double param2 = MasCompanyReports[0].param2[j];
                                        double param3 = MasCompanyReports[0].param3[j];
                                        DGVcompReport.Rows.Add(MasCompany[i].comp_name, MasCompany[i].inn, param1, param2, param3, 0.0, 2);
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
                                        int param1 = MasCompanyReports[0].param1[j] - MasCompanyReports[1].param1[j];
                                        double param2 = (MasCompanyReports[1].param2[j] == 0 ? MasCompanyReports[0].param2[j] : MasCompanyReports[0].param2[j] * 100.0 / MasCompanyReports[1].param2[j] - 100);
                                        double param3 = MasCompanyReports[0].param3[j] - MasCompanyReports[1].param3[j];
                                        double param4 = (MasCompanyReports[1].param3[j] == 0 ? MasCompanyReports[0].param2[j] : MasCompanyReports[0].param3[j] * 100.0 / MasCompanyReports[1].param3[j] - 100);
                                        int random = r.Next(0, 2);
                                        DGVcompReport.Rows.Add(MasCompany[i].comp_name, MasCompany[i].inn, param1, param2, param3, param4);
                                        DGVcompReport.Rows[i * 5 + j].Cells[2].Style.BackColor = (param1 >= PlanSettingsParam1 ? Color.LightGreen : Color.PaleVioletRed);
                                        DGVcompReport.Rows[i * 5 + j].Cells[3].Style.BackColor = (param2 >= PlanSettingsParam2 ? Color.LightGreen : Color.PaleVioletRed);
                                        DGVcompReport.Rows[i * 5 + j].Cells[4].Style.BackColor = (param3 >= PlanSettingsParam3 ? Color.LightGreen : Color.PaleVioletRed);
                                        DGVcompReport.Rows[i * 5 + j].Cells[5].Style.BackColor = (param4 >= PlanSettingsParam4 ? Color.LightGreen : Color.PaleVioletRed);
                                        break;
                                    }
                            }
                        }
                    }
                }
                if (ReportSearchError)
                {
                    MessageBox.Show("Отчеты не найдены", "Ошибка загрузки", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Program.ConnectForm.conn.Close();
            }
            catch (MySqlException ex)
            {
                Program.ConnectForm.conn.Close();
                MessageBox.Show("Ошибка выполнения запроса. Обратитесь к системному администратору.\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (CBinstSelect2.SelectedIndex == 0)
            {
                CBinstSelect2_SelectedIndexChanged(sender, e);
            }
            else
            {
                CBinstSelect2.SelectedIndex = 0;
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
            CBinstSelect2.SelectedIndex = 0;
            CBinstSelect3.SelectedIndex = 0;
            //Загрузка параметров плана
            try
            {
                if (Program.IF.KeyExists("PlanSettings", "Number"))
                {
                    PlanSettingsParam1 = Convert.ToInt32(Program.IF.ReadINI("PlanSettings", "Number"));
                }
            }
            catch (FormatException) { }
            try
            {
                if (Program.IF.KeyExists("PlanSettings", "Workplaces"))
                {
                    PlanSettingsParam2 = Convert.ToDouble(Program.IF.ReadINI("PlanSettings", "Workplaces"));
                }
            }
            catch (FormatException) { }
            try
            {
                if (Program.IF.KeyExists("PlanSettings", "Proceeds"))
                {
                    PlanSettingsParam3 = Convert.ToDouble(Program.IF.ReadINI("PlanSettings", "Proceeds"));
                }
            }
            catch (FormatException) { }
            try
            {
                if (Program.IF.KeyExists("PlanSettings", "Proceeds1"))
                {
                    PlanSettingsParam4 = Convert.ToDouble(Program.IF.ReadINI("PlanSettings", "Proceeds1"));
                }
            }
            catch (FormatException) { }
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

        private void TSMIOptionsSettings_Click(object sender, EventArgs e)
        {
            SettingsAdminClient SACForm = new SettingsAdminClient();
            SACForm.ShowDialog();
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
    
    [Serializable]
    public class MySqlQueryException : ApplicationException
    {
        public MySqlQueryException() { }
        public MySqlQueryException(string message) : base(message) { }
        public MySqlQueryException(string message, Exception inner) : base(message, inner) { }
        protected MySqlQueryException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
