using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Chat
{
    static class Debug
    {
        public static event StatusChangedEventHandler StatusChanged;
        private static StatusChangedEventArgs e;
        static readonly string _logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
        /// <summary>
        /// Записывает лог в файл
        /// </summary>
        /// <param name="line">Строка текста для вывода</param>
        public static void WriteLine(string line)
        {
            File.AppendAllText(_logPath,"["+DateTime.Now+"] " +line + Environment.NewLine);
            System.Diagnostics.Debug.WriteLine(line);
        }
        /// <summary>
        /// Записывает лог в файл
        /// </summary>
        /// <param name="line">Строка текста для вывода</param>
        /// <param name="key">Код лога. 1=info 2=Warring 3=Error 0=Debug</param>
        public static void WriteLine(int key,string line)
        {
            string msg = String.Format("[" + DateTime.Now + "] " + line + Environment.NewLine);
            if (key == 0) msg = String.Format("[" + DateTime.Now + "] [Debug] " + line + Environment.NewLine);
            if (key == 1) msg = String.Format("[" + DateTime.Now + "] [Info] " + line + Environment.NewLine);
            if (key == 2) msg = String.Format("[" + DateTime.Now + "] [Warring] " + line + Environment.NewLine);
            if (key == 3) msg = String.Format("[" + DateTime.Now + "] [Error] " + line + Environment.NewLine);
            File.AppendAllText(_logPath, msg);
            e = new StatusChangedEventArgs(msg); // что бы отправить 
            OnStatusChanged(e);            
            System.Diagnostics.Debug.WriteLine(msg);
        }
        /// <summary>
        ///  Записывает лог в файл
        /// </summary>
        /// <param name="line">Строка текста для вывода</param>
        /// <param name="args"> Праметры </param>
        public static void WriteLine(string line,params object[] args)
        {
            string msg = String.Format(line, args);
            File.AppendAllText(_logPath, "[" + DateTime.Now + "] " + msg + Environment.NewLine);
            System.Diagnostics.Debug.WriteLine(msg);
        }
        public static void OnStatusChanged(StatusChangedEventArgs e) //что бы отправить  
        {
            StatusChangedEventHandler statusHandler = StatusChanged;
            if(statusHandler !=null)
            {
                statusHandler(null, e);
            }

        }
    }
}
