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
            this.BCreateUser = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BCreateUser
            // 
            this.BCreateUser.Location = new System.Drawing.Point(12, 12);
            this.BCreateUser.Name = "BCreateUser";
            this.BCreateUser.Size = new System.Drawing.Size(139, 23);
            this.BCreateUser.TabIndex = 0;
            this.BCreateUser.Text = "Создать пользователя";
            this.BCreateUser.UseVisualStyleBackColor = true;
            this.BCreateUser.Click += new System.EventHandler(this.BCreateUser_Click);
            // 
            // AdminPanelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(435, 220);
            this.Controls.Add(this.BCreateUser);
            this.MaximizeBox = false;
            this.Name = "AdminPanelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Панель администратора";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BCreateUser;
    }
}