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
        protected struct Report
        {
            public DateTime date;
            public int[] param1, param2;
            public double[] param3;
        }
        private struct Reports
        {
            public string inn, comp_name;
            public Report[] reports;
            public bool ReportFound;
        }
        private Reports[] MasReportsForPeriod;
        private Reports[] MasReports;
        private bool ReportSearch = false;

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
            MasReports = null;
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
                int i;
                for (i = 0; i < MasReports.Length; i++)
                {
                    com = new MySqlCommand("select * from project.`" + MasReports[i].inn + "`  order by date desc limit 2", Program.ConnectForm.conn);
                    readed = com.ExecuteReader();

                    //MasReports[i1].reports = new Report[1];
                    //MasReports[i1].ReportFound = false;

                    while (readed.Read())//Если есть отчеты, получаем самый актуальный
                    {
                        ReportSearch = true;

                        Array.Resize(ref MasReports[i].reports, (MasReports[i].reports == null ? 1 : MasReports[i].reports.Length + 1));
                        MasReports[i].reports[MasReports[i].reports.Length - 1].date = Convert.ToDateTime(readed[0].ToString());

                        MasReports[i].reports[MasReports[i].reports.Length - 1].param1 = new int[5];
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param2 = new int[5];
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param3 = new double[5];

                        MasReports[i].reports[MasReports[i].reports.Length - 1].param1[0] = Convert.ToInt32(readed[1].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param2[0] = Convert.ToInt32(readed[2].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param3[0] = Convert.ToDouble(readed[3].ToString());

                        MasReports[i].reports[MasReports[i].reports.Length - 1].param1[1] = Convert.ToInt32(readed[4].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param2[1] = Convert.ToInt32(readed[5].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param3[1] = Convert.ToDouble(readed[6].ToString());

                        MasReports[i].reports[MasReports[i].reports.Length - 1].param1[2] = Convert.ToInt32(readed[7].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param2[2] = Convert.ToInt32(readed[8].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param3[2] = Convert.ToDouble(readed[9].ToString());

                        MasReports[i].reports[MasReports[i].reports.Length - 1].param1[3] = Convert.ToInt32(readed[10].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param2[3] = Convert.ToInt32(readed[11].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param3[3] = Convert.ToDouble(readed[12].ToString());

                        MasReports[i].reports[MasReports[i].reports.Length - 1].param1[4] = Convert.ToInt32(readed[13].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param2[4] = Convert.ToInt32(readed[14].ToString());
                        MasReports[i].reports[MasReports[i].reports.Length - 1].param3[4] = Convert.ToDouble(readed[15].ToString());
                    }
                    if (MasReports[i].reports != null)
                    {
                        MasReports[i].ReportFound = true;
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
        }

        private void CBinstSelect1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DGVcompReport.Rows.Clear();
            if (MasReports != null)
            {
                for (int i = 0; i < MasReports.Length; i++)
                {
                    if (!MasReports[i].ReportFound)
                    {
                        DGVcompReport.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, 0, 0.0, 0.0, 0.0, 3);
                        DGVcompReport.Rows[i].Cells[0].Style.BackColor = Color.LightGray;
                        DGVcompReport.Rows[i].Cells[1].Style.BackColor = Color.LightGray;
                        for (int j = 2; j <= 6; j++)
                        {
                            DGVcompReport.Rows[i].Cells[j].Style.BackColor = Color.Gray;
                        }
                        DGVcompReport.Rows[i].Cells[6].Style.ForeColor = Color.Gray;
                        break;
                    }
                    else
                    {
                        switch (MasReports[i].reports.Length)
                        {
                            case 1:
                                {
                                    int param1 = MasReports[i].reports[0].param1[CBinstSelect2.SelectedIndex];
                                    double param2 = MasReports[i].reports[0].param2[CBinstSelect2.SelectedIndex];
                                    double param3 = MasReports[i].reports[0].param3[CBinstSelect2.SelectedIndex];
                                    DGVcompReport.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, 0.0, 2);
                                    for (int j = 0; j <= 6; j++)
                                    {
                                        DGVcompReport.Rows[i].Cells[j].Style.BackColor = Color.LightGray;
                                    }
                                    DGVcompReport.Rows[i].Cells[6].Style.ForeColor = Color.LightGray;
                                    break;
                                }
                            case 2:
                                {
                                    int param1 = MasReports[i].reports[0].param1[CBinstSelect2.SelectedIndex] - MasReports[i].reports[1].param1[CBinstSelect2.SelectedIndex];
                                    double param2 = (MasReports[i].reports[1].param2[CBinstSelect2.SelectedIndex] == 0 ? MasReports[i].reports[0].param2[CBinstSelect2.SelectedIndex] : MasReports[i].reports[0].param2[CBinstSelect2.SelectedIndex] * 100.0 / MasReports[i].reports[1].param2[CBinstSelect2.SelectedIndex] - 100);
                                    double param3 = MasReports[i].reports[0].param3[CBinstSelect2.SelectedIndex] - MasReports[i].reports[1].param3[CBinstSelect2.SelectedIndex];
                                    double param4 = (MasReports[i].reports[1].param3[CBinstSelect2.SelectedIndex] == 0 ? MasReports[i].reports[0].param2[CBinstSelect2.SelectedIndex] : MasReports[i].reports[0].param3[CBinstSelect2.SelectedIndex] * 100.0 / MasReports[i].reports[1].param3[CBinstSelect2.SelectedIndex] - 100);

                                    int random = r.Next(0, 2);
                                    DGVcompReport.Rows.Add(MasReports[i].comp_name, MasReports[i].inn, param1, param2, param3, param4, random);
                                    if (random == 0)
                                    {
                                        DGVcompReport.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                        DGVcompReport.Rows[i].Cells[6].Style.ForeColor = Color.Red;
                                    }
                                    else
                                    {
                                        DGVcompReport.Rows[i].Cells[6].Style.BackColor = Color.Green;
                                        DGVcompReport.Rows[i].Cells[6].Style.ForeColor = Color.Green;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }

        private void AdminPanelForm_Load(object sender, EventArgs e)
        {
            //this.Size = new Size(953, 531);

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

        /*private void Bset_Click(object sender, EventArgs e)
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
        }*/

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
