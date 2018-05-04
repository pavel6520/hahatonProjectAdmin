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
                catch (Exception ex)
                {
                    DialogResult = MessageBox.Show($"Нет подключения к интернету\n{ex.Message}", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
                    if(DialogResult == DialogResult.Cancel)
                    {
                        Environment.Exit(0);
                    }
                    continue;
                }
            }
            if (!Program.IF.KeyExists("ConnSett", "Address") || !Program.IF.KeyExists("ConnSett", "DBname") || !Program.IF.KeyExists("ConnSett", "Port"))//Проверка файла настроек
            {
                SetForm = new SettingsConnectForm();
                Hide();
                MessageBox.Show("Первый запуск. Введите настройки.", "Сообщение", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetForm.FormClosing += (obj, arg) =>
                {
                    Show();
                };
                SetForm.ShowDialog();
            }
        }

        private void ButtonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validation.StringValidation(Validation.ValidationType.LoginType, TBLogin.Text))
                {
                    MessageBox.Show("Недопустимые символы в логине", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!Validation.StringValidation(Validation.ValidationType.PasswordType, TBPass.Text))
                {
                    MessageBox.Show("Недопустимые символы в пароле", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (TBLogin.Text != "" && TBPass.Text != "")
                {
                    ConnectStr = 
                        $"server={Program.IF.ReadINI("ConnSett", "Address")};" +
                        $"port={Program.IF.ReadINI("ConnSett", "Port")};" +
                        $"user={TBLogin.Text};" +
                        $"password={TBPass.Text};" +
                        $"database={Program.IF.ReadINI("ConnSett", "DBname")};";
                    conn = new MySqlConnection(ConnectStr);
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                        login = TBLogin.Text;
                        AdminPanel = new AdminPanelForm();
                        Hide();
                        AdminPanel.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Введите логин и пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            SetForm.ShowDialog();
        }

        private void TBLogin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.CharValidation(Validation.ValidationType.LoginType, e.KeyChar, PasteMode: true);
        }

        private void TBPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !Validation.CharValidation(Validation.ValidationType.PasswordType, e.KeyChar, PasteMode: true);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            TBPass.UseSystemPasswordChar = !checkBox1.Checked;
        }
    }
}
