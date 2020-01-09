using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SQLite;

namespace Server_Chat
{
    class Sqlite
    {
        const string databaseName = @"Server.sqlite";
        /// <summary>
        /// sqlite запрос на создание значений в базе
        /// </summary>
        public static void Insert_CreateUser(string _name, string _password)
        {
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName))
                {

                }
            }
            catch(SQLiteException ex)
            {
                Debug.WriteLine(3, "void Insert_CreateUser: " + ex.Message);
            }
        }
        public static void TestBase()
        {
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName))
                {
                    SQLiteCommand command = new SQLiteCommand("SELECT * FROM users", connect);
                    SQLiteDataReader reader = command.ExecuteReader();
                    foreach(DbDataRecord record in reader)
                    {
                        Debug.WriteLine(0, "Table: " + record["name"]);

                    }
                    connect.Close();

                }
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(2, "Test DataBase: " + ex.Message);
            }
        }
    }
}
