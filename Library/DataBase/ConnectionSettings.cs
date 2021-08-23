using System.Configuration;
using System.Data.SqlClient;

namespace Library.DataBase
{
    /// <summary>
    /// The class is responsible for setting up the database
    /// </summary>
    public static class ConnectionSettings
    {
        /// <summary>
        /// The variable for the current database connection
        /// </summary>
        private static SqlConnection connection = null;

        /// <summary>
        /// The method opens a connection to the database
        /// </summary>
        public static void OpenConnection()
        {
            connection = new SqlConnection(ConfigurationManager
                .ConnectionStrings["LibraryDB"]
                .ConnectionString);
            connection.Open();
        }

        /// <summary>
        /// The method closes the connection to the database
        /// </summary>
        public static void CloseConnection()
        {
            if (connection != null)
                connection.Close();
            connection = null;
        }

        /// <summary>
        /// Return the current connection
        /// </summary>
        /// <returns>Current SqlConnection</returns>
        public static SqlConnection GetConnection() => connection;
    }
}
