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
        /// <summary>
        /// Хотябы один параметр должет быть кроме id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="fullname"></param>
        /// <param name="date_reg"></param>
        /// <param name="online"></param>
        /// <param name="last_ip"></param>
        public static void Update_Parametrs(string id, string login = null, string password = null,string fullname = null,string date_reg = null,string online = null,string last_ip = null)
        {
            string sql_command = "UPDATE Users SET";
            if (login != null && !login.Equals("") && login == String.Empty) sql_command += $" Login = '{login}'";
            else if (password != null && !password.Equals("")) sql_command += $" Password = '{password}'";
            else if (fullname != null && !fullname.Equals("")) sql_command += $" FullName = '{fullname}'";
            else if (date_reg != null && !date_reg.Equals("")) sql_command += $" Date_reg = '{date_reg}'";
            else if (online != null && !online.Equals("")) sql_command += $" Online = '{online}'";
            else if (last_ip != null && !last_ip.Equals("")) sql_command += $" Last_IP {last_ip}'";
            else { Debug.WriteLine(2, "void Update_Parametrs is null"); return; }
            sql_command += " WHERE id = " + id;
            Debug.WriteLine(0, $"Send sql command : {sql_command}");
            try
            {
                using (SQLiteConnection connect = new SQLiteConnection("Data Source=" + databaseName + ";Version=3;"))
                {
                    connect.Open();
                    SQLiteCommand command = new SQLiteCommand(sql_command, connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(3, "void Update_Parametrs: " + ex.Message);
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
                        UsersList.Add(new Users(record["id"].ToString(),record["Login"].ToString(), record["FullName"].ToString(), record["Date_reg"].ToString(), record["Online"].ToString(), record["Last_IP"].ToString(), 0));

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
