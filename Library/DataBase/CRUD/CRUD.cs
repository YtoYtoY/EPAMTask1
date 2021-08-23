using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using Library.DataBase.ORM;

namespace Library.DataBase.CRUD
{
    /// <summary>
    /// The class implements basic database operations such as Create, Read, Update and Delete
    /// </summary>
    /// <typeparam name="T">Generic parameter</typeparam>
    public static class CRUD<T>
    {
        /// <summary>
        /// This method helps to get an string of headers for non-code injection
        /// </summary>
        /// <param name="objType">Object type</param>
        /// <param name="spliter">Special character / string</param>
        /// <returns>String of headers of table</returns>
        public static string GetHeads(Type objType, string spliter)
        {
            string result = string.Empty;
            PropertyInfo[] properties = objType.GetProperties();
            foreach (var item in properties)
                result += spliter + item.Name + ", ";

            int delete = result.Length - 2;
            result = result.Substring(0, delete);

            return result;
        }

        /// <summary>
        /// Method for adding data to the database
        /// </summary>
        /// <param name="objType">Object type</param>
        /// <param name="toAdd">The data to add</param>
        public static void Create(Type objType, object[] toAdd)
        {
            PropertyInfo[] properties = objType.GetProperties();
            try
            {
                ConnectionSettings.OpenConnection();

                string query = $"INSERT INTO [{objType.Name}] " +
                    $"({GetHeads(objType, "")}) VALUES ({GetHeads(objType, "@")})";

                SqlCommand command = new SqlCommand(query, ConnectionSettings.GetConnection());

                for (int i = 0; i < properties.Length; i++)
                {
                    command.Parameters.AddWithValue(properties[i].Name, toAdd[i]);
                }
                command.ExecuteNonQuery();

                Library.GetAll();
                ConnectionSettings.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Method for reading data from the database
        /// </summary>
        /// <param name="objType">Object type</param>
        /// <returns>Returns a list of objects in this table from the database</returns>
        public static List<object> Read(Type objType)
        {
            ConnectionSettings.OpenConnection();
            SqlDataReader dataReader = null;
            List<object> list = new List<object>();

            try
            {
                string query = $"SELECT * FROM {objType.Name}";

                SqlCommand command = new SqlCommand(query, ConnectionSettings.GetConnection());

                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    var obj = Activator.CreateInstance(objType);
                    obj = Entity.SetObject(obj, dataReader);
                    list.Add(obj);
                }

                ConnectionSettings.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dataReader != null && !dataReader.IsClosed)
                {
                    dataReader.Close();
                }
            }
            
            return list;

        }

        /// <summary>
        /// Changing data in the database
        /// </summary>
        /// <param name="objType">Object type</param>
        /// <param name="toUpdate">The data to update (the first object is the number of the element to be changed)</param>
        public static void Update(Type objType, object[] toUpdate)
        {
            PropertyInfo[] properties = objType.GetProperties();
            try
            {
                ConnectionSettings.OpenConnection();

                string updateSet = string.Empty;

                for (int i = 1; i < toUpdate.Length; i++)
                {
                    updateSet += properties[i].Name + " = @" + properties[i].Name;
                    if (i + 1 != toUpdate.Length)
                        updateSet += ", ";
                }

                string query = $"UPDATE [{objType.Name}] " +
                    $"SET {updateSet} WHERE ({properties[0].Name} = @{properties[0].Name})";

                SqlCommand command = new SqlCommand(query, ConnectionSettings.GetConnection());

                for (int i = 0; i < properties.Length; i++)
                {
                    command.Parameters.AddWithValue(properties[i].Name, toUpdate[i]);
                }
                command.ExecuteNonQuery();

                Library.GetAll();
                ConnectionSettings.CloseConnection();
            }
            catch (Exception ex)
            {

                throw new Exception (ex.Message);
            }
        }

        /// <summary>
        /// Removing data from the database
        /// </summary>
        /// <param name="objType">Object type</param>
        /// <param name="objId">Element number in the table</param>
        public static void Delete(Type objType, int objId)
        {
            PropertyInfo[] properties = objType.GetProperties();
            try
            {
                ConnectionSettings.OpenConnection();

                string query = $"DELETE FROM [{objType.Name}] " +
                    $"WHERE ({properties[0].Name} = @{properties[0].Name})";

                SqlCommand command = new SqlCommand(query, ConnectionSettings.GetConnection());

                command.Parameters.AddWithValue(properties[0].Name, objId);
                command.ExecuteNonQuery();

                Library.GetAll();
                ConnectionSettings.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
