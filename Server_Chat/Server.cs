using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server_Chat
{
    class Server
    {
        public static Hashtable htUsers = new Hashtable(30);
        public static Hashtable htConnections = new Hashtable(30);

        private TcpListener tcpListener;
        private TcpClient tcpClient;
        private IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        private bool ServerIsRun = false;
        private Thread thrListen;
        public Server()
        {

        }
        public static bool TryLogin(string name, string pass)
        {
            return true;
        }
        public void StartListening()
        {
            if(tcpListener == null)
            {
                tcpListener = new TcpListener(7770);
                tcpListener.Start();
                ServerIsRun = true;
                Debug.WriteLine(1, "Server is run");
                thrListen = new Thread(KeepListening);
                thrListen.IsBackground = true;
                thrListen.Start();
                Debug.WriteLine(1, "Server start Listen port 7770");

            }
        }
        private void KeepListening()
        {
            try
            {
                while(ServerIsRun)
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(3, ex.Message);
            }
        }
    }
    class Connection
    {
        private TcpClient tcpClient;
        private StreamReader srReciver;
        private StreamWriter swSender;
        private Thread thrSender;
        public Connection(TcpClient _tcpClient)
        {
            tcpClient = _tcpClient;
            thrSender = new Thread(AcceptClient);
            thrSender.IsBackground = true;
            thrSender.Start();
        }
        private void AcceptClient()
        {
            try
            {
                srReciver = new StreamReader(tcpClient.GetStream());
                swSender = new StreamWriter(tcpClient.GetStream());
                string tcp_client_ip = Convert.ToString(((System.Net.IPEndPoint)tcpClient.Client.RemoteEndPoint).Address);
                Debug.WriteLine(1, "Connection client (ip:" + tcp_client_ip + ")");
                string connectMessage = srReciver.ReadLine();
                string[] mess = connectMessage.Split('|');
                if (mess[0] != "" && mess[1] != "" && mess[2] != "")
                {
                    if (Server.htUsers.Contains(mess[0]) == true)
                    {
                        swSender.WriteLine("0|This username already exists.");
                        swSender.Flush();
                        CloseConnecion();
                        return;
                    }
                    else
                    {
                        //if()
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(2, "void AcceptClient: " + ex.Message);
            }
        }
        private void CloseConnecion()
        {
            tcpClient.Close();
            srReciver.Close();
            swSender.Close();
        }
    }
}
