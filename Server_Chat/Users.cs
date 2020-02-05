using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Chat
{
    class Users
    {
        private string name;
        private bool online;
        private string last_entry;
        private string last_send_message;
        private int adminlevel;
        private string last_ip; //нужно реализовать


        public Users(string name, string last_entry, string last_send_message, bool online = false, int adminlevel = 0)
        {
            this.name = name;
            this.online = online;
            this.last_entry = last_entry;
            this.last_send_message = last_send_message;
            this.adminlevel = adminlevel;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
