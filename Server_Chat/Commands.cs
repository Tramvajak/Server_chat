using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server_Chat
{
    class Commands
    {
        public static string SetOnlineStatus
        {
            get
            {
                return "OnSetClientOnlineStatus";
            }
         }
        public static string onListClientOnline // new
        {
            get
            {
                return "OnListClientOnline";
            }
        }
        public static string onListClientOffline // new
        {
            get
            {
                return "OnListClientOffline";
            }
        }
        public static string onCurrentUserFullName // new
        {
            get
            {
                return "OnCurrentUserFullName";
            }
         }
    }
}
