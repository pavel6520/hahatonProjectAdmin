namespace hahatonProjectAdmin
{
    partial class CreateUserForm
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
            this.Llogin = new System.Windows.Forms.Label();
            this.Lpass = new System.Windows.Forms.Label();
            this.TBlogin = new System.Windows.Forms.TextBox();
            this.TBpass = new System.Windows.Forms.TextBox();
            this.Bgenerate = new System.Windows.Forms.Button();
            this.LerrLoginExist = new System.Windows.Forms.Label();
            this.LerrLoginIncorrect = new System.Windows.Forms.Label();
            this.TableINN = new System.Windows.Forms.DataGridView();
            this.INN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.COmpName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddTableLine = new System.Windows.Forms.Button();
            this.DeleteTableLine = new System.Windows.Forms.Button();
            this.BSave = new System.Windows.Forms.Button();
            this.LErrTable = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TableINN)).BeginInit();
            this.SuspendLayout();
            // 
            // Llogin
            // 
            this.Llogin.AutoSize = true;
            this.Llogin.Location = new System.Drawing.Point(12, 9);
            this.Llogin.Name = "Llogin";
            this.Llogin.Size = new System.Drawing.Size(41, 13);
            this.Llogin.TabIndex = 0;
            this.Llogin.Text = "Логин:";
            // 
            // Lpass
            // 
            this.Lpass.AutoSize = true;
            this.Lpass.Location = new System.Drawing.Point(12, 35);
            this.Lpass.Name = "Lpass";
            this.Lpass.Size = new System.Drawing.Size(48, 13);
            this.Lpass.TabIndex = 1;
            this.Lpass.Text = "Пароль:";
            // 
            // TBlogin
            // 
            this.TBlogin.Location = new System.Drawing.Point(121, 6);
            this.TBlogin.Name = "TBlogin";
            this.TBlogin.Size = new System.Drawing.Size(133, 20);
            this.TBlogin.TabIndex = 2;
            // 
            // TBpass
            // 
            this.TBpass.Location = new System.Drawing.Point(121, 32);
            this.TBpass.Name = "TBpass";
            this.TBpass.ReadOnly = true;
            this.TBpass.Size = new System.Drawing.Size(133, 20);
            this.TBpass.TabIndex = 3;
            // 
            // Bgenerate
            // 
            this.Bgenerate.Location = new System.Drawing.Point(260, 30);
            this.Bgenerate.Name = "Bgenerate";
            this.Bgenerate.Size = new System.Drawing.Size(90, 23);
            this.Bgenerate.TabIndex = 4;
            this.Bgenerate.Text = "Генерировать";
            this.Bgenerate.UseVisualStyleBackColor = true;
            this.Bgenerate.Click += new System.EventHandler(this.Bgenerate_Click);
            // 
            // LerrLoginExist
            // 
            this.LerrLoginExist.AutoSize = true;
            this.LerrLoginExist.ForeColor = System.Drawing.Color.Red;
            this.LerrLoginExist.Location = new System.Drawing.Point(260, 9);
            this.LerrLoginExist.Name = "LerrLoginExist";
            this.LerrLoginExist.Size = new System.Drawing.Size(154, 13);
            this.LerrLoginExist.TabIndex = 5;
            this.LerrLoginExist.Text = "Такой логин уже существует";
            this.LerrLoginExist.Visible = false;
            // 
            // LerrLoginIncorrect
            // 
            this.LerrLoginIncorrect.AutoSize = true;
            this.LerrLoginIncorrect.ForeColor = System.Drawing.Color.Red;
            this.LerrLoginIncorrect.Location = new System.Drawing.Point(260, 9);
            this.LerrLoginIncorrect.Name = "LerrLoginIncorrect";
            this.LerrLoginIncorrect.Size = new System.Drawing.Size(114, 13);
            this.LerrLoginIncorrect.TabIndex = 6;
            this.LerrLoginIncorrect.Text = "Логин некорректный";
            this.LerrLoginIncorrect.Visible = false;
            // 
            // TableINN
            // 
            this.TableINN.AllowUserToAddRows = false;
            this.TableINN.AllowUserToDeleteRows = false;
            this.TableINN.AllowUserToResizeColumns = false;
            this.TableINN.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.TableINN.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.TableINN.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TableINN.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.INN,
            this.COmpName});
            this.TableINN.Location = new System.Drawing.Point(12, 59);
            this.TableINN.Name = "TableINN";
            this.TableINN.Size = new System.Drawing.Size(443, 163);
            this.TableINN.TabIndex = 7;
            // 
            // INN
            // 
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.INN.DefaultCellStyle = dataGridViewCellStyle2;
            this.INN.Frozen = true;
            this.INN.HeaderText = "ИНН";
            this.INN.Name = "INN";
            this.INN.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.INN.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.INN.Width = 150;
            // 
            // COmpName
            // 
            this.COmpName.Frozen = true;
            this.COmpName.HeaderText = "Имя компании";
            this.COmpName.Name = "COmpName";
            this.COmpName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.COmpName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.COmpName.Width = 250;
            // 
            // AddTableLine
            // 
            this.AddTableLine.Location = new System.Drawing.Point(12, 228);
            this.AddTableLine.Name = "AddTableLine";
            this.AddTableLine.Size = new System.Drawing.Size(75, 23);
            this.AddTableLine.TabIndex = 8;
            this.AddTableLine.Text = "Добавить";
            this.AddTableLine.UseVisualStyleBackColor = true;
            this.AddTableLine.Click += new System.EventHandler(this.AddTableLine_Click);
            // 
            // DeleteTableLine
            // 
            this.DeleteTableLine.Location = new System.Drawing.Point(93, 228);
            this.DeleteTableLine.Name = "DeleteTableLine";
            this.DeleteTableLine.Size = new System.Drawing.Size(75, 23);
            this.DeleteTableLine.TabIndex = 9;
            this.DeleteTableLine.Text = "Удалить";
            this.DeleteTableLine.UseVisualStyleBackColor = true;
            this.DeleteTableLine.Click += new System.EventHandler(this.DeleteTableLine_Click);
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(380, 228);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(75, 23);
            this.BSave.TabIndex = 10;
            this.BSave.Text = "Сохранить";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // LErrTable
            // 
            this.LErrTable.AutoSize = true;
            this.LErrTable.ForeColor = System.Drawing.Color.Red;
            this.LErrTable.Location = new System.Drawing.Point(246, 233);
            this.LErrTable.Name = "LErrTable";
            this.LErrTable.Size = new System.Drawing.Size(128, 13);
            this.LErrTable.TabIndex = 11;
            this.LErrTable.Text = "Не все поля заполнены";
            this.LErrTable.Visible = false;
            // 
            // CreateUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(467, 259);
            this.Controls.Add(this.LErrTable);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.DeleteTableLine);
            this.Controls.Add(this.AddTableLine);
            this.Controls.Add(this.TableINN);
            this.Controls.Add(this.LerrLoginIncorrect);
            this.Controls.Add(this.LerrLoginExist);
            this.Controls.Add(this.Bgenerate);
            this.Controls.Add(this.TBpass);
            this.Controls.Add(this.TBlogin);
            this.Controls.Add(this.Lpass);
            this.Controls.Add(this.Llogin);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "CreateUserForm";
            this.Text = "CreateUser";
            this.Load += new System.EventHandler(this.CreateUserForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CreateUserForm_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.TableINN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Llogin;
        private System.Windows.Forms.Label Lpass;
        private System.Windows.Forms.TextBox TBlogin;
        private System.Windows.Forms.TextBox TBpass;
        private System.Windows.Forms.Button Bgenerate;
        private System.Windows.Forms.Label LerrLoginExist;
        private System.Windows.Forms.Label LerrLoginIncorrect;
        private System.Windows.Forms.DataGridView TableINN;
        private System.Windows.Forms.Button AddTableLine;
        private System.Windows.Forms.Button DeleteTableLine;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.Label LErrTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn INN;
        private System.Windows.Forms.DataGridViewTextBoxColumn COmpName;
    }
}