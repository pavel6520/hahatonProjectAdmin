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
        public AdminPanelForm AdminPanel;
        private SettingsConnectForm SetForm;
        public string login;
        private string ConnectStr;

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
            if (!Program.IF.KeyExists("ConnSett", "Adress") || !Program.IF.KeyExists("ConnSett", "DBname") || !Program.IF.KeyExists("ConnSett", "Port"))//Проверка файла настроек
            {
                SetForm = new SettingsConnectForm();
                this.Hide();
                MessageBox.Show("Первый запуск. Введите настройки.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetForm.FormClosing += (obj, arg) =>
                {
                    this.Show();
                };
                SetForm.ShowDialog();
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (TBPass.Text.IndexOf('\'') != -1 || TBPass.Text.IndexOf('`') != -1){
                    MessageBox.Show("Недопустимые символы в пароле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (TBLogin.Text != "" && TBPass.Text != "")
                {
                    ConnectStr = 
                        $"server={Program.IF.ReadINI("ConnSett", "Adress")};" +
                        $"port={Program.IF.ReadINI("ConnSett", "Port")};" +
                        $"user={TBLogin.Text};" +
                        $"password={TBPass.Text};" +
                        $"database={Program.IF.ReadINI("ConnSett", "DBname")};";
                    conn = new MySqlConnection(ConnectStr);
                    conn.Open();
                    conn.Close();
                    login = TBLogin.Text;
                    AdminPanel = new AdminPanelForm();
                    this.Hide();
                    AdminPanel.Show();
                }
                else
                {
                    MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось подключится к базе данных. Проверьте настройки.\n{ex.Message}", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetForm = new SettingsConnectForm();

            SetForm.FormClosing += (obj, arg) =>
            {
            };
            SetForm.ShowDialog();
        }

        private void TBLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123)
                && (e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 45 && e.KeyChar != 95)
                e.Handled = true;
        }

        private void TBPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 64 || e.KeyChar >= 91) && (e.KeyChar <= 96 || e.KeyChar >= 123)
                && (e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 35 && e.KeyChar != 36
                && e.KeyChar != 38 && e.KeyChar != 63 && e.KeyChar != 64 && e.KeyChar != 37 &&
                e.KeyChar != 22)
                e.Handled = true;
        }
    }
}
