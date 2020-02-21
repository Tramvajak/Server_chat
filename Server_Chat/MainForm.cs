using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Chat
{
    public partial class MainForm : Form
    {
        private Thread thrAutoKick;
        public MainForm()
        {
            InitializeComponent();
            chckBox_DebugMode.CheckState = CheckState.Checked;
            chckBox_DebugMode.Enabled = true;
            //Debug.WriteLine("test");
        }
        
        private void btn_StartServer_Click(object sender, EventArgs e)
        {
            //try
            //{
            
            //string line = Sqlite.Select_UserPassword("Test");
            //string[] _line = line.Split(';');
            //MessageBox.Show(_line[0], _line[1]);
            Debug.StatusChanged += new StatusChangedEventHandler(Log_StatusChanged); // объявить что бы принять сообщение
            Server server = new Server();
            server.StartListening();
            //Debug.WriteLine(1, "Test Info color");
            //Debug.WriteLine(2, "Test warring color");
            //Debug.WriteLine(3, "Test Error Color");
            //Debug.WriteLine(0, "Test Debug Color");
            //thrAutoKick = new Thread(AutoKick);
            //thrAutoKick.IsBackground = true;
            //thrAutoKick.Name = "Auto Kick Thread";
            //thrAutoKick.Start();
            //}
            //catch(Exception ex)
            //{
            //    Debug.WriteLine(3, ex.Message);

            //}
        }
        private void OnSetClientOnlineStatus(string name,string status)
        {
            if(status =="Online")
            {
                var foundUser = Sqlite.UsersList.Find(item => item.full_name == name);
                for (int i = 0; i < listB_UsersOnline.Items.Count; i++)
                {
                    if(listB_UsersOnline.Items[i].ToString() == foundUser.full_name)
                    {
                        foundUser.online = "1";
                        listB_UsersOnline.Items[i] += "[Online]";
                        Server.OnClientsStatusOnline(foundUser.full_name, foundUser.online);
                        return;
                    }
                }
            }
            else
            {
                var foundUser = Sqlite.UsersList.Find(item => item.full_name == name);
                for (int i = 0; i < listB_UsersOnline.Items.Count; i++)
                {
                    if(listB_UsersOnline.Items[i].ToString().Contains(foundUser.full_name))
                    //if (listB_UsersOnline.Items[i].ToString()+"[Online]" == foundUser.full_name+"[Online]")
                    {
                        foundUser.online = "0";
                        listB_UsersOnline.Items[i] = foundUser.full_name;
                        Server.OnClientsStatusOnline(foundUser.full_name, foundUser.online);
                        return;
                    }
                }
            }

        }
        
        private void Log_StatusChanged(object sender, StatusChangedEventArgs e)// объявить что бы принять сообщение
        {
            string msg = e.EventMessage;
            if (msg.IndexOf(";;") > 0)
            {
                string[] _msg = msg.Split(new char[] {';',';' }); // первая часть|пусто|вторая часть
                if(_msg[0] == Commands.SetOnlineStatus)
                {
                    string[] text = _msg[2].Split('|');
                    Invoke((MethodInvoker)delegate ()
                    {
                        OnSetClientOnlineStatus(text[0], text[1]);
                    });
                }
            }
            else
            {
                int startIndex = msg.IndexOf('[', 19);
                int endIndex = msg.IndexOf(']', startIndex);
                string key = msg.Substring(startIndex + 1, endIndex - startIndex - 1);
                Invoke((MethodInvoker)delegate ()
                {
                    if (key == "Debug" && Properties.Settings.Default.DebugMode != "Checked") return;
                    if (key == "Info") rich_Logs.AppendText(e.EventMessage);
                    if (key == "Debug") rich_Logs.AppendText(e.EventMessage, Color.Gray);
                    if (key == "Warring") rich_Logs.AppendText(e.EventMessage, Color.Orange);
                    if (key == "Error") rich_Logs.AppendText(e.EventMessage, Color.Red);
                });
            }
        }

        private void chckBox_DebugMode_CheckedChanged(object sender, EventArgs e)
        {
            string debugmode = chckBox_DebugMode.CheckState.ToString();
            Properties.Settings.Default.DebugMode = debugmode;
            Properties.Settings.Default.Save();
            if (Properties.Settings.Default.DebugMode == "Checked")
             Debug.WriteLine(0, "DebugMode activated");
            else
                Debug.WriteLine(0, "DebugMode deactivated");
           
        }

        private void listB_UsersOnline_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listB_UsersOnline.SelectedIndex == -1) return;
            Debug.WriteLine(0, "List Box Users selected index " + listB_UsersOnline.SelectedIndex.ToString());
            Debug.WriteLine(0, "Open Selected User form " + listB_UsersOnline.Items[listB_UsersOnline.SelectedIndex]);
             var user = Sqlite.UsersList.ElementAt(listB_UsersOnline.SelectedIndex);
            SelectedUserForm suf = new SelectedUserForm(user.login,user.full_name,user.date_reg,user.online,user.last_ip,user.adminlevel.ToString());
            if(suf.ShowDialog(this) == DialogResult.OK)
            {

            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Sqlite.TestBase();
            foreach (var item in Sqlite.UsersList)
            {
                listB_UsersOnline.Items.Add(item.full_name);
            }
        }

        private void Timer_Time_Tick(object sender, EventArgs e)
        {
            l_Time.Text = DateTime.Now.ToString();
            
        }

        private void rich_Logs_TextChanged(object sender, EventArgs e)
        {
            rich_Logs.SelectionStart = rich_Logs.Text.Length;
            rich_Logs.ScrollToCaret();
        }

        private void createUsersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Может не до конца рабатать");

        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
