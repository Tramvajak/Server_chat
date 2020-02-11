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
                return "OnSetOnlineStatus";
            }
         }
        public static string CurrentUserFullName
        {
            get
            {
                return "OnCurrentUserFullName";
            }
        }
    }
}
