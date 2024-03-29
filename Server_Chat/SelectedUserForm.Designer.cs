﻿namespace Server_Chat
{
    partial class SelectedUserForm
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
            this.btn_Ok = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.l_InfoLogin = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.l_InfoPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.l_AdminLevel = new System.Windows.Forms.Label();
            this.l_InfoFullName = new System.Windows.Forms.Label();
            this.l_InfoDateReg = new System.Windows.Forms.Label();
            this.l_InfoOnline = new System.Windows.Forms.Label();
            this.l_InfoLastIP = new System.Windows.Forms.Label();
            this.l_InfoAdminLevel = new System.Windows.Forms.Label();
            this.btn_Edit = new System.Windows.Forms.Button();
            this.tEdit_Login = new System.Windows.Forms.TextBox();
            this.tEdit_Password = new System.Windows.Forms.TextBox();
            this.tEdit_FullName = new System.Windows.Forms.TextBox();
            this.tEdit_DateReg = new System.Windows.Forms.TextBox();
            this.tEdit_Online = new System.Windows.Forms.TextBox();
            this.tEdit_LastIP = new System.Windows.Forms.TextBox();
            this.tEdit_adminlevel = new System.Windows.Forms.TextBox();
            this.btn_Kick = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_Ok.Location = new System.Drawing.Point(96, 292);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(25, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Login: ";
            // 
            // l_InfoLogin
            // 
            this.l_InfoLogin.AutoSize = true;
            this.l_InfoLogin.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoLogin.Location = new System.Drawing.Point(120, 35);
            this.l_InfoLogin.Name = "l_InfoLogin";
            this.l_InfoLogin.Size = new System.Drawing.Size(35, 18);
            this.l_InfoLogin.TabIndex = 2;
            this.l_InfoLogin.Text = "Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(25, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password: ";
            // 
            // l_InfoPassword
            // 
            this.l_InfoPassword.AutoSize = true;
            this.l_InfoPassword.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoPassword.Location = new System.Drawing.Point(120, 62);
            this.l_InfoPassword.Name = "l_InfoPassword";
            this.l_InfoPassword.Size = new System.Drawing.Size(35, 18);
            this.l_InfoPassword.TabIndex = 4;
            this.l_InfoPassword.Text = "Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(25, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "FullName: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(25, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Date Reg: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(25, 148);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 18);
            this.label5.TabIndex = 7;
            this.label5.Text = "Online: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(25, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 18);
            this.label6.TabIndex = 8;
            this.label6.Text = "Last IP: ";
            // 
            // l_AdminLevel
            // 
            this.l_AdminLevel.AutoSize = true;
            this.l_AdminLevel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_AdminLevel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.l_AdminLevel.Location = new System.Drawing.Point(25, 207);
            this.l_AdminLevel.Name = "l_AdminLevel";
            this.l_AdminLevel.Size = new System.Drawing.Size(90, 18);
            this.l_AdminLevel.TabIndex = 9;
            this.l_AdminLevel.Text = "AdminLevel";
            // 
            // l_InfoFullName
            // 
            this.l_InfoFullName.AutoSize = true;
            this.l_InfoFullName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoFullName.Location = new System.Drawing.Point(120, 90);
            this.l_InfoFullName.Name = "l_InfoFullName";
            this.l_InfoFullName.Size = new System.Drawing.Size(35, 18);
            this.l_InfoFullName.TabIndex = 10;
            this.l_InfoFullName.Text = "Text";
            // 
            // l_InfoDateReg
            // 
            this.l_InfoDateReg.AutoSize = true;
            this.l_InfoDateReg.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoDateReg.Location = new System.Drawing.Point(120, 118);
            this.l_InfoDateReg.Name = "l_InfoDateReg";
            this.l_InfoDateReg.Size = new System.Drawing.Size(35, 18);
            this.l_InfoDateReg.TabIndex = 11;
            this.l_InfoDateReg.Text = "Text";
            // 
            // l_InfoOnline
            // 
            this.l_InfoOnline.AutoSize = true;
            this.l_InfoOnline.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoOnline.Location = new System.Drawing.Point(120, 148);
            this.l_InfoOnline.Name = "l_InfoOnline";
            this.l_InfoOnline.Size = new System.Drawing.Size(35, 18);
            this.l_InfoOnline.TabIndex = 12;
            this.l_InfoOnline.Text = "Text";
            // 
            // l_InfoLastIP
            // 
            this.l_InfoLastIP.AutoSize = true;
            this.l_InfoLastIP.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoLastIP.Location = new System.Drawing.Point(120, 177);
            this.l_InfoLastIP.Name = "l_InfoLastIP";
            this.l_InfoLastIP.Size = new System.Drawing.Size(35, 18);
            this.l_InfoLastIP.TabIndex = 13;
            this.l_InfoLastIP.Text = "Text";
            // 
            // l_InfoAdminLevel
            // 
            this.l_InfoAdminLevel.AutoSize = true;
            this.l_InfoAdminLevel.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_InfoAdminLevel.Location = new System.Drawing.Point(121, 207);
            this.l_InfoAdminLevel.Name = "l_InfoAdminLevel";
            this.l_InfoAdminLevel.Size = new System.Drawing.Size(35, 18);
            this.l_InfoAdminLevel.TabIndex = 14;
            this.l_InfoAdminLevel.Text = "Text";
            // 
            // btn_Edit
            // 
            this.btn_Edit.Location = new System.Drawing.Point(96, 249);
            this.btn_Edit.Name = "btn_Edit";
            this.btn_Edit.Size = new System.Drawing.Size(75, 23);
            this.btn_Edit.TabIndex = 15;
            this.btn_Edit.Text = "Edit";
            this.btn_Edit.UseVisualStyleBackColor = true;
            this.btn_Edit.Click += new System.EventHandler(this.btn_Edit_Click);
            // 
            // tEdit_Login
            // 
            this.tEdit_Login.Location = new System.Drawing.Point(234, 36);
            this.tEdit_Login.Name = "tEdit_Login";
            this.tEdit_Login.Size = new System.Drawing.Size(100, 20);
            this.tEdit_Login.TabIndex = 16;
            // 
            // tEdit_Password
            // 
            this.tEdit_Password.Location = new System.Drawing.Point(234, 63);
            this.tEdit_Password.Name = "tEdit_Password";
            this.tEdit_Password.Size = new System.Drawing.Size(100, 20);
            this.tEdit_Password.TabIndex = 17;
            // 
            // tEdit_FullName
            // 
            this.tEdit_FullName.Location = new System.Drawing.Point(234, 91);
            this.tEdit_FullName.Name = "tEdit_FullName";
            this.tEdit_FullName.Size = new System.Drawing.Size(100, 20);
            this.tEdit_FullName.TabIndex = 18;
            // 
            // tEdit_DateReg
            // 
            this.tEdit_DateReg.Location = new System.Drawing.Point(234, 119);
            this.tEdit_DateReg.Name = "tEdit_DateReg";
            this.tEdit_DateReg.Size = new System.Drawing.Size(100, 20);
            this.tEdit_DateReg.TabIndex = 19;
            // 
            // tEdit_Online
            // 
            this.tEdit_Online.Location = new System.Drawing.Point(234, 149);
            this.tEdit_Online.Name = "tEdit_Online";
            this.tEdit_Online.Size = new System.Drawing.Size(100, 20);
            this.tEdit_Online.TabIndex = 20;
            // 
            // tEdit_LastIP
            // 
            this.tEdit_LastIP.Location = new System.Drawing.Point(234, 178);
            this.tEdit_LastIP.Name = "tEdit_LastIP";
            this.tEdit_LastIP.Size = new System.Drawing.Size(100, 20);
            this.tEdit_LastIP.TabIndex = 21;
            // 
            // tEdit_adminlevel
            // 
            this.tEdit_adminlevel.Location = new System.Drawing.Point(234, 207);
            this.tEdit_adminlevel.Name = "tEdit_adminlevel";
            this.tEdit_adminlevel.Size = new System.Drawing.Size(100, 20);
            this.tEdit_adminlevel.TabIndex = 22;
            // 
            // btn_Kick
            // 
            this.btn_Kick.Enabled = false;
            this.btn_Kick.Location = new System.Drawing.Point(204, 249);
            this.btn_Kick.Name = "btn_Kick";
            this.btn_Kick.Size = new System.Drawing.Size(75, 23);
            this.btn_Kick.TabIndex = 23;
            this.btn_Kick.Text = "Kick";
            this.btn_Kick.UseVisualStyleBackColor = true;
            // 
            // SelectedUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 337);
            this.Controls.Add(this.btn_Kick);
            this.Controls.Add(this.tEdit_adminlevel);
            this.Controls.Add(this.tEdit_LastIP);
            this.Controls.Add(this.tEdit_Online);
            this.Controls.Add(this.tEdit_DateReg);
            this.Controls.Add(this.tEdit_FullName);
            this.Controls.Add(this.tEdit_Password);
            this.Controls.Add(this.tEdit_Login);
            this.Controls.Add(this.btn_Edit);
            this.Controls.Add(this.l_InfoAdminLevel);
            this.Controls.Add(this.l_InfoLastIP);
            this.Controls.Add(this.l_InfoOnline);
            this.Controls.Add(this.l_InfoDateReg);
            this.Controls.Add(this.l_InfoFullName);
            this.Controls.Add(this.l_AdminLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.l_InfoPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_InfoLogin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Ok);
            this.Name = "SelectedUserForm";
            this.Text = "SelectedUserForm";
            this.Load += new System.EventHandler(this.SelectedUserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label l_InfoLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label l_InfoPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label l_AdminLevel;
        private System.Windows.Forms.Label l_InfoFullName;
        private System.Windows.Forms.Label l_InfoDateReg;
        private System.Windows.Forms.Label l_InfoOnline;
        private System.Windows.Forms.Label l_InfoLastIP;
        private System.Windows.Forms.Label l_InfoAdminLevel;
        private System.Windows.Forms.Button btn_Edit;
        private System.Windows.Forms.TextBox tEdit_Login;
        private System.Windows.Forms.TextBox tEdit_Password;
        private System.Windows.Forms.TextBox tEdit_FullName;
        private System.Windows.Forms.TextBox tEdit_DateReg;
        private System.Windows.Forms.TextBox tEdit_Online;
        private System.Windows.Forms.TextBox tEdit_LastIP;
        private System.Windows.Forms.TextBox tEdit_adminlevel;
        private System.Windows.Forms.Button btn_Kick;
    }
}