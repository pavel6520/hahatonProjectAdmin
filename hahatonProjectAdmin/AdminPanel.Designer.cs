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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.TSMIdb = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIdbShow = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIuser = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMIuserCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.MC1 = new System.Windows.Forms.MonthCalendar();
            this.Bselect_date1 = new System.Windows.Forms.Button();
            this.CBinstSelect1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.CBinstSelect2 = new System.Windows.Forms.ComboBox();
            this.DGVinst = new System.Windows.Forms.DataGridView();
            this.compName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vsm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pschr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvmr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pvPercents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.plan1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.CBinstSelect3 = new System.Windows.Forms.ComboBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bselect_date2 = new System.Windows.Forms.Button();
            this.MC2 = new System.Windows.Forms.MonthCalendar();
            this.Dia1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.inst1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NONW = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Money = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVinst)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dia1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMIdb,
            this.TSMIuser});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(910, 24);
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
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage4);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl.Location = new System.Drawing.Point(0, 24);
            this.TabControl.Multiline = true;
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(910, 469);
            this.TabControl.TabIndex = 2;
            this.TabControl.SelectedIndexChanged += new System.EventHandler(this.TabControl_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.MC1);
            this.tabPage1.Controls.Add(this.Bselect_date1);
            this.tabPage1.Controls.Add(this.CBinstSelect1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(794, 443);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Компании";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // MC1
            // 
            this.MC1.Location = new System.Drawing.Point(399, 21);
            this.MC1.Name = "MC1";
            this.MC1.TabIndex = 4;
            this.MC1.Visible = false;
            this.MC1.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MC1_DateSelected_1);
            // 
            // Bselect_date1
            // 
            this.Bselect_date1.Location = new System.Drawing.Point(458, -1);
            this.Bselect_date1.Name = "Bselect_date1";
            this.Bselect_date1.Size = new System.Drawing.Size(105, 22);
            this.Bselect_date1.TabIndex = 3;
            this.Bselect_date1.Text = "Выбрать период";
            this.Bselect_date1.UseVisualStyleBackColor = true;
            this.Bselect_date1.Click += new System.EventHandler(this.Bselect_date1_Click);
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
            this.CBinstSelect1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.inst1,
            this.NONW,
            this.SN,
            this.Money});
            this.dataGridView1.Location = new System.Drawing.Point(0, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(563, 422);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.CBinstSelect2);
            this.tabPage2.Controls.Add(this.DGVinst);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(794, 443);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Институты поддержки";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // CBinstSelect2
            // 
            this.CBinstSelect2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBinstSelect2.FormattingEnabled = true;
            this.CBinstSelect2.Items.AddRange(new object[] {
            "Фонд Микрофинансирования",
            "Гарантийный фонд",
            "Центр кластерного развития",
            "Центр поддержки предпринимательства",
            "Центр экспорта"});
            this.CBinstSelect2.Location = new System.Drawing.Point(0, 0);
            this.CBinstSelect2.Name = "CBinstSelect2";
            this.CBinstSelect2.Size = new System.Drawing.Size(240, 21);
            this.CBinstSelect2.TabIndex = 1;
            this.CBinstSelect2.SelectedIndexChanged += new System.EventHandler(this.CBinstSelect1_SelectedIndexChanged);
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
            this.DGVinst.Size = new System.Drawing.Size(794, 422);
            this.DGVinst.TabIndex = 0;
            // 
            // compName
            // 
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.compName.DefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Format = "N2";
            dataGridViewCellStyle2.NullValue = null;
            this.pschr.DefaultCellStyle = dataGridViewCellStyle2;
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
            dataGridViewCellStyle3.Format = "N2";
            dataGridViewCellStyle3.NullValue = null;
            this.pvPercents.DefaultCellStyle = dataGridViewCellStyle3;
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Dia1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(902, 443);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "Диаграмма";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.MC2);
            this.tabPage4.Controls.Add(this.Bselect_date2);
            this.tabPage4.Controls.Add(this.CBinstSelect3);
            this.tabPage4.Controls.Add(this.dataGridView2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(794, 443);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Архив";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // CBinstSelect3
            // 
            this.CBinstSelect3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBinstSelect3.FormattingEnabled = true;
            this.CBinstSelect3.Items.AddRange(new object[] {
            "Фонд Микрофинансирования",
            "Гарантийный фонд",
            "Центр кластерного развития",
            "Центр поддержки предпринимательства",
            "Центр экспорта"});
            this.CBinstSelect3.Location = new System.Drawing.Point(0, 0);
            this.CBinstSelect3.Name = "CBinstSelect3";
            this.CBinstSelect3.Size = new System.Drawing.Size(240, 21);
            this.CBinstSelect3.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView2.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dataGridView2.Location = new System.Drawing.Point(0, 21);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(794, 422);
            this.dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn1.HeaderText = "Компания";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "ИНН";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Численность сотрудников, чел";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 120;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Созданные рабочие места, шт";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Выручка, млн";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 105;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Дата";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Bselect_date2
            // 
            this.Bselect_date2.Location = new System.Drawing.Point(690, -1);
            this.Bselect_date2.Name = "Bselect_date2";
            this.Bselect_date2.Size = new System.Drawing.Size(105, 22);
            this.Bselect_date2.TabIndex = 4;
            this.Bselect_date2.Text = "Выбрать период";
            this.Bselect_date2.UseVisualStyleBackColor = true;
            this.Bselect_date2.Click += new System.EventHandler(this.Bselect_date2_Click);
            // 
            // MC2
            // 
            this.MC2.Location = new System.Drawing.Point(631, 21);
            this.MC2.Name = "MC2";
            this.MC2.TabIndex = 5;
            this.MC2.Visible = false;
            this.MC2.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.MC2_DateSelected);
            // 
            // Dia1
            // 
            this.Dia1.BackSecondaryColor = System.Drawing.Color.White;
            this.Dia1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea1.BackColor = System.Drawing.Color.Wheat;
            chartArea1.BorderWidth = 3;
            chartArea1.Name = "ChartArea1";
            this.Dia1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Dia1.Legends.Add(legend1);
            this.Dia1.Location = new System.Drawing.Point(0, 3);
            this.Dia1.Name = "Dia1";
            series1.ChartArea = "ChartArea1";
            series1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            series1.Legend = "Legend1";
            series1.MarkerStep = 4;
            series1.Name = "Фонд Микрофинансирования";
            series1.YValuesPerPoint = 4;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Гарантийный фонд";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Центр кластерного развития";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Центр поддержки предпринимательства";
            series5.ChartArea = "ChartArea1";
            series5.Legend = "Legend1";
            series5.Name = "Центр экспорта";
            this.Dia1.Series.Add(series1);
            this.Dia1.Series.Add(series2);
            this.Dia1.Series.Add(series3);
            this.Dia1.Series.Add(series4);
            this.Dia1.Series.Add(series5);
            this.Dia1.Size = new System.Drawing.Size(899, 440);
            this.Dia1.TabIndex = 0;
            this.Dia1.Text = "chart1";
            title1.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            title1.Name = "Title1";
            title1.Text = "Созданные рабочие места";
            this.Dia1.Titles.Add(title1);
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
            this.Money.HeaderText = "Прирост выручки";
            this.Money.Name = "Money";
            this.Money.ReadOnly = true;
            this.Money.Width = 120;
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(910, 493);
            this.Controls.Add(this.TabControl);
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
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGVinst)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Dia1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem TSMIuser;
        private System.Windows.Forms.ToolStripMenuItem TSMIuserCreate;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView DGVinst;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox CBinstSelect2;
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
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox CBinstSelect1;
        private System.Windows.Forms.Button Bselect_date1;
        private System.Windows.Forms.MonthCalendar MC1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.ComboBox CBinstSelect3;
        private System.Windows.Forms.Button Bselect_date2;
        private System.Windows.Forms.MonthCalendar MC2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Dia1;
        private System.Windows.Forms.DataGridViewTextBoxColumn inst1;
        private System.Windows.Forms.DataGridViewTextBoxColumn NONW;
        private System.Windows.Forms.DataGridViewTextBoxColumn SN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Money;
    }
}