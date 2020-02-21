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
                    if (mess[2] != "0.1")
                    {
                        swSender.WriteLine("0|This old version! Please check new version!");
                        swSender.Flush();
                        CloseConnecion();
                        return;
                    }
                    if (Server.CheckConnectedUser(mess[0])) // 
                    {
                        swSender.WriteLine("0|This username already exists.");
                        swSender.Flush();
                        CloseConnecion();
                        return;
                    }
                    else
                    {
                        if (Server.TryLogin(mess[0], mess[1]))
                        {
                            swSender.WriteLine("1");
                            swSender.Flush();
                            Server.AddUser(tcpClient, mess[0]);
                            Server.OnClientListLoad(tcpClient);
                            Server.OnClientsStatusOnline();
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
                        Debug.WriteLine(0, "Response: " + strResponse); // 1UserFullName;2UserFullName|Message
                        int count = strResponse.IndexOf("|");
                        if (count > 0)
                        {
                            string[] _mess = strResponse.Split('|');
                            string[] username = _mess[0].Split(';');
                            Server.OnSendMessageToClient(username[0], username[1], _mess[1]);
                        }

                    }
                }
                //=================================Конец========================================
                catch (Exception ex)
                {
                    Debug.WriteLine(3, ex.Message);
                }
            }
            catch (Exception ex)
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
