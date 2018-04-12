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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMIdb = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIdbShow = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIuser = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIuserCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.TCinst = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CBinstSelect1 = new System.Windows.Forms.ComboBox();
            this.DGVinst = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.inst1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.compName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pschr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvmr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvPercents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.TCinst.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVinst)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIdb,
            this.TSMIuser});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
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
            this.TSMIdbShow.Size = new System.Drawing.Size(131, 22);
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
            this.TSMIuserCreate.Size = new System.Drawing.Size(117, 22);
            this.TSMIuserCreate.Text = "&Создать";
            this.TSMIuserCreate.Click += new System.EventHandler(this.TSMIuserCreate_Click);
            // 
            // TCinst
            // 
            this.TCinst.Controls.Add(this.tabPage2);
            this.TCinst.Controls.Add(this.tabPage1);
            this.TCinst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TCinst.Location = new System.Drawing.Point(0, 24);
            this.TCinst.Multiline = true;
            this.TCinst.Name = "TCinst";
            this.TCinst.SelectedIndex = 0;
            this.TCinst.Size = new System.Drawing.Size(764, 478);
            this.TCinst.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CBinstSelect1);
            this.tabPage2.Controls.Add(this.DGVinst);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(756, 452);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Институты поддержки";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            this.CBinstSelect1.Size = new System.Drawing.Size(344, 21);
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
            this.DGVinst.Size = new System.Drawing.Size(756, 431);
            this.DGVinst.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(982, 461);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Компании";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inst1});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(976, 455);
            this.dataGridView1.TabIndex = 0;
            // 
            // inst1
            // 
            this.inst1.HeaderText = "Институт поддержки";
            this.inst1.Name = "inst1";
            // 
            // compName
            // 
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
            this.vsm.HeaderText = "Вновь созданые места, чел";
            this.vsm.Name = "vsm";
            this.vsm.ReadOnly = true;
            // 
            // pschr
            // 
            this.pschr.HeaderText = "Прирост среднесписочной численности работников, %";
            this.pschr.Name = "pschr";
            this.pschr.ReadOnly = true;
            // 
            // pvmr
            // 
            this.pvmr.HeaderText = "Прирост выручки, млн. руб";
            this.pvmr.Name = "pvmr";
            this.pvmr.ReadOnly = true;
            this.pvmr.Width = 70;
            // 
            // pvPercents
            // 
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
            this.plan1.Width = 45;
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
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(764, 502);
            this.Controls.Add(this.TCinst);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AdminPanelForm_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TCinst.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVinst)).EndInit();
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridViewTextBoxColumn inst1;
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
    }
}