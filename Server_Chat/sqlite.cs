using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace Server_Chat
{
    class Sqlite
    {
        public static List<Users> UsersList = new List<Users>();
        const string databaseName = @"Server.sqlite3";
        /// <summary>
        /// sqlite запрос на создание значений в базе
        /// </summary>
        public static void Insert_CreateUser(string _name, string _password)
        {
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;"))
                {
                    connect.Open();
                    SQLiteCommand command = new SQLiteCommand("INSERT INTO Users ('login','password','date-reg') VALUES ('" + _name + "','" + _password + "','" + DateTime.Now + "')", connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(3, "void Insert_CreateUser: " + ex.Message);
            }
        }
        /// <summary>
        /// Получения логина и пароля из бд
        /// </summary>
        /// <param name="_name">Логин</param>
        /// <returns>Возвращяет  line (Login;Password)</returns>
        public static string Select_UserPassword(string _name)
        {
           
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;"))
                {
                    connect.Open();
                    SQLiteCommand command = new SQLiteCommand("SELECT login,password FROM Users WHERE login='" + _name + "'", connect);
                    SQLiteDataReader reader = command.ExecuteReader();
                    
                    string line = String.Empty;
                    
                    foreach (DbDataRecord record in reader)
                    {
                        line = record["Login"].ToString()+";"+ record["Password"].ToString();
                        Debug.WriteLine(0, "Table: " + record["login"]);

                    }
                    connect.Close();
                    return line;
                }
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(3, "Select User Password DataBase: " + ex.Message);
                return null;
            }
        }
        public static void TestBase()
        {
            if (File.Exists(databaseName) == false) Debug.WriteLine(0, "Data base file not found");
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName+";Version=3;"))
                {
                    connect.Open();
                    SQLiteCommand command = new SQLiteCommand
                    {
                        Connection = connect,
                        CommandText = "SELECT * FROM Users"
                    };
                    SQLiteDataReader reader = command.ExecuteReader();
                    
                    foreach(DbDataRecord record in reader)
                    {
                        Debug.WriteLine(0, "Table: " + record["Login"]);
                        //new Users( )
                        UsersList.Add(new Users(record["Login"].ToString(), record["FullName"].ToString(), "0", "0", "0", 0));

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
