using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Chat
{
    class Users
    {
       
        private string login;
        private bool full_name;
        private string date_reg;
        private string online;
        private int last_ip;
        private int adminlevel
        //private string last_ip; //нужно реализовать


        public Users(string login, string full_name, string date_reg, string online, int last_ip,int adminlevel)
        {
            this.login = login;         
            this.date_reg = date_reg;
            this.online = online;
            this.last_ip = last_ip;
            this.adminlevel = adminlevel;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
