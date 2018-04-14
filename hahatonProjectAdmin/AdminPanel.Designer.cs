namespace hahatonProjectAdmin
{
    partial class AdminPanelForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMIdb = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIdbShow = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIuser = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIuserCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.TCinst = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.MC1 = new System.Windows.Forms.MonthCalendar();
            this.Bselect_date = new System.Windows.Forms.Button();
            this.CBinstSelect1 = new System.Windows.Forms.ComboBox();
            this.DGVinst = new System.Windows.Forms.DataGridView();
            this.compName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pschr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvmr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvPercents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inst1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NONW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.Bdia_set = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.TCinst.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVinst)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIdb,
            this.TSMIuser});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(937, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // TSMIdb
            // 
            this.TSMIdb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIdbShow});
            this.TSMIdb.Name = "TSMIdb";
            this.TSMIdb.Size = new System.Drawing.Size(86, 20);
            this.TSMIdb.Text = "База данных";
            // 
            // TSMIdbShow
            // 
            this.TSMIdbShow.Name = "TSMIdbShow";
            this.TSMIdbShow.ShortcutKeyDisplayString = "F1";
            this.TSMIdbShow.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.TSMIdbShow.Size = new System.Drawing.Size(150, 22);
            this.TSMIdbShow.Text = "&Просмотр";
            this.TSMIdbShow.Click += new System.EventHandler(this.TSMIbdShow_Click);
            // 
            // TSMIuser
            // 
            this.TSMIuser.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIuserCreate});
            this.TSMIuser.Name = "TSMIuser";
            this.TSMIuser.Size = new System.Drawing.Size(97, 20);
            this.TSMIuser.Text = "Пользователи";
            // 
            // TSMIuserCreate
            // 
            this.TSMIuserCreate.Name = "TSMIuserCreate";
            this.TSMIuserCreate.ShortcutKeyDisplayString = "";
            this.TSMIuserCreate.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.TSMIuserCreate.Size = new System.Drawing.Size(136, 22);
            this.TSMIuserCreate.Text = "&Создать";
            this.TSMIuserCreate.Click += new System.EventHandler(this.TSMIuserCreate_Click);
            // 
            // TCinst
            // 
            this.TCinst.Controls.Add(this.tabPage2);
            this.TCinst.Controls.Add(this.tabPage1);
            this.TCinst.Controls.Add(this.tabPage3);
            this.TCinst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCinst.Location = new System.Drawing.Point(0, 24);
            this.TCinst.Multiline = true;
            this.TCinst.Name = "TCinst";
            this.TCinst.SelectedIndex = 0;
            this.TCinst.Size = new System.Drawing.Size(937, 469);
            this.TCinst.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.MC1);
            this.tabPage2.Controls.Add(this.Bselect_date);
            this.tabPage2.Controls.Add(this.CBinstSelect1);
            this.tabPage2.Controls.Add(this.DGVinst);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(929, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Институты поддержки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // MC1
            // 
            this.MC1.Location = new System.Drawing.Point(765, 21);
            this.MC1.Name = "MC1";
            this.MC1.TabIndex = 3;
            this.MC1.Visible = false;
            this.MC1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MC1_DateSelected);
            // 
            // Bselect_date
            // 
            this.Bselect_date.Location = new System.Drawing.Point(824, -1);
            this.Bselect_date.Name = "Bselect_date";
            this.Bselect_date.Size = new System.Drawing.Size(105, 22);
            this.Bselect_date.TabIndex = 2;
            this.Bselect_date.Text = "Выбрать период";
            this.Bselect_date.UseVisualStyleBackColor = true;
            this.Bselect_date.Click += new System.EventHandler(this.Bselect_date_Click);
            // 
            // CBinstSelect1
            // 
            this.CBinstSelect1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBinstSelect1.FormattingEnabled = true;
            this.CBinstSelect1.Items.AddRange(new object[] {
            "Фонд Микрофинансирования",
            "Гарантийный фонд",
            "Центр кластерного развития",
            "Центр поддержки предпринимательства",
            "Центр экспорта"});
            this.CBinstSelect1.Location = new System.Drawing.Point(0, 0);
            this.CBinstSelect1.Name = "CBinstSelect1";
            this.CBinstSelect1.Size = new System.Drawing.Size(240, 21);
            this.CBinstSelect1.TabIndex = 1;
            this.CBinstSelect1.SelectedIndexChanged += new System.EventHandler(this.CBinstSelect1_SelectedIndexChanged);
            // 
            // DGVinst
            // 
            this.DGVinst.AllowUserToAddRows = false;
            this.DGVinst.AllowUserToDeleteRows = false;
            this.DGVinst.AllowUserToResizeColumns = false;
            this.DGVinst.AllowUserToResizeRows = false;
            this.DGVinst.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVinst.BackgroundColor = System.Drawing.Color.White;
            this.DGVinst.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVinst.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.compName,
            this.inn,
            this.vsm,
            this.pschr,
            this.pvmr,
            this.pvPercents,
            this.plan1,
            this.inst});
            this.DGVinst.Location = new System.Drawing.Point(0, 21);
            this.DGVinst.Name = "DGVinst";
            this.DGVinst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGVinst.Size = new System.Drawing.Size(929, 422);
            this.DGVinst.TabIndex = 0;
            // 
            // compName
            // 
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compName.DefaultCellStyle = dataGridViewCellStyle22;
            this.compName.HeaderText = "Компания";
            this.compName.Name = "compName";
            this.compName.ReadOnly = true;
            this.compName.Width = 200;
            // 
            // inn
            // 
            this.inn.HeaderText = "ИНН";
            this.inn.Name = "inn";
            this.inn.ReadOnly = true;
            // 
            // vsm
            // 
            this.vsm.FillWeight = 120F;
            this.vsm.HeaderText = "Вновь созданые места, чел";
            this.vsm.Name = "vsm";
            this.vsm.ReadOnly = true;
            this.vsm.Width = 120;
            // 
            // pschr
            // 
            dataGridViewCellStyle23.Format = "N2";
            dataGridViewCellStyle23.NullValue = null;
            this.pschr.DefaultCellStyle = dataGridViewCellStyle23;
            this.pschr.HeaderText = "Прирост среднесписочной численности работников, %";
            this.pschr.Name = "pschr";
            this.pschr.ReadOnly = true;
            this.pschr.Width = 200;
            // 
            // pvmr
            // 
            this.pvmr.HeaderText = "Прирост выручки, млн. руб";
            this.pvmr.Name = "pvmr";
            this.pvmr.ReadOnly = true;
            this.pvmr.Width = 130;
            // 
            // pvPercents
            // 
            dataGridViewCellStyle24.Format = "N2";
            dataGridViewCellStyle24.NullValue = null;
            this.pvPercents.DefaultCellStyle = dataGridViewCellStyle24;
            this.pvPercents.HeaderText = "Прирост выручки, %";
            this.pvPercents.Name = "pvPercents";
            this.pvPercents.ReadOnly = true;
            this.pvPercents.Width = 70;
            // 
            // plan1
            // 
            this.plan1.HeaderText = "План";
            this.plan1.Name = "plan1";
            this.plan1.ReadOnly = true;
            this.plan1.Width = 66;
            // 
            // inst
            // 
            this.inst.HeaderText = "Институт поддержки";
            this.inst.Name = "inst";
            this.inst.ReadOnly = true;
            this.inst.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.inst.Visible = false;
            this.inst.Width = 215;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(929, 443);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Компании";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inst1,
            this.NONW,
            this.SN,
            this.Money});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(923, 437);
            this.dataGridView1.TabIndex = 0;
            // 
            // inst1
            // 
            this.inst1.HeaderText = "Институт поддержки";
            this.inst1.Name = "inst1";
            this.inst1.Width = 200;
            // 
            // NONW
            // 
            this.NONW.HeaderText = "Кол-во созданных мест";
            this.NONW.Name = "NONW";
            this.NONW.ReadOnly = true;
            // 
            // SN
            // 
            this.SN.HeaderText = "Кол-во сотрудников";
            this.SN.Name = "SN";
            this.SN.ReadOnly = true;
            // 
            // Money
            // 
            this.Money.HeaderText = "Выручка";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            this.Money.Width = 120;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Bdia_set);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(929, 443);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Диаграмма";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(120, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 283);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(17, 96);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(33, 185);
            this.panel2.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Location = new System.Drawing.Point(56, 96);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(33, 185);
            this.panel3.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Yellow;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Location = new System.Drawing.Point(95, 96);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(33, 185);
            this.panel4.TabIndex = 2;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Olive;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Location = new System.Drawing.Point(134, 96);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(33, 185);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.LawnGreen;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Location = new System.Drawing.Point(173, 96);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(33, 185);
            this.panel6.TabIndex = 3;
            // 
            // Bdia_set
            // 
            this.Bdia_set.Location = new System.Drawing.Point(492, 169);
            this.Bdia_set.Name = "Bdia_set";
            this.Bdia_set.Size = new System.Drawing.Size(95, 28);
            this.Bdia_set.TabIndex = 1;
            this.Bdia_set.Text = "Составить";
            this.Bdia_set.UseVisualStyleBackColor = true;
            this.Bdia_set.Click += new System.EventHandler(this.Bdia_set_Click);
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(937, 493);
            this.Controls.Add(this.TCinst);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanelForm_FormClosed);
            this.Load += new System.EventHandler(this.AdminPanelForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TCinst.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVinst)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIuser;
        private System.Windows.Forms.ToolStripMenuItem TSMIuserCreate;
        private System.Windows.Forms.TabControl TCinst;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DGVinst;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CBinstSelect1;
        private System.Windows.Forms.ToolStripMenuItem TSMIdb;
        private System.Windows.Forms.ToolStripMenuItem TSMIdbShow;
        private System.Windows.Forms.DataGridViewTextBoxColumn compName;
        private System.Windows.Forms.DataGridViewTextBoxColumn inn;
        private System.Windows.Forms.DataGridViewTextBoxColumn vsm;
        private System.Windows.Forms.DataGridViewTextBoxColumn pschr;
        private System.Windows.Forms.DataGridViewTextBoxColumn pvmr;
        private System.Windows.Forms.DataGridViewTextBoxColumn pvPercents;
        private System.Windows.Forms.DataGridViewTextBoxColumn plan1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inst;
        private System.Windows.Forms.DataGridViewTextBoxColumn inst1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NONW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
        private System.Windows.Forms.Button Bselect_date;
        private System.Windows.Forms.MonthCalendar MC1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button Bdia_set;
    }
}