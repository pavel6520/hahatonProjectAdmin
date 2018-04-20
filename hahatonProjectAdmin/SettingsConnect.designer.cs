namespace hahatonProjectAdmin
{
    partial class SettingsConnectForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TBip = new System.Windows.Forms.TextBox();
            this.TBdatabase = new System.Windows.Forms.TextBox();
            this.LabelIP = new System.Windows.Forms.Label();
            this.LabelBDname = new System.Windows.Forms.Label();
            this.BSave = new System.Windows.Forms.Button();
            this.LabelPort = new System.Windows.Forms.Label();
            this.TBport = new System.Windows.Forms.TextBox();
            this.LipErr = new System.Windows.Forms.Label();
            this.LportErr = new System.Windows.Forms.Label();
            this.LdbErr = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TBip
            // 
            this.TBip.Location = new System.Drawing.Point(116, 6);
            this.TBip.Name = "TBip";
            this.TBip.Size = new System.Drawing.Size(156, 20);
            this.TBip.TabIndex = 0;
            // 
            // TBdatabase
            // 
            this.TBdatabase.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            this.TBdatabase.Location = new System.Drawing.Point(116, 58);
            this.TBdatabase.Name = "TBdatabase";
            this.TBdatabase.Size = new System.Drawing.Size(156, 20);
            this.TBdatabase.TabIndex = 2;
            // 
            // LabelIP
            // 
            this.LabelIP.AutoSize = true;
            this.LabelIP.Location = new System.Drawing.Point(15, 9);
            this.LabelIP.Name = "LabelIP";
            this.LabelIP.Size = new System.Drawing.Size(98, 13);
            this.LabelIP.TabIndex = 2;
            this.LabelIP.Text = "IP-адрес сервера:";
            // 
            // LabelBDname
            // 
            this.LabelBDname.AutoSize = true;
            this.LabelBDname.Location = new System.Drawing.Point(9, 61);
            this.LabelBDname.Name = "LabelBDname";
            this.LabelBDname.Size = new System.Drawing.Size(101, 13);
            this.LabelBDname.TabIndex = 3;
            this.LabelBDname.Text = "Имя базы данных:";
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(184, 112);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(75, 23);
            this.BSave.TabIndex = 3;
            this.BSave.Text = "Сохранить";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // LabelPort
            // 
            this.LabelPort.AutoSize = true;
            this.LabelPort.Location = new System.Drawing.Point(75, 35);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(35, 13);
            this.LabelPort.TabIndex = 5;
            this.LabelPort.Text = "Порт:";
            // 
            // TBport
            // 
            this.TBport.Location = new System.Drawing.Point(116, 32);
            this.TBport.MaxLength = 5;
            this.TBport.Name = "TBport";
            this.TBport.Size = new System.Drawing.Size(39, 20);
            this.TBport.TabIndex = 1;
            // 
            // LipErr
            // 
            this.LipErr.AutoSize = true;
            this.LipErr.ForeColor = System.Drawing.Color.Red;
            this.LipErr.Location = new System.Drawing.Point(278, 9);
            this.LipErr.Name = "LipErr";
            this.LipErr.Size = new System.Drawing.Size(158, 13);
            this.LipErr.TabIndex = 6;
            this.LipErr.Text = "Обязательно для заполнения";
            this.LipErr.Visible = false;
            // 
            // LportErr
            // 
            this.LportErr.AutoSize = true;
            this.LportErr.ForeColor = System.Drawing.Color.Red;
            this.LportErr.Location = new System.Drawing.Point(161, 35);
            this.LportErr.Name = "LportErr";
            this.LportErr.Size = new System.Drawing.Size(158, 13);
            this.LportErr.TabIndex = 7;
            this.LportErr.Text = "Обязательно для заполнения";
            this.LportErr.Visible = false;
            // 
            // LdbErr
            // 
            this.LdbErr.AutoSize = true;
            this.LdbErr.ForeColor = System.Drawing.Color.Red;
            this.LdbErr.Location = new System.Drawing.Point(278, 61);
            this.LdbErr.Name = "LdbErr";
            this.LdbErr.Size = new System.Drawing.Size(158, 13);
            this.LdbErr.TabIndex = 8;
            this.LdbErr.Text = "Обязательно для заполнения";
            this.LdbErr.Visible = false;
            // 
            // SettingsConnectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 147);
            this.Controls.Add(this.LdbErr);
            this.Controls.Add(this.LportErr);
            this.Controls.Add(this.LipErr);
            this.Controls.Add(this.TBport);
            this.Controls.Add(this.LabelPort);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.LabelBDname);
            this.Controls.Add(this.LabelIP);
            this.Controls.Add(this.TBdatabase);
            this.Controls.Add(this.TBip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsConnectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TBip;
        private System.Windows.Forms.TextBox TBdatabase;
        private System.Windows.Forms.Label LabelIP;
        private System.Windows.Forms.Label LabelBDname;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.Label LabelPort;
        private System.Windows.Forms.TextBox TBport;
        private System.Windows.Forms.Label LipErr;
        private System.Windows.Forms.Label LportErr;
        private System.Windows.Forms.Label LdbErr;
    }
}