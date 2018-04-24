namespace hahatonProjectAdmin
{
    partial class DeleteUserForm
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
            this.DGV_archive = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TB_query = new System.Windows.Forms.TextBox();
            this.BTSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_archive)).BeginInit();
            this.SuspendLayout();
            // 
            // DGV_archive
            // 
            this.DGV_archive.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DGV_archive.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_archive.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.DGV_archive.Location = new System.Drawing.Point(0, 20);
            this.DGV_archive.Name = "DGV_archive";
            this.DGV_archive.ReadOnly = true;
            this.DGV_archive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DGV_archive.Size = new System.Drawing.Size(592, 242);
            this.DGV_archive.TabIndex = 0;
            this.DGV_archive.DoubleClick += new System.EventHandler(this.DGV_archive_DoubleClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Логин";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 133;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "ИНН";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Компания";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 250;
            // 
            // TB_query
            // 
            this.TB_query.Location = new System.Drawing.Point(41, 0);
            this.TB_query.Name = "TB_query";
            this.TB_query.Size = new System.Drawing.Size(181, 20);
            this.TB_query.TabIndex = 1;
            // 
            // BTSearch
            // 
            this.BTSearch.Location = new System.Drawing.Point(228, 0);
            this.BTSearch.Name = "BTSearch";
            this.BTSearch.Size = new System.Drawing.Size(75, 20);
            this.BTSearch.TabIndex = 2;
            this.BTSearch.Text = "Поиск";
            this.BTSearch.UseVisualStyleBackColor = true;
            this.BTSearch.Click += new System.EventHandler(this.BTSearch_Click);
            // 
            // DeleteUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 262);
            this.Controls.Add(this.BTSearch);
            this.Controls.Add(this.TB_query);
            this.Controls.Add(this.DGV_archive);
            this.Name = "DeleteUserForm";
            this.Text = "Удаление пользователя";
            this.Load += new System.EventHandler(this.DeleteUserForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_archive)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DGV_archive;
        private System.Windows.Forms.TextBox TB_query;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.Button BTSearch;
    }
}