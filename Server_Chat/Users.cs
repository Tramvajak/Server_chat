using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server_Chat
{
    class Users
    {
        public string id { get; set; }
        public string login { get; set; }
        public string full_name { get; set; }
        public string date_reg { get; set; }
        public string online { get; set; }
        public string last_ip { get; set; }
        public int adminlevel { get; set; }
        public TcpClient tcpClient { get; set; }
        //private string last_ip; //нужно реализовать


        public Users(string id, string login, string full_name, string date_reg, string online, string last_ip,int adminlevel)
        {
            this.id = id;
            this.login = login;
            this.full_name = full_name;    
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
