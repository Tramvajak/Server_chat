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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            //try
            //{
            Sqlite.TestBase();
            string line = Sqlite.Select_UserPassword("Test");
            string[] _line = line.Split(';');
            MessageBox.Show(_line[0], _line[1]);
            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine(3, ex.Message);

            //}
        }
    }
}
