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
        string name;
        string password;
        string fullname;
        string date_reg;
        string online;
        string lastip;
        string adminlevel;
        public SelectedUserForm(string name,string fullname,string date_reg,string online,string lastip,string adminlevel, string password = null)
        {
            InitializeComponent();
            this.name = name;
            this.password = password;
            this.fullname = fullname;
            this.date_reg = date_reg;
            this.online = online;
            this.lastip = lastip;
            this.adminlevel = adminlevel;
            l_AdminLevel.Visible = false;
            l_InfoAdminLevel.Visible = false;
        }

        private void SelectedUserForm_Load(object sender, EventArgs e)
        {
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
    }
}
