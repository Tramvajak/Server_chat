namespace Server_Chat
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_StartServer = new System.Windows.Forms.Button();
            this.rich_UsersOnline = new System.Windows.Forms.RichTextBox();
            this.rich_Logs = new System.Windows.Forms.RichTextBox();
            this.chckBox_DebugMode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btn_StartServer
            // 
            this.btn_StartServer.Location = new System.Drawing.Point(407, 253);
            this.btn_StartServer.Name = "btn_StartServer";
            this.btn_StartServer.Size = new System.Drawing.Size(75, 23);
            this.btn_StartServer.TabIndex = 0;
            this.btn_StartServer.Text = "StartServer";
            this.btn_StartServer.UseVisualStyleBackColor = true;
            this.btn_StartServer.Click += new System.EventHandler(this.btn_StartServer_Click);
            // 
            // rich_UsersOnline
            // 
            this.rich_UsersOnline.Location = new System.Drawing.Point(12, 22);
            this.rich_UsersOnline.Name = "rich_UsersOnline";
            this.rich_UsersOnline.Size = new System.Drawing.Size(186, 203);
            this.rich_UsersOnline.TabIndex = 1;
            this.rich_UsersOnline.Text = "";
            // 
            // rich_Logs
            // 
            this.rich_Logs.Location = new System.Drawing.Point(215, 22);
            this.rich_Logs.Name = "rich_Logs";
            this.rich_Logs.Size = new System.Drawing.Size(383, 203);
            this.rich_Logs.TabIndex = 2;
            this.rich_Logs.Text = "";
            // 
            // chckBox_DebugMode
            // 
            this.chckBox_DebugMode.AutoSize = true;
            this.chckBox_DebugMode.Enabled = false;
            this.chckBox_DebugMode.Location = new System.Drawing.Point(128, 253);
            this.chckBox_DebugMode.Name = "chckBox_DebugMode";
            this.chckBox_DebugMode.Size = new System.Drawing.Size(85, 17);
            this.chckBox_DebugMode.TabIndex = 3;
            this.chckBox_DebugMode.Text = "DebugMode";
            this.chckBox_DebugMode.UseVisualStyleBackColor = true;
            this.chckBox_DebugMode.CheckedChanged += new System.EventHandler(this.chckBox_DebugMode_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 352);
            this.Controls.Add(this.chckBox_DebugMode);
            this.Controls.Add(this.rich_Logs);
            this.Controls.Add(this.rich_UsersOnline);
            this.Controls.Add(this.btn_StartServer);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_StartServer;
        private System.Windows.Forms.RichTextBox rich_UsersOnline;
        public System.Windows.Forms.RichTextBox rich_Logs;
        private System.Windows.Forms.CheckBox chckBox_DebugMode;
    }
}

