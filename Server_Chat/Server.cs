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
        private Thread thTimeOut;
        public Server()
        {

        }
        public static bool TryLogin(string name, string pass)
        {
            var foundUser = Sqlite.UsersList.Find(item => item.login == name);
            if (foundUser == null) return false;
            string[] msg = Sqlite.Select_UserPassword(foundUser.login).Split(';');
            if (msg[1] == pass)
            {
                Debug.WriteLine(0, "Login: " + foundUser.login + " Pass: Sucsseccful");
                return true;
            }
            return false;
        }
        public static void AddUser(TcpClient client, string name)
        {
            var foundUser = Sqlite.UsersList.Find(item => item.login == name);
            foundUser.tcpClient = client;
            StreamWriter swSender = new StreamWriter(foundUser.tcpClient.GetStream());
            swSender.WriteLine("Connection true");
            swSender.Flush();
            swSender = null;
        }
        public async void StartListening()
        {
            if (tcpListener == null)
            {
                tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), 7770);
                tcpListener.Start();
                ServerIsRun = true;
                Debug.WriteLine(1, "Server is run");
                thrListen = new Thread(KeepListening);
                thrListen.IsBackground = true;
                thrListen.Start();
                Debug.WriteLine(1, "Server start Listen port 7770");


                //thTimeOut = new Thread(OnTimeOutSend);
                //thTimeOut.Name = "TimeOutTimer";
                //thTimeOut.IsBackground = true;
                //thTimeOut.Start();
                await Task.Run(() => OnTimeOutSend());
            }
        }
        private void KeepListening()
        {
            try
            {
                while (ServerIsRun)
                {
                    tcpClient = tcpListener.AcceptTcpClient();

                    Connection conn = new Connection(tcpClient);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(3, ex.Message);
            }
        }
        private void OnTimeOutSend() //таймаут для проверки подключен ли юзер
        {
            Debug.WriteLine(0, "Start Time out");
            //Sqlite.UsersList.Count;
            //Timer timer = new Timer(_OnTimeOutSend, null, 5000, 1000);
            while (true)
            {
                _OnTimeOutSend();
                Thread.Sleep(1200);
            }
        }
        public static void OnClientListLoad(TcpClient client)
        {
            try
            {
                StreamWriter swSender = new StreamWriter(client.GetStream());
                foreach (var item in Sqlite.UsersList)
                {
                    swSender.WriteLine(item.full_name + ";OnListClientAdd");
                    swSender.Flush();
                }
                swSender = null;
            }
            catch(Exception ex)
            {

            }
        }
        private void _OnTimeOutSend()
        {
            if (Sqlite.UsersList.Count == 0) return;
            foreach (var item in Sqlite.UsersList)
            {
                if (item.tcpClient == null) return;
                try
                {
                    //StreamWriter swSender = new StreamWriter(item.tcpClient.GetStream());
                    //swSender.WriteLine("TestConnections");
                    //swSender.Flush();
                    //swSender = null;
                    if (item.tcpClient.Client.Poll(0, SelectMode.SelectRead))
                    {
                        if (item.tcpClient.Client.Receive(new byte[1], SocketFlags.Peek) == 0)
                        {
                            throw new IOException();
                        }
                    }
                }
                catch (Exception ex)
                {


                    item.tcpClient = null;
                    Debug.WriteLine(2, "Client disconected to timeout " + item.login);
                    Debug.WriteLine(0, "Client error timeout: " + ex.Message);
                }      
            }
        }
    }
    class Connection
    {
        private TcpClient tcpClient;
        private StreamReader srReciver;
        private StreamWriter swSender;
        private Thread thrSender;
        private string strResponse;
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
                //=====================Процедура авторизации========================
                if (mess[0] != "" && mess[1] != "" && mess[2] != "")// 0|1|2 name|pass|version
                {
                    if(mess[2] != "0.1")
                    {
                        swSender.WriteLine("0|This old version! Please check new version!");
                        swSender.Flush();
                        CloseConnecion();
                        return;
                    }
                    if (Server.htUsers.Contains(mess[0]) == true) // не используется
                    {
                        swSender.WriteLine("0|This username already exists.");
                        swSender.Flush();
                        CloseConnecion();
                        return;
                    }
                    else
                    {
                        if(Server.TryLogin(mess[0],mess[1]))
                        {
                            swSender.WriteLine("1");
                            swSender.Flush();
                            Server.AddUser(tcpClient, mess[0]);
                            Server.OnClientListLoad(tcpClient);
                        }
                        else
                        {
                            swSender.WriteLine("0|Проверте правельность введенных данных");
                            swSender.Flush();
                            CloseConnecion();
                        }
                    }
                    mess = null;
                    //========================Конец авторизации=======================
                }
                else
                {
                    CloseConnecion();
                    return;
                }
                //===========================Процедура обмена сообщениями=====================
                try
                {
                    while ((strResponse = srReciver.ReadLine()) != "")
                    {
                        Debug.WriteLine(0, "Response: " + strResponse);

                    }
                }
                catch(Exception ex)
                {
                    Debug.WriteLine(3, ex.Message);
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
