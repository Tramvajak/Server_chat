using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Chat
{
    public partial class SelectedUserForm : Form
    {
        string id;
        string name;
        string password;
        string fullname;
        string date_reg;
        string online;
        string lastip;
        string adminlevel;

        bool editmode;
        public SelectedUserForm(string id,string name,string fullname,string date_reg,string online,string lastip,string adminlevel, string password = null)
        {
            InitializeComponent();
            this.id = id;
            this.name = name;
            this.password = password;
            this.fullname = fullname;
            this.date_reg = date_reg;
            this.online = online;
            this.lastip = lastip;
            this.adminlevel = adminlevel;
            l_AdminLevel.Visible = false;
            l_InfoAdminLevel.Visible = false;

            foreach(Control control in Controls)
            {
                if(control.GetType() == typeof(TextBox))
                {
                    control.Visible = false;
                }
            }
            editmode = false;
        }

        private void SelectedUserForm_Load(object sender, EventArgs e)
        {
            this.Text = "ID: " + id;
            l_InfoLogin.Text = name;
            l_InfoPassword.Text = password;
            l_InfoFullName.Text = fullname;
            l_InfoDateReg.Text = date_reg;
            l_InfoOnline.Text = online;
            l_InfoLastIP.Text = lastip;
            if (adminlevel.Equals("0")) return;
            else
            {
                l_AdminLevel.Visible = true;
                l_InfoAdminLevel.Visible = true;
                l_InfoAdminLevel.Text = adminlevel;
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (editmode)
            {
                Sqlite.Update_Parametrs(id,tEdit_Login.Text, tEdit_Password.Text, tEdit_FullName.Text, tEdit_DateReg.Text, tEdit_Online.Text, tEdit_LastIP.Text);
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            editmode = true;
            btn_Ok.Text = "OK/Save";
            foreach (Control control in Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    if (control == tEdit_adminlevel) continue;
                    control.Visible = true;
                }
            }
        }
    }
}
