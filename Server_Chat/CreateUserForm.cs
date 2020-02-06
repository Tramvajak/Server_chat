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
    public partial class CreateUserForm : Form
    {
        public CreateUserForm()
        {
            InitializeComponent();
            txt_Mode.Enabled = false;
        }

        private void ch_BoxMode_CheckedChanged(object sender, EventArgs e)
        {
            if (ch_BoxMode.Checked == true) txt_Mode.Enabled = true;
            else txt_Mode.Enabled = false;
        }

        private void btn_CreateUser_Click(object sender, EventArgs e)
        {
            if (txt_Login.Text.Equals("") && txt_Login.Text.Equals(""))
            {
                MessageBox.Show("Поля не могут быть пустыми");
                return;
            }
            Sqlite.Insert_CreateUser(txt_Login.Text, txt_Password.Text);
        }
    }
}
