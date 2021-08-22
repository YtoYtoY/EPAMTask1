using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library.DataBase
{
    public static class ConnectionSettings
    {
        private static SqlConnection connection = null;

        public static void OpenConnection()
        {
            connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["LibraryDB"]
                .ConnectionString);
            connection.Open();
        }

        public static void CloseConnection()
        {
            connection.Close();
            connection = null;
        }

        public static SqlConnection GetConnection() => connection;
    }
}
