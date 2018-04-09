using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace hahatonProjectAdmin
{
    public partial class ConnectForm : Form
    {
        public MySqlConnection conn;
        //private SendRepForm ReportForm;
        //private SettingsForm SetForm;
        public string ConnectAdress;
        public string ConnectPort;
        public string NameDB;
        public string login;

        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            while (true)//Проверка интернета
            {
                try
                {
                    // Create a request for the URL.        
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.google.ru/");
                    request.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1)";
                    request.Timeout = 10000;

                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream ReceiveStream1 = response.GetResponseStream();
                    StreamReader sr = new StreamReader(ReceiveStream1, true);
                    string responseFromServer = sr.ReadToEnd();

                    response.Close();
                    break;
                }
                catch (Exception)
                {
                    DialogResult = MessageBox.Show("Нет подключения к интернету\nПроверьте Ваш фаервол или настройки сетевого подключения", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                    if(DialogResult == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                    }
                    continue;
                }
            }
            /*if (!Program.IF.KeyExists("ConnSett", "Adress") || !Program.IF.KeyExists("ConnSett", "DBname") || !Program.IF.KeyExists("ConnSett", "Port"))//Проверка файла настроек
            {
                SetForm = new SettingsForm();
                this.Hide();
                MessageBox.Show("Первый запуск. Введите настройки.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetForm.FormClosing += (obj, arg) =>
                {
                    this.Show();
                };
                SetForm.ShowDialog();
            }*/
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBLogin.Text != "" && TBPass.Text != "")
                {
                    ConnectAdress = Program.IF.ReadINI("ConnSett", "Adress");
                    NameDB = Program.IF.ReadINI("ConnSett", "DBname");
                    ConnectPort = Program.IF.ReadINI("ConnSett", "Port");

                    conn = new MySqlConnection("server=" + ConnectAdress + ";user=" + TBLogin.Text + ";database=" + NameDB + ";password=" + TBPass.Text + ";port=" + ConnectPort + ";");

                    conn.Open();

                    if (conn.State == ConnectionState.Open)
                    {
                        login = TBLogin.Text;
                        //ReportForm = new SendRepForm();
                        this.Hide();
                        conn.Close();
                        //ReportForm.Show();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось подключится к базе данных. Проверьте настройки.", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин и пароль");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось подключится к базе данных. Проверьте настройки.\n", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*SetForm = new SettingsForm();

            SetForm.FormClosing += (obj, arg) =>
            {
            };
            SetForm.ShowDialog();*/
        }

    }
}
